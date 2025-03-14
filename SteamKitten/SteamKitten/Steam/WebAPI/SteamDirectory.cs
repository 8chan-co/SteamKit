using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SteamKitten.Discovery;

namespace SteamKitten
{
    /// <summary>
    /// Helper class to load servers from the Steam Directory Web API.
    /// </summary>
    public static class SteamDirectory
    {
        /// <summary>
        /// Load a list of servers from the Steam Directory.
        /// </summary>
        /// <param name="configuration">Configuration Object</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> with the Result set to an enumerable list of <see cref="ServerRecord"/>s.</returns>
        public static Task<IReadOnlyCollection<ServerRecord>> LoadAsync( SteamConfiguration configuration )
            => LoadCoreAsync( configuration, null, CancellationToken.None );

        /// <summary>
        /// Load a list of servers from the Steam Directory.
        /// </summary>
        /// <param name="configuration">Configuration Object</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> with the Result set to an enumerable list of <see cref="ServerRecord"/>s.</returns>
        public static Task<IReadOnlyCollection<ServerRecord>> LoadAsync( SteamConfiguration configuration, CancellationToken cancellationToken )
            => LoadCoreAsync( configuration, null, cancellationToken );

        /// <summary>
        /// Load a list of servers from the Steam Directory.
        /// </summary>
        /// <param name="configuration">Configuration Object</param>
        /// <param name="maxNumServers">Max number of servers to return. The API will typically return this number per server type (socket and websocket).</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> with the Result set to an enumerable list of <see cref="ServerRecord"/>s.</returns>
        public static Task<IReadOnlyCollection<ServerRecord>> LoadAsync( SteamConfiguration configuration, int maxNumServers, CancellationToken cancellationToken )
            => LoadCoreAsync( configuration, maxNumServers, cancellationToken );

        static async Task<IReadOnlyCollection<ServerRecord>> LoadCoreAsync( SteamConfiguration configuration, int? maxNumServers, CancellationToken cancellationToken )
        {
            ArgumentNullException.ThrowIfNull( configuration );

            using var directory = configuration.GetAsyncWebAPIInterface( "ISteamDirectory" );
            var args = new Dictionary<string, object?>
            {
                ["cellid"] = configuration.CellID.ToString( CultureInfo.InvariantCulture )
            };

            if ( maxNumServers.HasValue )
            {
                args[ "maxcount" ] = maxNumServers.Value.ToString( CultureInfo.InvariantCulture );
            }

            cancellationToken.ThrowIfCancellationRequested();

            var response = await directory.CallAsync( HttpMethod.Get, "GetCMListForConnect", version: 1, args: args ).ConfigureAwait( false );

            if ( !response[ "success" ].AsBoolean() )
            {
                throw new InvalidOperationException( $"Steam Web API returned failure - {response[ "message" ].AsString() ?? "unknown"}" );
            }

            var socketList = response[ "serverlist" ];

            cancellationToken.ThrowIfCancellationRequested();

            var serverRecords = new List<ServerRecord>( capacity: socketList.Children.Count );

            foreach ( var child in socketList.Children )
            {
                var endpoint = child[ "endpoint" ].Value;

                if ( endpoint == null )
                {
                    continue;
                }

                var record = child[ "type" ].Value switch
                {
                    "websockets" => ServerRecord.CreateWebSocketServer( endpoint ),
                    "netfilter" => ServerRecord.CreateDnsSocketServer( endpoint ),
                    // TODO: There's also "china" type which uses websocket
                    _ => null,
                };

                if ( record != null )
                {
                    serverRecords.Add( record );
                }
            }

            return serverRecords.AsReadOnly();
        }
    }
}
