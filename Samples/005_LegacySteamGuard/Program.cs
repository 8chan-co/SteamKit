﻿using System;
using System.Threading;

using SteamKitten;

//
// WARNING!
// This the old login flow, which may still work, but you will not receive machine auth.
// See Sample1a_Authentication for the new flow.
// This sample will be removed in the future. 
//

//
// Sample 5: SteamGuard
//
// this sample goes into detail for how to handle steamguard protected accounts and how to login to them
//
// SteamGuard works by enforcing a two factor authentication scheme
// upon first logon to an account with SG enabled, the steam server will email an authcode to the validated address of the account
// this authcode token can be used as the second factor during logon, but the token has a limited time span in which it is valid
//
// after a client logs on using the authcode, the steam server will generate a blob of random data that the client stores called a "sentry file"
// this sentry file is then used in all subsequent logons as the second factor
// ownership of this file provides proof that the machine being used to logon is owned by the client in question
//
// the usual login flow is thus:
// 1. connect to the server
// 2. logon to account with only username and password
// at this point, if the account is steamguard protected, the LoggedOnCallback will have a result of AccountLogonDenied
// the server will disconnect the client and email the authcode
//
// the login flow must then be restarted:
// 1. connect to server
// 2. logon to account using username, password, and authcode
// at this point, login wil succeed and a UpdateMachineAuthCallback callback will be posted with the sentry file data from the steam server
// the client will save the file, and reply to the server informing that it has accepted the sentry file
// 
// all subsequent logons will use this flow:
// 1. connect to server
// 2. logon to account using username, password, and sha-1 hash of the sentry file

if ( args.Length < 2 )
{
    Console.WriteLine( "Sample5: No username and password specified!" );
    return;
}

// save our logon details
var user = args[ 0 ];
var pass = args[ 1 ];

string authCode = null, twoFactorAuth = null;

// create our steamclient instance
var steamClient = new SteamClient();
// create the callback manager which will route callbacks to function calls
var manager = new CallbackManager( steamClient );

// get the steamuser handler, which is used for logging on after successfully connecting
var steamUser = steamClient.GetHandler<SteamUser>();

// register a few callbacks we're interested in
// these are registered upon creation to a callback manager, which will then route the callbacks
// to the functions specified
manager.Subscribe<SteamClient.ConnectedCallback>( OnConnected );
manager.Subscribe<SteamClient.DisconnectedCallback>( OnDisconnected );

manager.Subscribe<SteamUser.LoggedOnCallback>( OnLoggedOn );
manager.Subscribe<SteamUser.LoggedOffCallback>( OnLoggedOff );

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
                
        // in this sample, we pass in an additional authcode
        // this value will be null (which is the default) for our first logon attempt
        AuthCode = authCode,

        // if the account is using 2-factor auth, we'll provide the two factor code instead
        // this will also be null on our first logon attempt
        TwoFactorCode = twoFactorAuth,
    } );
}

void OnDisconnected( SteamClient.DisconnectedCallback callback )
{
    // after recieving an AccountLogonDenied, we'll be disconnected from steam
    // so after we read an authcode from the user, we need to reconnect to begin the logon flow again

    Console.WriteLine( "Disconnected from Steam, reconnecting in 5..." );

    Thread.Sleep( TimeSpan.FromSeconds( 5 ) );

    steamClient.Connect();
}

void OnLoggedOn( SteamUser.LoggedOnCallback callback )
{
    bool isSteamGuard = callback.Result == EResult.AccountLogonDenied;
    bool is2FA = callback.Result == EResult.AccountLoginDeniedNeedTwoFactor;

    if ( isSteamGuard || is2FA )
    {
        Console.WriteLine( "This account is SteamGuard protected!" );

        if ( is2FA )
        {
            Console.Write( "Please enter your 2 factor auth code from your authenticator app: " );
            twoFactorAuth = Console.ReadLine();
        }
        else
        {
            Console.Write( "Please enter the auth code sent to the email at {0}: ", callback.EmailDomain );
            authCode = Console.ReadLine();
        }

        return;
    }

    if ( callback.Result != EResult.OK )
    {
        Console.WriteLine( "Unable to logon to Steam: {0} / {1}", callback.Result, callback.ExtendedResult );

        isRunning = false;
        return;
    }

    Console.WriteLine( "Successfully logged on!" );

    // at this point, we'd be able to perform actions on Steam
}

void OnLoggedOff( SteamUser.LoggedOffCallback callback )
{
    Console.WriteLine( "Logged off of Steam: {0}", callback.Result );
}
