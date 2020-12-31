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

        public GameObject GameObject => PlayerStats.gameObject;

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
            get => PlayerStats.PlayerName;
            set
            {
                PlayerStats.PlayerName = value;
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

        public float Stamina
        {
            get => PlayerStats.NetworksprintAmount;
            set
            {
                PlayerStats.NetworksprintAmount = value;
            }
        }

        public float MaxStamina
        {
            get => PlayerStats.NetworkmaxSprint;
            set
            {
                PlayerStats.NetworkmaxSprint = value;
            }
        }

        public bool InfiniteRun
        {
            get => PlayerStats.NetworkisInfRun;
            set
            {
                PlayerStats.NetworkisInfRun = value;
            }
        }

        public bool IsStaminaRecovering
        {
            get => PlayerStats.NetworksprintIsRecovering;
            set
            {
                PlayerStats.NetworksprintIsRecovering = value;
            }
        }

        public float StaminaReconveringMultiplier
        {
            get => PlayerStats.NetworkSprintRecoverMultiplier;
            set
            {
                PlayerStats.NetworkSprintRecoverMultiplier = value;
            }
        }

        public float BlinkTimer
        {
            get => PlayerStats.NetworkblinkTimer;
            set
            {
                PlayerStats.NetworksprintAmount = value;
            }
        }

        public float MaxBlinkTimer
        {
            get => PlayerStats.NetworkmaxBlink;
            set
            {
                PlayerStats.NetworkmaxBlink = value;
            }
        }

        public bool IsBlinking
        {
            get => PlayerStats.NetworkisBlinking;
            set
            {
                PlayerStats.NetworkisBlinking = value;
            }
        }

        public bool HasRing
        {
            get => PlayerStats.hasRing;
        }

        public bool IsGodMode
        {
            get => IPlayer.PlayerController.Network_godMode;
            set
            {
                IPlayer.PlayerController.Network_godMode = value;
            }
        }

        public Inventory Inventory => PlayerStats.inv;

        public ItemBase CurrentItem => Inventory.current;
        public ItemBase CurrentWorn => Inventory.currentWorn;

        public int CurrentItemIndex
        {
            get => Inventory.NetworkCurItem;
            set
            {
                Inventory.NetworkCurItem = value;
            }
        }

        public int CurrentWornItemIndex
        {
            get => Inventory.NetworkCurWornItem;
            set
            {
                Inventory.NetworkCurWornItem = value;
            }
        }

        public void RemoveItem(int index)
        {
            Inventory.RemoveItem(index);
        }

        public int CurAmmo
        {
            get => PlayerStats.NetworkcurWeaponAmmo;
            set
            {
                PlayerStats.NetworkcurWeaponAmmo = value;
            }
        }

        public int ReserveAmmo
        {
            get => PlayerStats.NetworkreserveAmmo;
            set
            {
                PlayerStats.NetworkreserveAmmo = value;
            }
        }

        public int CurrentDimension
        {
            get => PlayerStats.CurrentDimension;
            set
            {
                PlayerStats.CurrentDimension = CurrentDimension;
            }
        }

        public bool HasNightVision => PlayerStats.nightVision;
        public bool HasBlueVision => PlayerStats.blueVision;
        public bool HasInfraVision => PlayerStats.infraVision;

        public static Player Get(IPlayer ply)
        {
            return Dictionary[ply];
        }

        public void SendChatMessage(string message)
        {
            IPlayer.SendPlayerChatMessage(message);
        }

        public void Kill()
        {
            IPlayer.KillPlayer();
        }

        public void Kill(PlayerStats.DeathTypes death, GameObject killer)
        {
            PlayerStats.KillPlayer(death, killer);
        }

        public void Cough()
        {
            PlayerStats.Cough();
        }

        public void Hurt(float damage, GameObject damager, PlayerStats.DeathTypes death = PlayerStats.DeathTypes.Unknown)
        {
            PlayerStats.TakeDamage(damage, damager, death);
        }
    }
}