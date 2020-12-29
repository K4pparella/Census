namespace CensusAPI.Features
{
    using Enums;
    using PluginFramework.Classes;
    using System.Collections.Generic;
    using UnityEngine;
    using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.Player.Classes;

    public class Player
    {
        public static IEnumerable<Player> List => Dictionary.Values;
        public static Dictionary<IPlayer, Player> Dictionary { get; } = new Dictionary<IPlayer, Player>();

        public Player(IPlayer inst)
        {
            IPlayer = inst;
        }

        public IPlayer IPlayer { get; }

        public Vector3 Position
        {
            get => IPlayer.PlayerController.Position;
            set
            {
                IPlayer.PlayerController.Position = value;
            }
        }

        public Quaternion BaseRotation => IPlayer.PlayerController.BaseRotation;

        public float HeadRotation => IPlayer.PlayerController.HeadRotation;

        public string Nickname
        {
            get => IPlayer.PlayerController.NetworkplayerName;
            set
            {
                IPlayer.PlayerController.NetworkplayerName = value;
            }
        }

        public RoleType ClassId
        {
            get => (RoleType)PlayerStats.NetworkClassId;
            set
            {
                PlayerStats.NetworkClassId = (int)value;
            }
        }

        public Class Class => Role.Get(ClassId);

        public PlayerStats PlayerStats => IPlayer.PlayerController.stats;

        public float MaxHealth
        {
            get => PlayerStats.NetworkMaxHealth;
            set
            {
                PlayerStats.NetworkMaxHealth = value;
            }
        }

        public float Health
        {
            get => IPlayer.PlayerController.healthController.NetworkHealth;
            set
            {
                IPlayer.PlayerController.healthController.NetworkHealth = value;
            }
        }

        public Inventory Inventory => PlayerStats.inv;

        public static Player Get(IPlayer ply)
        {
            return Dictionary[ply];
        }

        public void SendChatMessage(string message)
        {
            IPlayer.SendPlayerChatMessage(message);
        }
    }
}