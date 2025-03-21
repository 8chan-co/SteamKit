using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Threading.Tasks;
using ProtoBuf;

namespace SteamKitten.Discovery
{
    /// <summary>
    /// A server list provider that uses IsolatedStorage to persist the server list
    /// </summary>
    public class IsolatedStorageServerListProvider : IServerListProvider
    {
        private const string FileName = "serverlist.protobuf";

        IsolatedStorageFile isolatedStorage;

        /// <summary>
        /// Initialize a new instance of IsolatedStorageServerListProvider using <see cref="IsolatedStorageFile.GetUserStoreForAssembly"/>
        /// </summary>
        public IsolatedStorageServerListProvider()
        {
            isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly();
        }

        /// <summary>
        /// Returns the last time the file was written to storage
        /// </summary>
        public DateTime LastServerListRefresh => isolatedStorage.GetLastWriteTime(FileName).UtcDateTime;

        /// <summary>
        /// Read the stored list of servers from IsolatedStore
        /// </summary>
        /// <returns>List of servers if persisted, otherwise an empty list</returns>
        public Task<IEnumerable<ServerRecord>> FetchServerListAsync()
        {
            return Task.Run(() =>
            {
                try
                {
                    using var fileStream = isolatedStorage.OpenFile( FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite );
                    return Serializer.DeserializeItems<BasicServerListProto>( fileStream, PrefixStyle.Base128, 1 )
                        .Select( item => ServerRecord.CreateServer( item.Address, item.Port, item.Protocols ) )
                        .ToList();
                }
                catch (IOException ex)
                {
                    DebugLog.WriteLine("IsolatedStorageServerListProvider", "Failed to read file {0}: {1}", FileName, ex.Message);
                    return Enumerable.Empty<ServerRecord>();
                }
            });
        }

        /// <summary>
        /// Writes the supplied list of servers to persistent storage
        /// </summary>
        /// <param name="endpoints">List of server endpoints</param>
        /// <returns>Awaitable task for write completion</returns>
        public Task UpdateServerListAsync(IEnumerable<ServerRecord> endpoints)
        {
            ArgumentNullException.ThrowIfNull( endpoints );

            return Task.Run(() =>
            {
                try
                {
                    using IsolatedStorageFileStream fileStream = isolatedStorage.OpenFile( FileName, FileMode.Create );
                    Serializer.Serialize( fileStream,
                        endpoints.Select( ep =>
                        {
                            return new BasicServerListProto
                            {
                                Address = ep.GetHost(),
                                Port = ep.GetPort(),
                                Protocols = ep.ProtocolTypes
                            };
                        } ) );
                    fileStream.SetLength( fileStream.Position );
                }
                catch (IOException ex)
                {
                    DebugLog.WriteLine("IsolatedStorageServerListProvider", "Failed to write file {0}: {1}", FileName, ex.Message);
                }
            });
        }
    }
}
