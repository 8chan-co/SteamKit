﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamKitten.Discovery
{
    /// <summary>
    /// A server list provider that returns an empty list, for consumers that populate the server list themselves
    /// </summary>
    public class NullServerListProvider : IServerListProvider
    {
        /// <summary>
        /// Always returns <see cref="DateTime.MinValue"/>
        /// </summary>
        public DateTime LastServerListRefresh => DateTime.MinValue;

        /// <summary>
        /// No-op implementation that returns an empty server list
        /// </summary>
        /// <returns>Empty server list</returns>
        public Task<IEnumerable<ServerRecord>> FetchServerListAsync()
            => Task.FromResult(Enumerable.Empty<ServerRecord>());

        /// <summary>
        /// No-op implementation that does not persist server list
        /// </summary>
        /// <param name="endpoints">Server list</param>
        /// <returns>Completed task</returns>
        public Task UpdateServerListAsync(IEnumerable<ServerRecord> endpoints)
            => Task.CompletedTask;
    }
}
