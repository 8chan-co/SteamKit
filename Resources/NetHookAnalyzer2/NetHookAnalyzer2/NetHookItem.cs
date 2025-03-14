﻿using System;
using System.IO;
using System.Text.RegularExpressions;
using ProtoBuf;
using SteamKitten;
using SteamKitten.Internal;

namespace NetHookAnalyzer2
{
	partial class NetHookItem
	{
		public enum PacketDirection
		{
			In,
			Out
		}

		static Regex NameRegex = NameRegexGenerated();

		public int Sequence { get; private set; }
		public DateTime Timestamp { get; private set; }
		public PacketDirection Direction { get; private set; }
		public EMsg EMsg { get; private set; }

		public string InnerMessageName
		{
			get { return innerMessageName ??= ReadInnerMessageName(); }
		}
		string innerMessageName;

		public FileInfo FileInfo { get; private set; }

		public Stream OpenStream()
		{
			return FileInfo.OpenRead();
		}

		public bool LoadFromFile(FileInfo fileInfo)
		{
			Match m = NameRegex.Match( fileInfo.Name );

			if ( !m.Success )
			{
				return false;
			}

			if (!int.TryParse(m.Groups["num"].Value, out var sequence))
			{
				return false;
			}

			Timestamp = fileInfo.LastWriteTime;

			var direction = m.Groups[ "direction" ].Value;

			if (!Enum.TryParse<PacketDirection>(direction, ignoreCase: true, result: out var packetDirection))
			{
				return false;
			}

			if (!uint.TryParse(m.Groups["emsg"].Value, out var emsg))
			{
				return false;
			}

			FileInfo = fileInfo;

			Sequence = sequence;
			Direction = packetDirection;
			EMsg = (EMsg)emsg;

			return true;
		}

		string ReadInnerMessageName()
		{
			try
			{
				return ReadInnerMessageNameCore();
			}
			catch (IOException)
			{
				return null;
			}
		}

		string ReadInnerMessageNameCore()
		{
			switch (EMsg)
			{
				case SteamKitten.EMsg.ClientToGC:
				case SteamKitten.EMsg.ClientFromGC:
				{
					var proto = ReadAsProtobufMsg<CMsgGCClient>();
					var gcEMsg = proto.Body.msgtype;
					var gcName = EMsgExtensions.GetGCMessageName(gcEMsg, proto.Body.appid);

					var headerToTrim = "k_EMsg";
					if (gcName.StartsWith(headerToTrim, StringComparison.Ordinal))
					{
						gcName = gcName[ headerToTrim.Length.. ];
					}

					return gcName;
				}

				case SteamKitten.EMsg.ServiceMethod:
				case SteamKitten.EMsg.ServiceMethodSendToClient:
				case SteamKitten.EMsg.ServiceMethodCallFromClient:
				case SteamKitten.EMsg.ServiceMethodCallFromClientNonAuthed:
				case SteamKitten.EMsg.ServiceMethodResponse:
				{
					using var stream = OpenStream();
					var hdr = new MsgHdrProtoBuf();
					hdr.Deserialize(stream);
					return hdr.Proto.target_job_name;
				}

				case SteamKitten.EMsg.ClientServiceMethodLegacy:
				{
					var proto = ReadAsProtobufMsg<CMsgClientServiceMethodLegacy>();
					return proto.Body.method_name;
				}

				case SteamKitten.EMsg.ClientServiceMethodLegacyResponse:
				{
					var proto = ReadAsProtobufMsg<CMsgClientServiceMethodLegacyResponse>();
					return proto.Body.method_name;
				}

				default:
					return string.Empty;

			}
		}

		ClientMsgProtobuf<T> ReadAsProtobufMsg<T>()
			where T : IExtensible, new()
		{
			var fileData = File.ReadAllBytes(FileInfo.FullName);
			var msg = new SteamKitten.PacketClientMsgProtobuf(EMsg, fileData);
			var proto = new ClientMsgProtobuf<T>(msg);
			return proto;
		}

		[GeneratedRegex( @"(?<num>\d+)_(?<direction>in|out)_(?<emsg>\d+)", RegexOptions.IgnoreCase )]
		private static partial Regex NameRegexGenerated();
	}
}
