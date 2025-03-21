// <auto-generated>
//   This file was generated by a tool; you should avoid making direct changes.
//   Consider using 'partial classes' to extend these types
//   Input: steammessages_parental_objects.proto
// </auto-generated>

#region Designer generated code
#pragma warning disable CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
namespace SteamKitten.Internal
{

    [global::ProtoBuf.ProtoContract()]
    public partial class ParentalApp : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1)]
        public uint appid
        {
            get => __pbn__appid.GetValueOrDefault();
            set => __pbn__appid = value;
        }
        public bool ShouldSerializeappid() => __pbn__appid != null;
        public void Resetappid() => __pbn__appid = null;
        private uint? __pbn__appid;

        [global::ProtoBuf.ProtoMember(2)]
        public bool is_allowed
        {
            get => __pbn__is_allowed.GetValueOrDefault();
            set => __pbn__is_allowed = value;
        }
        public bool ShouldSerializeis_allowed() => __pbn__is_allowed != null;
        public void Resetis_allowed() => __pbn__is_allowed = null;
        private bool? __pbn__is_allowed;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class ParentalPlaytimeDay : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1)]
        public ulong allowed_time_windows
        {
            get => __pbn__allowed_time_windows.GetValueOrDefault();
            set => __pbn__allowed_time_windows = value;
        }
        public bool ShouldSerializeallowed_time_windows() => __pbn__allowed_time_windows != null;
        public void Resetallowed_time_windows() => __pbn__allowed_time_windows = null;
        private ulong? __pbn__allowed_time_windows;

        [global::ProtoBuf.ProtoMember(2)]
        public uint allowed_daily_minutes
        {
            get => __pbn__allowed_daily_minutes.GetValueOrDefault();
            set => __pbn__allowed_daily_minutes = value;
        }
        public bool ShouldSerializeallowed_daily_minutes() => __pbn__allowed_daily_minutes != null;
        public void Resetallowed_daily_minutes() => __pbn__allowed_daily_minutes = null;
        private uint? __pbn__allowed_daily_minutes;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class ParentalPlaytimeRestrictions : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(2)]
        public bool apply_playtime_restrictions
        {
            get => __pbn__apply_playtime_restrictions.GetValueOrDefault();
            set => __pbn__apply_playtime_restrictions = value;
        }
        public bool ShouldSerializeapply_playtime_restrictions() => __pbn__apply_playtime_restrictions != null;
        public void Resetapply_playtime_restrictions() => __pbn__apply_playtime_restrictions = null;
        private bool? __pbn__apply_playtime_restrictions;

        [global::ProtoBuf.ProtoMember(15)]
        public global::System.Collections.Generic.List<ParentalPlaytimeDay> playtime_days { get; } = new global::System.Collections.Generic.List<ParentalPlaytimeDay>();

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class ParentalTemporaryPlaytimeRestrictions : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1)]
        public ParentalPlaytimeDay restrictions { get; set; }

        [global::ProtoBuf.ProtoMember(2)]
        public uint rtime_expires
        {
            get => __pbn__rtime_expires.GetValueOrDefault();
            set => __pbn__rtime_expires = value;
        }
        public bool ShouldSerializertime_expires() => __pbn__rtime_expires != null;
        public void Resetrtime_expires() => __pbn__rtime_expires = null;
        private uint? __pbn__rtime_expires;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class ParentalSettings : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong steamid
        {
            get => __pbn__steamid.GetValueOrDefault();
            set => __pbn__steamid = value;
        }
        public bool ShouldSerializesteamid() => __pbn__steamid != null;
        public void Resetsteamid() => __pbn__steamid = null;
        private ulong? __pbn__steamid;

        [global::ProtoBuf.ProtoMember(2)]
        public uint applist_base_id
        {
            get => __pbn__applist_base_id.GetValueOrDefault();
            set => __pbn__applist_base_id = value;
        }
        public bool ShouldSerializeapplist_base_id() => __pbn__applist_base_id != null;
        public void Resetapplist_base_id() => __pbn__applist_base_id = null;
        private uint? __pbn__applist_base_id;

        [global::ProtoBuf.ProtoMember(3)]
        [global::System.ComponentModel.DefaultValue("")]
        public string applist_base_description
        {
            get => __pbn__applist_base_description ?? "";
            set => __pbn__applist_base_description = value;
        }
        public bool ShouldSerializeapplist_base_description() => __pbn__applist_base_description != null;
        public void Resetapplist_base_description() => __pbn__applist_base_description = null;
        private string __pbn__applist_base_description;

        [global::ProtoBuf.ProtoMember(4)]
        public global::System.Collections.Generic.List<ParentalApp> applist_base { get; } = new global::System.Collections.Generic.List<ParentalApp>();

        [global::ProtoBuf.ProtoMember(5)]
        public global::System.Collections.Generic.List<ParentalApp> applist_custom { get; } = new global::System.Collections.Generic.List<ParentalApp>();

        [global::ProtoBuf.ProtoMember(6)]
        public uint passwordhashtype
        {
            get => __pbn__passwordhashtype.GetValueOrDefault();
            set => __pbn__passwordhashtype = value;
        }
        public bool ShouldSerializepasswordhashtype() => __pbn__passwordhashtype != null;
        public void Resetpasswordhashtype() => __pbn__passwordhashtype = null;
        private uint? __pbn__passwordhashtype;

        [global::ProtoBuf.ProtoMember(7)]
        public byte[] salt
        {
            get => __pbn__salt;
            set => __pbn__salt = value;
        }
        public bool ShouldSerializesalt() => __pbn__salt != null;
        public void Resetsalt() => __pbn__salt = null;
        private byte[] __pbn__salt;

        [global::ProtoBuf.ProtoMember(8)]
        public byte[] passwordhash
        {
            get => __pbn__passwordhash;
            set => __pbn__passwordhash = value;
        }
        public bool ShouldSerializepasswordhash() => __pbn__passwordhash != null;
        public void Resetpasswordhash() => __pbn__passwordhash = null;
        private byte[] __pbn__passwordhash;

        [global::ProtoBuf.ProtoMember(9)]
        public bool is_enabled
        {
            get => __pbn__is_enabled.GetValueOrDefault();
            set => __pbn__is_enabled = value;
        }
        public bool ShouldSerializeis_enabled() => __pbn__is_enabled != null;
        public void Resetis_enabled() => __pbn__is_enabled = null;
        private bool? __pbn__is_enabled;

        [global::ProtoBuf.ProtoMember(10)]
        public uint enabled_features
        {
            get => __pbn__enabled_features.GetValueOrDefault();
            set => __pbn__enabled_features = value;
        }
        public bool ShouldSerializeenabled_features() => __pbn__enabled_features != null;
        public void Resetenabled_features() => __pbn__enabled_features = null;
        private uint? __pbn__enabled_features;

        [global::ProtoBuf.ProtoMember(11)]
        [global::System.ComponentModel.DefaultValue("")]
        public string recovery_email
        {
            get => __pbn__recovery_email ?? "";
            set => __pbn__recovery_email = value;
        }
        public bool ShouldSerializerecovery_email() => __pbn__recovery_email != null;
        public void Resetrecovery_email() => __pbn__recovery_email = null;
        private string __pbn__recovery_email;

        [global::ProtoBuf.ProtoMember(12)]
        public bool is_site_license_lock
        {
            get => __pbn__is_site_license_lock.GetValueOrDefault();
            set => __pbn__is_site_license_lock = value;
        }
        public bool ShouldSerializeis_site_license_lock() => __pbn__is_site_license_lock != null;
        public void Resetis_site_license_lock() => __pbn__is_site_license_lock = null;
        private bool? __pbn__is_site_license_lock;

        [global::ProtoBuf.ProtoMember(13)]
        public uint temporary_enabled_features
        {
            get => __pbn__temporary_enabled_features.GetValueOrDefault();
            set => __pbn__temporary_enabled_features = value;
        }
        public bool ShouldSerializetemporary_enabled_features() => __pbn__temporary_enabled_features != null;
        public void Resettemporary_enabled_features() => __pbn__temporary_enabled_features = null;
        private uint? __pbn__temporary_enabled_features;

        [global::ProtoBuf.ProtoMember(14)]
        public uint rtime_temporary_feature_expiration
        {
            get => __pbn__rtime_temporary_feature_expiration.GetValueOrDefault();
            set => __pbn__rtime_temporary_feature_expiration = value;
        }
        public bool ShouldSerializertime_temporary_feature_expiration() => __pbn__rtime_temporary_feature_expiration != null;
        public void Resetrtime_temporary_feature_expiration() => __pbn__rtime_temporary_feature_expiration = null;
        private uint? __pbn__rtime_temporary_feature_expiration;

        [global::ProtoBuf.ProtoMember(15)]
        public ParentalPlaytimeRestrictions playtime_restrictions { get; set; }

        [global::ProtoBuf.ProtoMember(16)]
        public ParentalTemporaryPlaytimeRestrictions temporary_playtime_restrictions { get; set; }

        [global::ProtoBuf.ProtoMember(17)]
        public global::System.Collections.Generic.List<uint> excluded_store_content_descriptors { get; } = new global::System.Collections.Generic.List<uint>();

        [global::ProtoBuf.ProtoMember(18)]
        public global::System.Collections.Generic.List<uint> excluded_community_content_descriptors { get; } = new global::System.Collections.Generic.List<uint>();

        [global::ProtoBuf.ProtoMember(19)]
        public global::System.Collections.Generic.List<uint> utility_appids { get; } = new global::System.Collections.Generic.List<uint>();

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class ParentalFeatureRequest : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong requestid
        {
            get => __pbn__requestid.GetValueOrDefault();
            set => __pbn__requestid = value;
        }
        public bool ShouldSerializerequestid() => __pbn__requestid != null;
        public void Resetrequestid() => __pbn__requestid = null;
        private ulong? __pbn__requestid;

        [global::ProtoBuf.ProtoMember(2, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong family_groupid
        {
            get => __pbn__family_groupid.GetValueOrDefault();
            set => __pbn__family_groupid = value;
        }
        public bool ShouldSerializefamily_groupid() => __pbn__family_groupid != null;
        public void Resetfamily_groupid() => __pbn__family_groupid = null;
        private ulong? __pbn__family_groupid;

        [global::ProtoBuf.ProtoMember(3, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong steamid
        {
            get => __pbn__steamid.GetValueOrDefault();
            set => __pbn__steamid = value;
        }
        public bool ShouldSerializesteamid() => __pbn__steamid != null;
        public void Resetsteamid() => __pbn__steamid = null;
        private ulong? __pbn__steamid;

        [global::ProtoBuf.ProtoMember(4)]
        public uint features
        {
            get => __pbn__features.GetValueOrDefault();
            set => __pbn__features = value;
        }
        public bool ShouldSerializefeatures() => __pbn__features != null;
        public void Resetfeatures() => __pbn__features = null;
        private uint? __pbn__features;

        [global::ProtoBuf.ProtoMember(5)]
        public uint time_requested
        {
            get => __pbn__time_requested.GetValueOrDefault();
            set => __pbn__time_requested = value;
        }
        public bool ShouldSerializetime_requested() => __pbn__time_requested != null;
        public void Resettime_requested() => __pbn__time_requested = null;
        private uint? __pbn__time_requested;

        [global::ProtoBuf.ProtoMember(6)]
        public bool approved
        {
            get => __pbn__approved.GetValueOrDefault();
            set => __pbn__approved = value;
        }
        public bool ShouldSerializeapproved() => __pbn__approved != null;
        public void Resetapproved() => __pbn__approved = null;
        private bool? __pbn__approved;

        [global::ProtoBuf.ProtoMember(7, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong steamid_responder
        {
            get => __pbn__steamid_responder.GetValueOrDefault();
            set => __pbn__steamid_responder = value;
        }
        public bool ShouldSerializesteamid_responder() => __pbn__steamid_responder != null;
        public void Resetsteamid_responder() => __pbn__steamid_responder = null;
        private ulong? __pbn__steamid_responder;

        [global::ProtoBuf.ProtoMember(8)]
        public uint time_responded
        {
            get => __pbn__time_responded.GetValueOrDefault();
            set => __pbn__time_responded = value;
        }
        public bool ShouldSerializetime_responded() => __pbn__time_responded != null;
        public void Resettime_responded() => __pbn__time_responded = null;
        private uint? __pbn__time_responded;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class ParentalPlaytimeRequest : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong requestid
        {
            get => __pbn__requestid.GetValueOrDefault();
            set => __pbn__requestid = value;
        }
        public bool ShouldSerializerequestid() => __pbn__requestid != null;
        public void Resetrequestid() => __pbn__requestid = null;
        private ulong? __pbn__requestid;

        [global::ProtoBuf.ProtoMember(2, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong family_groupid
        {
            get => __pbn__family_groupid.GetValueOrDefault();
            set => __pbn__family_groupid = value;
        }
        public bool ShouldSerializefamily_groupid() => __pbn__family_groupid != null;
        public void Resetfamily_groupid() => __pbn__family_groupid = null;
        private ulong? __pbn__family_groupid;

        [global::ProtoBuf.ProtoMember(3, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong steamid
        {
            get => __pbn__steamid.GetValueOrDefault();
            set => __pbn__steamid = value;
        }
        public bool ShouldSerializesteamid() => __pbn__steamid != null;
        public void Resetsteamid() => __pbn__steamid = null;
        private ulong? __pbn__steamid;

        [global::ProtoBuf.ProtoMember(4)]
        public ParentalPlaytimeDay current_playtime_restrictions { get; set; }

        [global::ProtoBuf.ProtoMember(5)]
        public uint time_expires
        {
            get => __pbn__time_expires.GetValueOrDefault();
            set => __pbn__time_expires = value;
        }
        public bool ShouldSerializetime_expires() => __pbn__time_expires != null;
        public void Resettime_expires() => __pbn__time_expires = null;
        private uint? __pbn__time_expires;

        [global::ProtoBuf.ProtoMember(6)]
        public uint time_requested
        {
            get => __pbn__time_requested.GetValueOrDefault();
            set => __pbn__time_requested = value;
        }
        public bool ShouldSerializetime_requested() => __pbn__time_requested != null;
        public void Resettime_requested() => __pbn__time_requested = null;
        private uint? __pbn__time_requested;

        [global::ProtoBuf.ProtoMember(7)]
        public bool approved
        {
            get => __pbn__approved.GetValueOrDefault();
            set => __pbn__approved = value;
        }
        public bool ShouldSerializeapproved() => __pbn__approved != null;
        public void Resetapproved() => __pbn__approved = null;
        private bool? __pbn__approved;

        [global::ProtoBuf.ProtoMember(8, DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
        public ulong steamid_responder
        {
            get => __pbn__steamid_responder.GetValueOrDefault();
            set => __pbn__steamid_responder = value;
        }
        public bool ShouldSerializesteamid_responder() => __pbn__steamid_responder != null;
        public void Resetsteamid_responder() => __pbn__steamid_responder = null;
        private ulong? __pbn__steamid_responder;

        [global::ProtoBuf.ProtoMember(9)]
        public uint time_responded
        {
            get => __pbn__time_responded.GetValueOrDefault();
            set => __pbn__time_responded = value;
        }
        public bool ShouldSerializetime_responded() => __pbn__time_responded != null;
        public void Resettime_responded() => __pbn__time_responded = null;
        private uint? __pbn__time_responded;

        [global::ProtoBuf.ProtoMember(10)]
        public ParentalTemporaryPlaytimeRestrictions restrictions_approved { get; set; }

    }

}

#pragma warning restore CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
#endregion
