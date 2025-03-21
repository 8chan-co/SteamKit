﻿using System;
using System.IO;
using System.Linq;
using System.Reflection;
using ProtoBuf.Meta;

namespace NetHookAnalyzer2.Specializations
{
	static class UnifiedMessagingHelpers
	{
		public static MethodInfo FindMethodInfo(string serviceMethodName)
		{
			if ( string.IsNullOrEmpty( serviceMethodName ) )
			{
				return null;
			}

			var splitByDot = serviceMethodName.Split('.');
			var interfaceName = "I" + splitByDot[0];
			var methodName = splitByDot[1].Split('#').First();

			var namespaces = new[]
			{
				("SteamKitten", "SteamKitten.Internal"),
				("SteamKitten", "SteamKitten.Internal.Steamworks"),
				("SteamKitten", "SteamKitten.WebUI.Internal"),
			};

			foreach (var (assembly, ns) in namespaces)
			{
				var interfaceType = Type.GetType($"{ns}.{interfaceName}, {assembly}");
				if (interfaceType != null)
				{
					var method = interfaceType.GetMethod(methodName);
					if (method != null)
					{
						return method;
					}
				}
			}

			return null;
		}

		public static object ReadServiceMethodBody(string methodName, Stream stream, Func<MethodInfo, Type> typeSelector)
		{
			var methodInfo = FindMethodInfo(methodName);
			if (methodInfo != null)
			{
				var requestType = typeSelector(methodInfo);
				var request = RuntimeTypeModel.Default.Deserialize(stream, null, requestType);
				return request;
			}

			return null;
		}
	}
}
