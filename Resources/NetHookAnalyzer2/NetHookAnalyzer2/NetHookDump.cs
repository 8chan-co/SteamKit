﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using SteamKitten.Internal;

namespace NetHookAnalyzer2
{
	internal class NetHookDump
	{
		public NetHookDump()
		{
			items = [];
			readOnlyView = items.AsReadOnly();
		}

		List<NetHookItem> items;
		IReadOnlyList<NetHookItem> readOnlyView;
		static Dictionary<int, byte[]> accountAuthSecrets = [];

		public void LoadFromDirectory(string directory)
		{
			items.Clear();

			var directoryInfo = new DirectoryInfo(directory);
			var itemFiles = directoryInfo.EnumerateFiles("*.bin", SearchOption.TopDirectoryOnly);
			foreach (var itemFile in itemFiles)
			{
				AddItemFromFile(itemFile);
			}
		}

		public IEnumerable<NetHookItem> Items => readOnlyView;

		public static byte[] GetAccountAuthSecret(int secretId) => accountAuthSecrets.GetValueOrDefault(secretId);

		public NetHookItem AddItemFromFile(FileInfo fileInfo)
		{
			var item = new NetHookItem();
			if (!item.LoadFromFile(fileInfo))
			{
				return null;
			}

			items.Add(item);

			if (item.EMsg == SteamKitten.EMsg.ServiceMethodResponse && item.InnerMessageName == "Credentials.GetAccountAuthSecret#1")
			{
				var authSecretBody = item.ReadFile().Body as CCredentials_GetAccountAuthSecret_Response;

				if (authSecretBody != null)
				{
					accountAuthSecrets[ authSecretBody.secret_id ] = authSecretBody.secret;
				}
			}

			return item;
		}

		public NetHookItem RemoveItemWithPath(string path)
		{
			var item = items.SingleOrDefault(x => x.FileInfo.FullName == path);
			if (item == null)
			{
				return null;
			}

			items.Remove(item);
			return item;
		}
	}
}
