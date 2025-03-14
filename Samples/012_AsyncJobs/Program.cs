﻿using System;
using System.Linq;
using System.IO;
using System.Net;
using SteamKitten;
using System.Threading.Tasks;

//
// Sample 9: AsyncJobs
//
// this sample will give an example of how job based messages can now be used in
// an async fashion (either with the async/await pattern, or directly via TPL tasks)
//
// in this example, we'll request some information about some Steam products in an async
// manner with the SteamApps handler

if ( args.Length < 2 )
{
    Console.WriteLine( "Sample9: No username and password specified!" );
    return;
}

// save our logon details
var user = args[ 0 ];
var pass = args[ 1 ];

// create our steamclient instance
var steamClient = new SteamClient();
// create the callback manager which will route callbacks to function calls
var manager = new CallbackManager( steamClient );

// get the steamuser handler, which is used for logging on after successfully connecting
var steamUser = steamClient.GetHandler<SteamUser>();

// get our steamapps handler, we'll use this as an example of how async jobs can be handled
var steamApps = steamClient.GetHandler<SteamApps>();

// register a few callbacks we're interested in
// these are registered upon creation to a callback manager, which will then route the callbacks
// to the functions specified
manager.Subscribe<SteamClient.ConnectedCallback>( OnConnected );
manager.Subscribe<SteamClient.DisconnectedCallback>( OnDisconnected );

manager.Subscribe<SteamUser.LoggedOnCallback>( OnLoggedOn );
manager.Subscribe<SteamUser.LoggedOffCallback>( OnLoggedOff );

// notice that we're not subscribing to the SteamApps.PICSProductInfoCallback callback here (or other SteamApps callbacks)
// since this sample is using the async job directly, we no longer need to subscribe to the callback.
// however, if we still wish to use callbacks (or have existing code which subscribes to callbacks, they will
// continue to operate alongside direct async job handling. (i.e.: steamclient will still post callbacks for
// any async jobs that are completed)

var isRunning = true;

Console.WriteLine( "Connecting to Steam..." );

// initiate the connection
steamClient.Connect();

// create our callback handling loop
while ( isRunning )
{
    // in order for the callbacks to get routed, they need to be handled by the manager
    manager.RunWaitCallbacks( TimeSpan.FromSeconds( 1 ) );
}

void OnConnected( SteamClient.ConnectedCallback callback )
{
    Console.WriteLine( "Connected to Steam! Logging in '{0}'...", user );

    steamUser.LogOn( new SteamUser.LogOnDetails
    {
        Username = user,
        Password = pass,
    } );
}

void OnDisconnected( SteamClient.DisconnectedCallback callback )
{
    Console.WriteLine( "Disconnected from Steam" );

    isRunning = false;
}

async void OnLoggedOn( SteamUser.LoggedOnCallback callback )
{
    if ( callback.Result != EResult.OK )
    {
        if ( callback.Result == EResult.AccountLogonDenied )
        {
            // if we recieve AccountLogonDenied or one of it's flavors (AccountLogonDeniedNoMailSent, etc)
            // then the account we're logging into is SteamGuard protected
            // see sample 5 for how SteamGuard can be handled

            Console.WriteLine( "Unable to logon to Steam: This account is SteamGuard protected." );

            isRunning = false;
            return;
        }

        Console.WriteLine( "Unable to logon to Steam: {0} / {1}", callback.Result, callback.ExtendedResult );

        isRunning = false;
        return;
    }

    // in this sample, we'll simply do a few async requests to acquire information about Counter-Strike: Global Offensive

    uint appid = 730;
    uint depotid = 731;

    // first, we'll request a depot decryption key for CSGO's common files depot (731)
    var depotJob = steamApps.GetDepotDecryptionKey( depotid, appid );

    // at this point, this request is now in-flight to the steam server, so we'll use te async/await pattern to wait for a response
    // the await pattern allows this code to resume once the Steam servers have replied to the request.
    // if Steam does not reply to the request in a timely fashion (controlled by the `Timeout` field on the AsyncJob object), the underlying
    // task for this job will be cancelled, and TaskCanceledException will be thrown.
    // additionally, if Steam encounters a remote failure and is unable to process your request, the job will be faulted and an AsyncJobFailedException
    // will be thrown.
    SteamApps.DepotKeyCallback depotKey = await depotJob;

    if ( depotKey.Result == EResult.OK )
    {
        Console.WriteLine( $"Got our depot key: {BitConverter.ToString( depotKey.DepotKey )}" );
    }
    else
    {
        Console.WriteLine( "Unable to request depot key!" );
    }

    // now request the access token
    var accessTokenJob = steamApps.PICSGetAccessTokens( appid, package: null );
    var accessTokenResult = await accessTokenJob;
    ulong accessToken = 0;

    // Get the access token, if the app is owned it may be a long value, or 0 if it is public.
    // If the request was denied, the appid will be listed in AppTokensDenied.
    accessTokenResult.AppTokens.TryGetValue( appid, out accessToken );

    // create a request product info request struct
    var request = new SteamApps.PICSRequest( appid, accessToken );

    // now request some product info
    var productJob = steamApps.PICSGetProductInfo( app: request, package: null, metaDataOnly: false );

    // note that with some requests, Steam can return multiple results, so these jobs don't return the callback object directly, but rather
    // a result set that could contain multiple callback objects if Steam gives us multiple results
    AsyncJobMultiple<SteamApps.PICSProductInfoCallback>.ResultSet resultSet = await productJob;

    if ( resultSet.Complete )
    {
        // the request fully completed, we can handle the data
        SteamApps.PICSProductInfoCallback productInfo = resultSet.Results.First();

        // ... do something with our product info
    }
    else if ( resultSet.Failed )
    {
        // the request partially completed, and then Steam encountered a remote failure. for async jobs with only a single result (such as
        // GetDepotDecryptionKey), this would normally throw an AsyncJobFailedException. but since Steam had given us a partial set of callbacks
        // we get to decide what to do with the data

        // keep in mind that if Steam immediately fails to provide any data, or times out while waiting for the first result, an
        // AsyncJobFailedException or TaskCanceledException will be thrown

        // the result set might not have our data, so we need to test to see if we have results for our request
        SteamApps.PICSProductInfoCallback productInfo = resultSet.Results.FirstOrDefault( prodCallback => prodCallback.Apps.ContainsKey( appid ) );

        if ( productInfo != null )
        {
            // we were lucky and Steam gave us the info we requested before failing
        }
        else
        {
            // bad luck
        }
    }
    else
    {
        // the request partially completed, but then we timed out. essentially the same as the previous case, but Steam didn't explicitly fail.

        // we still need to check our result set to see if we have our data
        SteamApps.PICSProductInfoCallback productInfo = resultSet.Results.FirstOrDefault( prodCallback => prodCallback.Apps.ContainsKey( appid ) );

        if ( productInfo != null )
        {
            // we were lucky and Steam gave us the info we requested before timing out
        }
        else
        {
            // bad luck
        }
    }

    // lastly, if you're unable to use the async/await pattern (older VS/compiler, etc) you can still directly access the TPL Task associated
    // with the async job by calling `ToTask()`
    var depotTask = steamApps.GetDepotDecryptionKey( depotid, appid ).ToTask();

    // set up a continuation for when this task completes
    var ignored = depotTask.ContinueWith( task =>
    {
        depotKey = task.Result;

        // do something with the depot key

        // we're finished with this sample, drop out of the callback loop
        isRunning = false;

    }, TaskContinuationOptions.OnlyOnRanToCompletion );
}

void OnLoggedOff( SteamUser.LoggedOffCallback callback )
{
    Console.WriteLine( "Logged off of Steam: {0}", callback.Result );
}
