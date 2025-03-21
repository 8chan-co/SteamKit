﻿/*
 * This file is subject to the terms and conditions defined in
 * file 'license.txt', which is part of this source code package.
 */

using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using SteamKitten.Internal;

namespace SteamKitten
{
    public sealed partial class SteamMasterServer
    {
        /// <summary>
        /// This callback is received in response to calling <see cref="ServerQuery"/>.
        /// </summary>
        public sealed class QueryCallback : CallbackMsg
        {
            /// <summary>
            /// Represents a single server.
            /// </summary>
            public sealed class Server
            {
                /// <summary>
                /// Gets the IP endpoint of the server.
                /// </summary>
                public IPEndPoint EndPoint { get; private set; }

                /// <summary>
                /// Gets the number of Steam authenticated players on this server.
                /// </summary>
                public uint AuthedPlayers { get; private set; }


                internal Server( CMsgGMSClientServerQueryResponse.Server server )
                {
                    EndPoint = new IPEndPoint(
                        server.server_ip.GetIPAddress(),
                        ( int )server.query_port );

                    AuthedPlayers = server.auth_players;
                }
            }

            /// <summary>
            /// Gets the list of servers.
            /// </summary>
            public ReadOnlyCollection<Server> Servers { get; private set; }


            internal QueryCallback( IPacketMsg packetMsg )
            {
                var queryResponse = new ClientMsgProtobuf<CMsgGMSClientServerQueryResponse>( packetMsg );
                var msg = queryResponse.Body;

                JobID = queryResponse.TargetJobID;

                var serverList = msg.servers
                    .Select( s => new Server( s ) )
                    .ToList();

                this.Servers = new ReadOnlyCollection<Server>( serverList );
            }
        }
    }
}
