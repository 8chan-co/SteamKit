﻿/*
 * This file is subject to the terms and conditions defined in
 * file 'license.txt', which is part of this source code package.
 */

using System;
using System.Collections.Generic;
using System.Net;
using SteamKitten.Internal;

namespace SteamKitten
{
    /// <summary>
    /// This handler is used for requesting server list details from Steam.
    /// </summary>
    public sealed partial class SteamMasterServer : ClientMsgHandler
    {
        /// <summary>
        /// Details used when performing a server list query.
        /// </summary>
        public sealed class QueryDetails
        {
            /// <summary>
            /// Gets or sets the AppID used when querying servers.
            /// </summary>
            public uint AppID { get; set; }

            /// <summary>
            /// Gets or sets the filter used for querying the master server.
            /// Check https://developer.valvesoftware.com/wiki/Master_Server_Query_Protocol for details on how the filter is structured.
            /// </summary>
            public string? Filter { get; set; }
            /// <summary>
            /// Gets or sets the region that servers will be returned from.
            /// </summary>
            public ERegionCode Region { get; set; }

            /// <summary>
            /// Gets or sets the IP address that will be GeoIP located.
            /// This is done to return servers closer to this location.
            /// </summary>
            public IPAddress? GeoLocatedIP { get; set; }

            /// <summary>
            /// Gets or sets the maximum number of servers to return.
            /// </summary>
            public uint MaxServers { get; set; }
        }

        private static CallbackMsg? GetCallback( IPacketMsg packetMsg ) => packetMsg.MsgType switch
        {
            EMsg.GMSClientServerQueryResponse => new QueryCallback( packetMsg ),
            _ => null,
        };

        /// <summary>
        /// Requests a list of servers from the Steam game master server.
        /// Results are returned in a <see cref="QueryCallback"/>.
        /// The returned <see cref="AsyncJob{T}"/> can also be awaited to retrieve the callback result.
        /// </summary>
        /// <param name="details">The details for the request.</param>
        /// <returns>The Job ID of the request. This can be used to find the appropriate <see cref="QueryCallback"/>.</returns>
        public AsyncJob<QueryCallback> ServerQuery( QueryDetails details )
        {
            ArgumentNullException.ThrowIfNull( details );

            var query = new ClientMsgProtobuf<CMsgClientGMSServerQuery>( EMsg.ClientGMSServerQuery );
            query.SourceJobID = Client.GetNextJobID();

            query.Body.app_id = details.AppID;

            if ( details.GeoLocatedIP != null )
            {
                query.Body.geo_location_ip = NetHelpers.GetIPAddressAsUInt( details.GeoLocatedIP );
            }

            query.Body.filter_text = details.Filter;
            query.Body.region_code = ( uint )details.Region;

            query.Body.max_servers = details.MaxServers;

            this.Client.Send( query );

            return new AsyncJob<QueryCallback>( this.Client, query.SourceJobID );
        }

        /// <summary>
        /// Handles a client message. This should not be called directly.
        /// </summary>
        /// <param name="packetMsg">The packet message that contains the data.</param>
        public override void HandleMsg( IPacketMsg packetMsg )
        {
            var callback = GetCallback( packetMsg );

            if ( callback == null )
            {
                // ignore messages that we don't have a handler function for
                return;
            }

            this.Client.PostCallback( callback );
        }
    }
}
