﻿using System.Windows.Forms;
using System.Linq;
using System;
using SteamKitten;

namespace NetHookAnalyzer2
{
	static class NetHookItemTreeBuilder
	{
		public static TreeNode BuildTree(NetHookItem item, ISpecialization[] specializations, bool displayUnsetFields)
		{
			try
			{
				return CreateTreeNodeCore(item, specializations, displayUnsetFields);
			}
			catch (Exception ex)
			{
				return new TreeNode($"{ex.GetType().Name} encountered whilst parsing item: {ex.Message}");
			}
		}

		static TreeNode CreateTreeNodeCore(NetHookItem item, ISpecialization[] specializations, bool displayUnsetFields)
		{
			var configuration = new TreeNodeObjectExplorerConfiguration { ShowUnsetFields = displayUnsetFields };

			var (rawEMsg, header, body, payload) = item.ReadFile();

			var node = new TreeNode(EMsgToStringName(rawEMsg));
			node.Expand();

			node.Nodes.Add(new TreeNodeObjectExplorer("Header", header, configuration));

			var bodyNode = new TreeNodeObjectExplorer("Body", body, configuration);
			node.Nodes.Add(bodyNode);

			if (payload != null && payload.Length > 0)
			{
				node.Nodes.Add(new TreeNodeObjectExplorer("Payload", payload, configuration));
			}

			if (specializations != null)
			{
				var objectsToSpecialize = new[] { body };
				while ( objectsToSpecialize.Length > 0 )
				{
					var extraSpecializations = objectsToSpecialize.SelectMany( o => specializations.SelectMany( x => x.ReadExtraObjects( o ) ) ).ToArray();

					if (extraSpecializations.Length == 0 )
					{
						break;
					}

					bodyNode.Collapse(ignoreChildren: true);

					var extraNodes = extraSpecializations.Select(x => new TreeNodeObjectExplorer(x.Key, x.Value, configuration)).ToArray();
					node.Nodes.AddRange(extraNodes);

					// Let the specializers examine any new message objects.
					objectsToSpecialize = extraSpecializations.Select(x => x.Value).ToArray();
				}
			}

			return node;
		}

		internal static string EMsgToStringName(uint rawEMsg)
		{
			var eMsg = MsgUtil.GetMsg( rawEMsg );
			var eMsgName = $"EMsg {eMsg:G} ({eMsg:D})";

			if( MsgUtil.IsProtoBuf( rawEMsg ) )
			{
				return eMsgName;
			}

			return $"{eMsgName} (Non-Protobuf)";
		}
	}
}
