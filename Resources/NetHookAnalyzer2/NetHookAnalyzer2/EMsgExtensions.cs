﻿using System;
using System.Collections.Generic;
using System.Globalization;
using SteamKitten;

using CSGO = SteamKitten.GC.CSGO.Internal;
using Dota = SteamKitten.GC.Dota.Internal;
using TF2 = SteamKitten.GC.TF2.Internal;

namespace NetHookAnalyzer2
{
	static class EMsgExtensions
	{
		public static string GetGCMessageName(uint eMsg, uint appId)
		{
			eMsg = MsgUtil.GetGCMsg( eMsg );

			var eMsgEnums = GetGCEMsgEnums(appId);

			foreach ( var enumType in eMsgEnums )
			{
				if ( Enum.IsDefined( enumType, ( int )eMsg ) )
					return Enum.GetName( enumType, ( int )eMsg );
			}

			return eMsg.ToString( CultureInfo.InvariantCulture );
		}

		static IEnumerable<Type> GetGCEMsgEnums(uint appId)
		{
			switch (appId)
			{
				case WellKnownAppIDs.TeamFortress2:
					yield return typeof(TF2.ETFGCMsg);
					yield return typeof(TF2.EGCBaseMsg);
					yield return typeof(TF2.ESOMsg);
					yield return typeof(TF2.EGCSystemMsg);
					yield return typeof(TF2.EGCItemMsg);
					yield return typeof(TF2.EGCBaseClientMsg);
					break;

				case WellKnownAppIDs.Dota2:
					yield return typeof(Dota.EDOTAGCMsg);
					yield return typeof(Dota.EGCBaseMsg);
					yield return typeof(Dota.ESOMsg);
					yield return typeof(Dota.EGCItemMsg);
					yield return typeof(Dota.EGCBaseClientMsg);
					break;

				case WellKnownAppIDs.CounterStrike2:
					yield return typeof(CSGO.ECsgoGCMsg);
					yield return typeof(CSGO.EGCBaseMsg);
					yield return typeof(CSGO.ESOMsg);
					yield return typeof(CSGO.EGCSystemMsg);
					yield return typeof(CSGO.EGCItemMsg);
					yield return typeof(CSGO.EGCBaseClientMsg);
					break;
            }
		}
	}
}
