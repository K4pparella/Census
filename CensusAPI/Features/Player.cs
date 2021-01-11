namespace CensusAPI.Features
{
    using Enums;
    using Mirror;
    using PluginFramework.Classes;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using VirtualBrightPlayz.SCP_ET;
    using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.Player.Classes;
    using VirtualBrightPlayz.SCP_ET.Player.Effects;
    using VirtualBrightPlayz.SCP_ET.ServerGroups;
    using VirtualBrightPlayz.SCP_ET.NPCs.Interfaces;

    public class Player
    {
        public static IEnumerable<Player> List => Dictionary.Values;
        public static Dictionary<IPlayer, Player> Dictionary { get; } = new Dictionary<IPlayer, Player>();

        public Player(IPlayer inst)
        {
            IPlayer = inst;
        }

        public Player(PlayerController inst)
        {
            IPlayer = inst.stats;
        }

        public IPlayer IPlayer { get; }

        public INetworkConnection Connection => IPlayer.PlayerController.ConnectionToClient;

        public GameObject GameObject => PlayerStats.gameObject;

        public Vector3 Position
        {
            get => IPlayer.PlayerController.Position;
            set
            {
                IPlayer.PlayerController.Position = value;
            }
        }

        public Quaternion BaseRotation
        {
            get => IPlayer.PlayerController.BaseRotation;
            set
            {
                IPlayer.PlayerController.BaseRotation = value;
            }
        }

        public float HeadRotation
        {
            get => IPlayer.PlayerController.HeadRotation;
            set
            {
                IPlayer.PlayerController.HeadRotation = value;
            }
        }

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

        public string SteamID
        {
            get => Connection.AuthenticationData.ToString();
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
            get => PlayerStats.isInfRun;
            set
            {
                PlayerStats.isInfRun = value;
            }
        }

        public bool IsStaminaRecovering
        {
            get => PlayerStats.sprintIsRecovering;
            set
            {
                PlayerStats.sprintIsRecovering = value;
            }
        }

        public float StaminaRecoveringMultiplier
        {
            get => PlayerStats.SprintRecoverMultiplier;
            set
            {
                PlayerStats.SprintRecoverMultiplier = value;
            }
        }

        public float SprintSpeed
        {
            get => IPlayer.PlayerController.NetworksprintSpeed;
            set
            {
                IPlayer.PlayerController.NetworksprintSpeed = value;
            }
        }

        public float WalkSpeed
        {
            get => IPlayer.PlayerController.NetworkwalkSpeed;
            set
            {
                IPlayer.PlayerController.NetworkwalkSpeed = value;
            }
        }

        public float Gravity
        {
            get => IPlayer.PlayerController.Networkgravity;
            set
            {
                IPlayer.PlayerController.Networkgravity = value;
            }
        }

        public float JumpHeight
        {
            get => IPlayer.PlayerController.NetworkjumpHeight;
            set
            {
                IPlayer.PlayerController.NetworkjumpHeight = value;
            }
        }

        public float CrouchSpeed
        {
            get => IPlayer.PlayerController.NetworkcrouchSpeed;
            set
            {
                IPlayer.PlayerController.NetworkcrouchSpeed = value;
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

        public bool GodModeEnabled
        {
            get => IPlayer.PlayerController.Network_godMode;
            set
            {
                IPlayer.PlayerController.Network_godMode = value;
            }
        }

        public bool NoclipEnabled
        {
            get => IPlayer.PlayerController.NetworkisFly;
            set
            {
                IPlayer.PlayerController.NetworkisFly = value;
            }
        }

        public bool NotargetEnabled
        {
            get => IPlayer.PlayerController.NetworknoTarget;
            set
            {
                IPlayer.PlayerController.NetworknoTarget = value;
            }
        }

        public bool ThirdpersonEnabled
        {
            get => IPlayer.PlayerController.NetworkthirdPerson;
            set
            {
                IPlayer.PlayerController.NetworkthirdPerson = value;
            }
        }

        public bool NoSeeEnabled
        {
            get => IPlayer.PlayerController.NetworknoSee;
            set
            {
                IPlayer.PlayerController.NetworknoSee = value;
            }
        }

        public bool InfiniteAmmoEnabled
        {
            get => IPlayer.PlayerController.infAmmo;
            set
            {
                IPlayer.PlayerController.infAmmo = value;
            }
        }

        public string Group
        {
            get => IPlayer.PlayerController.NetworkplayerGroup;
            set
            {
                IPlayer.PlayerController.NetworkplayerGroup = value;
            }
        }

        public float IsMakingSound => IPlayer.PlayerController.IsMakingSound;

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

        public DimensionType CurrentDimension
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

        public string Skin
        {
            get => PlayerStats.NetworkplayerTextureIndex;
            set
            {
                PlayerStats.NetworkplayerTextureIndex = value;
            }
        }

        public PlayerMissionManager MissionManager
        {
            get => PlayerStats.playerMissionManager;
        }

        public bool IsMuted
        {
            get => IPlayer.PlayerController.voiceChatScript.NetworkisServerMuted;
            set
            {
                IPlayer.PlayerController.voiceChatScript.NetworkisServerMuted = true;
            }
        }

        public bool IsSprinting
        {
            get => IPlayer.PlayerController.movementController.NetworksyncIsSprinting;
            set
            {
                IPlayer.PlayerController.movementController.NetworksyncIsSprinting = value;
            }
        }

        public bool IsJumping
        {
            get => IPlayer.PlayerController.movementController.NetworksyncIsJump;
            set
            {
                IPlayer.PlayerController.movementController.NetworksyncIsJump = value;
            }
        }

        public bool IsDucking
        {
            get => IPlayer.PlayerController.movementController.NetworksyncIsDucking;
            set
            {
                IPlayer.PlayerController.movementController.NetworksyncIsDucking = value;
            }
        }

        public int AddMission(string name, bool completed = false)
        {
            MissionManager.AddMissionServer(new MissionInfo()
            {
                MissionName = name,
            }, completed);
            return MissionManager.GetIndex(name);
        }

        public void RemoveMission(int index)
        {
            MissionManager.RemoveMissionServer(index);
        }

        public static Player Get(IPlayer ply)
        {
            if (ply == null)
            {
                return null;
            }
            return Dictionary.ContainsKey(ply) ? Dictionary[ply] : null;
        }

        public static Player Get(PlayerController ply)
        {
            if (ply == null)
            {
                return null;
            }
            return Get(ply.stats);
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

        public void ShowStatus(string status)
        {
            IPlayer.PlayerController.ShowStatus(status);
        }

        public void Blink()
        {
            IPlayer.PlayerController.CmdBlink();
        }

        public void UnBlink()
        {
            IPlayer.PlayerController.CmdUnBlink();
        }

        public void Disconnect(string message)
        {
            IPlayer.PlayerController.Disconnect(message);
        }

        public void Ban(string reason, TimeSpan duration)
        {
            BanHandler.singleton.Addban(IPlayer.PlayerController.ConnectionToClient, "", duration);
            Disconnect($"You have been banned from this server: {reason}");
        }

        public void Mute(string reason, TimeSpan duration)
        {
            IsMuted = true;
            MuteHandler.singleton.AddMute(IPlayer.PlayerController.ConnectionToClient, reason, duration);
            if (duration == TimeSpan.MaxValue)
            {
                SendChatMessage($"<color=red>You have been server muted: {reason}</color>");
            }
            else
            {
                SendChatMessage(string.Format("<color=red>You have been server muted\nDuration: {0} Days {1} Hours {2} Minutes\nReason: {3}</color>", new object[]
                {
                    duration.Days,
                    duration.TotalHours,
                    duration.TotalMinutes,
                    string.Join(" ", reason)
                }));
            }
        }

        public void Unmute()
        {
            if (MuteHandler.singleton.GetMute(IPlayer.PlayerController.ConnectionToClient) != null)
            {
                IsMuted = false;
                if (IPlayer.PlayerController.ConnectionToClient.AuthenticationData == null)
                {
                    MuteHandler.singleton.RemoveMute("", IPlayer.PlayerController.ConnectionToClient.Address.ToString());
                }
                else
                {
                    MuteHandler.singleton.RemoveMute(IPlayer.PlayerController.ConnectionToClient.AuthenticationData.ToString(), IPlayer.PlayerController.ConnectionToClient.Address.ToString());
                }
                SendChatMessage("<color=red>You have been server unmuted</color>");
            }
        }

        public void DropAll()
        {
            IPlayer.PlayerController.DropAllInv();
        }

        public bool CheckPermission(string perm)
        {
            return ServerGroups.CheckPermission(IPlayer.PlayerController.ConnectionToClient, perm);
        }

        public void AddEffect(IEffect effect)
        {
            PlayerStats.effectsHP.AddEffect(effect);
        }

        public bool HasEffect(string effect)
        {
            return PlayerStats.effectsHP.HasEffect(effect);
        }

        public void RemoveEffect(string effect)
        {
            PlayerStats.effectsHP.RemoveEffect(effect);
        }

        public void RemoveAllEffects()
        {
            PlayerStats.effectsHP.RemoveAllEffects();
        }

        public void ExecuteChatCommand(string command)
        {
            string[] array = command.Split(new char[]
            {
                ' '
            });
            if (TextChat.commands.ContainsKey(array[0].ToLower()))
            {
                string text;
                TextChat.commands[array[0].ToLower()].Invoke(IPlayer.PlayerController, array, out text);
                SendChatMessage(text);
            }
        }

        public void ExecuteAdminCommand(string command)
        {
            IPlayer.PlayerController.adminmenuScript.CmdAdminCommand(command);
        }
    }
}