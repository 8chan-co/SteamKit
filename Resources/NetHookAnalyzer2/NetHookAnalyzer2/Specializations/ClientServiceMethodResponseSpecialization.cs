﻿using System.Collections.Generic;
using System.IO;
using SteamKitten.Internal;

namespace NetHookAnalyzer2.Specializations
{
	class ClientServiceMethodResponseSpecialization : ISpecialization
	{
		public IEnumerable<KeyValuePair<string, object>> ReadExtraObjects(object messageObject)
		{
			var serviceMethodBody = messageObject as CMsgClientServiceMethodLegacyResponse;
			if (serviceMethodBody == null)
			{
				yield break;
			}

			var name = serviceMethodBody.method_name;
			object innerBody = null;

			if ( serviceMethodBody.serialized_method_response != null )
			{
				using var ms = new MemoryStream(serviceMethodBody.serialized_method_response);
				innerBody = UnifiedMessagingHelpers.ReadServiceMethodBody(name, ms, x => x.ReturnType);
			}

			yield return new KeyValuePair<string, object>("Service Method Response", innerBody);
		}
	}
}
