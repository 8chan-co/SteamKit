// <auto-generated>
//   This file was generated by a tool; you should avoid making direct changes.
//   Consider using 'partial classes' to extend these types
//   Input: steammessages_notifications.steamclient.proto
// </auto-generated>

#region Designer generated code
#pragma warning disable CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
namespace SteamKitten.Internal
{

    [global::ProtoBuf.ProtoContract()]
    public partial class SteamNotificationData : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1)]
        public ulong notification_id
        {
            get => __pbn__notification_id.GetValueOrDefault();
            set => __pbn__notification_id = value;
        }
        public bool ShouldSerializenotification_id() => __pbn__notification_id != null;
        public void Resetnotification_id() => __pbn__notification_id = null;
        private ulong? __pbn__notification_id;

        [global::ProtoBuf.ProtoMember(2)]
        public uint notification_targets
        {
            get => __pbn__notification_targets.GetValueOrDefault();
            set => __pbn__notification_targets = value;
        }
        public bool ShouldSerializenotification_targets() => __pbn__notification_targets != null;
        public void Resetnotification_targets() => __pbn__notification_targets = null;
        private uint? __pbn__notification_targets;

        [global::ProtoBuf.ProtoMember(3)]
        [global::System.ComponentModel.DefaultValue(ESteamNotificationType.k_ESteamNotificationType_Invalid)]
        public ESteamNotificationType notification_type
        {
            get => __pbn__notification_type ?? ESteamNotificationType.k_ESteamNotificationType_Invalid;
            set => __pbn__notification_type = value;
        }
        public bool ShouldSerializenotification_type() => __pbn__notification_type != null;
        public void Resetnotification_type() => __pbn__notification_type = null;
        private ESteamNotificationType? __pbn__notification_type;

        [global::ProtoBuf.ProtoMember(4)]
        [global::System.ComponentModel.DefaultValue("")]
        public string body_data
        {
            get => __pbn__body_data ?? "";
            set => __pbn__body_data = value;
        }
        public bool ShouldSerializebody_data() => __pbn__body_data != null;
        public void Resetbody_data() => __pbn__body_data = null;
        private string __pbn__body_data;

        [global::ProtoBuf.ProtoMember(7)]
        public bool read
        {
            get => __pbn__read.GetValueOrDefault();
            set => __pbn__read = value;
        }
        public bool ShouldSerializeread() => __pbn__read != null;
        public void Resetread() => __pbn__read = null;
        private bool? __pbn__read;

        [global::ProtoBuf.ProtoMember(8)]
        public uint timestamp
        {
            get => __pbn__timestamp.GetValueOrDefault();
            set => __pbn__timestamp = value;
        }
        public bool ShouldSerializetimestamp() => __pbn__timestamp != null;
        public void Resettimestamp() => __pbn__timestamp = null;
        private uint? __pbn__timestamp;

        [global::ProtoBuf.ProtoMember(9)]
        public bool hidden
        {
            get => __pbn__hidden.GetValueOrDefault();
            set => __pbn__hidden = value;
        }
        public bool ShouldSerializehidden() => __pbn__hidden != null;
        public void Resethidden() => __pbn__hidden = null;
        private bool? __pbn__hidden;

        [global::ProtoBuf.ProtoMember(10)]
        public uint expiry
        {
            get => __pbn__expiry.GetValueOrDefault();
            set => __pbn__expiry = value;
        }
        public bool ShouldSerializeexpiry() => __pbn__expiry != null;
        public void Resetexpiry() => __pbn__expiry = null;
        private uint? __pbn__expiry;

        [global::ProtoBuf.ProtoMember(11)]
        public uint viewed
        {
            get => __pbn__viewed.GetValueOrDefault();
            set => __pbn__viewed = value;
        }
        public bool ShouldSerializeviewed() => __pbn__viewed != null;
        public void Resetviewed() => __pbn__viewed = null;
        private uint? __pbn__viewed;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CSteamNotification_NotificationsReceived_Notification : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1)]
        public global::System.Collections.Generic.List<SteamNotificationData> notifications { get; } = new global::System.Collections.Generic.List<SteamNotificationData>();

        [global::ProtoBuf.ProtoMember(2)]
        public uint pending_gift_count
        {
            get => __pbn__pending_gift_count.GetValueOrDefault();
            set => __pbn__pending_gift_count = value;
        }
        public bool ShouldSerializepending_gift_count() => __pbn__pending_gift_count != null;
        public void Resetpending_gift_count() => __pbn__pending_gift_count = null;
        private uint? __pbn__pending_gift_count;

        [global::ProtoBuf.ProtoMember(3)]
        public uint pending_friend_count
        {
            get => __pbn__pending_friend_count.GetValueOrDefault();
            set => __pbn__pending_friend_count = value;
        }
        public bool ShouldSerializepending_friend_count() => __pbn__pending_friend_count != null;
        public void Resetpending_friend_count() => __pbn__pending_friend_count = null;
        private uint? __pbn__pending_friend_count;

        [global::ProtoBuf.ProtoMember(4)]
        public uint pending_family_invite_count
        {
            get => __pbn__pending_family_invite_count.GetValueOrDefault();
            set => __pbn__pending_family_invite_count = value;
        }
        public bool ShouldSerializepending_family_invite_count() => __pbn__pending_family_invite_count != null;
        public void Resetpending_family_invite_count() => __pbn__pending_family_invite_count = null;
        private uint? __pbn__pending_family_invite_count;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class SteamNotificationPreference : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1)]
        [global::System.ComponentModel.DefaultValue(ESteamNotificationType.k_ESteamNotificationType_Invalid)]
        public ESteamNotificationType notification_type
        {
            get => __pbn__notification_type ?? ESteamNotificationType.k_ESteamNotificationType_Invalid;
            set => __pbn__notification_type = value;
        }
        public bool ShouldSerializenotification_type() => __pbn__notification_type != null;
        public void Resetnotification_type() => __pbn__notification_type = null;
        private ESteamNotificationType? __pbn__notification_type;

        [global::ProtoBuf.ProtoMember(2)]
        public uint notification_targets
        {
            get => __pbn__notification_targets.GetValueOrDefault();
            set => __pbn__notification_targets = value;
        }
        public bool ShouldSerializenotification_targets() => __pbn__notification_targets != null;
        public void Resetnotification_targets() => __pbn__notification_targets = null;
        private uint? __pbn__notification_targets;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CSteamNotification_PreferencesUpdated_Notification : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1)]
        public global::System.Collections.Generic.List<SteamNotificationPreference> preferences { get; } = new global::System.Collections.Generic.List<SteamNotificationPreference>();

    }

    [global::ProtoBuf.ProtoContract()]
    public enum ESteamNotificationType
    {
        k_ESteamNotificationType_Invalid = 0,
        k_ESteamNotificationType_Test = 1,
        k_ESteamNotificationType_Gift = 2,
        k_ESteamNotificationType_Comment = 3,
        k_ESteamNotificationType_Item = 4,
        k_ESteamNotificationType_FriendInvite = 5,
        k_ESteamNotificationType_MajorSale = 6,
        k_ESteamNotificationType_PreloadAvailable = 7,
        k_ESteamNotificationType_Wishlist = 8,
        k_ESteamNotificationType_TradeOffer = 9,
        k_ESteamNotificationType_General = 10,
        k_ESteamNotificationType_HelpRequest = 11,
        k_ESteamNotificationType_AsyncGame = 12,
        k_ESteamNotificationType_ChatMsg = 13,
        k_ESteamNotificationType_ModeratorMsg = 14,
        k_ESteamNotificationType_ParentalFeatureAccessRequest = 15,
        k_ESteamNotificationType_FamilyInvite = 16,
        k_ESteamNotificationType_FamilyPurchaseRequest = 17,
        k_ESteamNotificationType_ParentalPlaytimeRequest = 18,
        k_ESteamNotificationType_FamilyPurchaseRequestResponse = 19,
        k_ESteamNotificationType_ParentalFeatureAccessResponse = 20,
        k_ESteamNotificationType_ParentalPlaytimeResponse = 21,
        k_ESteamNotificationType_RequestedGameAdded = 22,
        k_ESteamNotificationType_SendToPhone = 23,
        k_ESteamNotificationType_ClipDownloaded = 24,
        k_ESteamNotificationType_2FAPrompt = 25,
        k_ESteamNotificationType_MobileConfirmation = 26,
        k_ESteamNotificationType_PartnerEvent = 27,
    }

    public class SteamNotificationClient : SteamUnifiedMessages.UnifiedService
    {
        public override string ServiceName { get; } = "SteamNotificationClient";

        public void NotificationsReceived(CSteamNotification_NotificationsReceived_Notification request )
        {
            UnifiedMessages.SendNotification<CSteamNotification_NotificationsReceived_Notification>( "SteamNotificationClient.NotificationsReceived#1", request );
        }

        public void PreferencesUpdated(CSteamNotification_PreferencesUpdated_Notification request )
        {
            UnifiedMessages.SendNotification<CSteamNotification_PreferencesUpdated_Notification>( "SteamNotificationClient.PreferencesUpdated#1", request );
        }

        public override void HandleResponseMsg( string methodName, PacketClientMsgProtobuf packetMsg )
        {
        }

        public override void HandleNotificationMsg( string methodName, PacketClientMsgProtobuf packetMsg )
        {
            switch ( methodName )
            {
                case "NotificationsReceived":
                    PostNotificationMsg<CSteamNotification_NotificationsReceived_Notification>( packetMsg );
                    break;
                case "PreferencesUpdated":
                    PostNotificationMsg<CSteamNotification_PreferencesUpdated_Notification>( packetMsg );
                    break;
            }
        }
    }

}

#pragma warning restore CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
#endregion
