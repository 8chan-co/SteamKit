// <auto-generated>
//   This file was generated by a tool; you should avoid making direct changes.
//   Consider using 'partial classes' to extend these types
//   Input: dota_gcmessages_common_survivors.proto
// </auto-generated>

#region Designer generated code
#pragma warning disable CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
namespace SteamKitten.GC.Dota.Internal
{

    [global::ProtoBuf.ProtoContract()]
    public partial class CMsgSurvivorsUserData : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1)]
        public global::System.Collections.Generic.List<AttributeLevelsEntry> attribute_levels { get; } = new global::System.Collections.Generic.List<AttributeLevelsEntry>();

        [global::ProtoBuf.ProtoMember(2)]
        public uint unlocked_difficulty
        {
            get => __pbn__unlocked_difficulty.GetValueOrDefault();
            set => __pbn__unlocked_difficulty = value;
        }
        public bool ShouldSerializeunlocked_difficulty() => __pbn__unlocked_difficulty != null;
        public void Resetunlocked_difficulty() => __pbn__unlocked_difficulty = null;
        private uint? __pbn__unlocked_difficulty;

        [global::ProtoBuf.ProtoContract()]
        public partial class AttributeLevelsEntry : global::ProtoBuf.IExtensible
        {
            private global::ProtoBuf.IExtension __pbn__extensionData;
            global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
                => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

            [global::ProtoBuf.ProtoMember(1)]
            public int key
            {
                get => __pbn__key.GetValueOrDefault();
                set => __pbn__key = value;
            }
            public bool ShouldSerializekey() => __pbn__key != null;
            public void Resetkey() => __pbn__key = null;
            private int? __pbn__key;

            [global::ProtoBuf.ProtoMember(2)]
            public uint value
            {
                get => __pbn__value.GetValueOrDefault();
                set => __pbn__value = value;
            }
            public bool ShouldSerializevalue() => __pbn__value != null;
            public void Resetvalue() => __pbn__value = null;
            private uint? __pbn__value;

        }

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CMsgClientToGCSurvivorsPowerUpTelemetryData : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1)]
        public uint powerup_id
        {
            get => __pbn__powerup_id.GetValueOrDefault();
            set => __pbn__powerup_id = value;
        }
        public bool ShouldSerializepowerup_id() => __pbn__powerup_id != null;
        public void Resetpowerup_id() => __pbn__powerup_id = null;
        private uint? __pbn__powerup_id;

        [global::ProtoBuf.ProtoMember(2)]
        public uint level
        {
            get => __pbn__level.GetValueOrDefault();
            set => __pbn__level = value;
        }
        public bool ShouldSerializelevel() => __pbn__level != null;
        public void Resetlevel() => __pbn__level = null;
        private uint? __pbn__level;

        [global::ProtoBuf.ProtoMember(3)]
        public uint time_received
        {
            get => __pbn__time_received.GetValueOrDefault();
            set => __pbn__time_received = value;
        }
        public bool ShouldSerializetime_received() => __pbn__time_received != null;
        public void Resettime_received() => __pbn__time_received = null;
        private uint? __pbn__time_received;

        [global::ProtoBuf.ProtoMember(4)]
        public uint time_held
        {
            get => __pbn__time_held.GetValueOrDefault();
            set => __pbn__time_held = value;
        }
        public bool ShouldSerializetime_held() => __pbn__time_held != null;
        public void Resettime_held() => __pbn__time_held = null;
        private uint? __pbn__time_held;

        [global::ProtoBuf.ProtoMember(5)]
        public ulong total_damage
        {
            get => __pbn__total_damage.GetValueOrDefault();
            set => __pbn__total_damage = value;
        }
        public bool ShouldSerializetotal_damage() => __pbn__total_damage != null;
        public void Resettotal_damage() => __pbn__total_damage = null;
        private ulong? __pbn__total_damage;

        [global::ProtoBuf.ProtoMember(6)]
        public uint dps
        {
            get => __pbn__dps.GetValueOrDefault();
            set => __pbn__dps = value;
        }
        public bool ShouldSerializedps() => __pbn__dps != null;
        public void Resetdps() => __pbn__dps = null;
        private uint? __pbn__dps;

        [global::ProtoBuf.ProtoMember(7)]
        public uint has_scepter
        {
            get => __pbn__has_scepter.GetValueOrDefault();
            set => __pbn__has_scepter = value;
        }
        public bool ShouldSerializehas_scepter() => __pbn__has_scepter != null;
        public void Resethas_scepter() => __pbn__has_scepter = null;
        private uint? __pbn__has_scepter;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CMsgClientToGCSurvivorsGameTelemetryData : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1)]
        public uint time_survived
        {
            get => __pbn__time_survived.GetValueOrDefault();
            set => __pbn__time_survived = value;
        }
        public bool ShouldSerializetime_survived() => __pbn__time_survived != null;
        public void Resettime_survived() => __pbn__time_survived = null;
        private uint? __pbn__time_survived;

        [global::ProtoBuf.ProtoMember(2)]
        public uint player_level
        {
            get => __pbn__player_level.GetValueOrDefault();
            set => __pbn__player_level = value;
        }
        public bool ShouldSerializeplayer_level() => __pbn__player_level != null;
        public void Resetplayer_level() => __pbn__player_level = null;
        private uint? __pbn__player_level;

        [global::ProtoBuf.ProtoMember(3)]
        public uint game_result
        {
            get => __pbn__game_result.GetValueOrDefault();
            set => __pbn__game_result = value;
        }
        public bool ShouldSerializegame_result() => __pbn__game_result != null;
        public void Resetgame_result() => __pbn__game_result = null;
        private uint? __pbn__game_result;

        [global::ProtoBuf.ProtoMember(4)]
        public uint gold_earned
        {
            get => __pbn__gold_earned.GetValueOrDefault();
            set => __pbn__gold_earned = value;
        }
        public bool ShouldSerializegold_earned() => __pbn__gold_earned != null;
        public void Resetgold_earned() => __pbn__gold_earned = null;
        private uint? __pbn__gold_earned;

        [global::ProtoBuf.ProtoMember(5)]
        public global::System.Collections.Generic.List<CMsgClientToGCSurvivorsPowerUpTelemetryData> powerups { get; } = new global::System.Collections.Generic.List<CMsgClientToGCSurvivorsPowerUpTelemetryData>();

        [global::ProtoBuf.ProtoMember(6)]
        public uint difficulty
        {
            get => __pbn__difficulty.GetValueOrDefault();
            set => __pbn__difficulty = value;
        }
        public bool ShouldSerializedifficulty() => __pbn__difficulty != null;
        public void Resetdifficulty() => __pbn__difficulty = null;
        private uint? __pbn__difficulty;

        [global::ProtoBuf.ProtoMember(7)]
        public uint metaprogression_level
        {
            get => __pbn__metaprogression_level.GetValueOrDefault();
            set => __pbn__metaprogression_level = value;
        }
        public bool ShouldSerializemetaprogression_level() => __pbn__metaprogression_level != null;
        public void Resetmetaprogression_level() => __pbn__metaprogression_level = null;
        private uint? __pbn__metaprogression_level;

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class CMsgClientToGCSurvivorsGameTelemetryDataResponse : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1)]
        [global::System.ComponentModel.DefaultValue(EResponse.k_eInternalError)]
        public EResponse response
        {
            get => __pbn__response ?? EResponse.k_eInternalError;
            set => __pbn__response = value;
        }
        public bool ShouldSerializeresponse() => __pbn__response != null;
        public void Resetresponse() => __pbn__response = null;
        private EResponse? __pbn__response;

        [global::ProtoBuf.ProtoContract()]
        public enum EResponse
        {
            k_eInternalError = 0,
            k_eSuccess = 1,
            k_eTooBusy = 2,
            k_eDisabled = 3,
            k_eTimeout = 4,
            k_eNotAllowed = 5,
            k_eInvalidItem = 6,
        }

    }

}

#pragma warning restore CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
#endregion
