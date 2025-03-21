﻿using System;
using System.Collections.Generic;
using System.IO;
using ProtoBuf;
using ProtoBuf.Meta;
using SteamKitten.GC.Dota.Internal;

namespace NetHookAnalyzer2.Specializations
{
    class Dota2CacheSubscribedGCSpecialization : IGameCoordinatorSpecialization
    {
        public IEnumerable<KeyValuePair<string, object>> GetExtraObjects(object body, uint appID)
        {
            if (appID != WellKnownAppIDs.Dota2)
            {
                yield break;
            }

            var cacheSubscribed = body as CMsgSOCacheSubscribed;
            if (cacheSubscribed == null)
            {
                yield break;
            }

            foreach (var bucket in cacheSubscribed.objects)
            {
                int typeId = bucket.type_id;
                foreach (var singleObject in bucket.object_data)
                {
                    var extraNode = ReadExtraObject(singleObject, typeId);
                    if (extraNode != null)
                    {
                        yield return new KeyValuePair<string, object>(string.Format("SO ({0})", extraNode.GetType().Name), extraNode);
                    }
                }
            }
        }

        static object ReadExtraObject(byte[] sharedObject, int typeId)
        {
            try
            {
                using var ms = new MemoryStream( sharedObject );
                if ( Dota2SOHelper.SOTypes.TryGetValue( typeId, out var t ) )
                {
                    return RuntimeTypeModel.Default.Deserialize( ms, null, t );
                }
            }
            catch (ProtoException ex)
            {
                return "Error parsing SO data: " + ex.Message;
            }
            catch (EndOfStreamException ex)
            {
                return "Error parsing SO data: " + ex.Message;
            }

            return null;
        }
    }
}
