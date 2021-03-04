﻿namespace CensusAPI.Features
{
    using Assets.Scripts;
    using System.Collections.Generic;
    using Assets.MirrorEXT;
    using PluginFramework.Events;
    using VirtualBrightPlayz.SCP_ET;
    using VirtualBrightPlayz.SCP_ET.ServerConsole;
    using VirtualBrightPlayz.SCP_ET.Misc;
    using VirtualBrightPlayz.SCP_ET.Player;

    public class Server
    {
        public static string Title
        {
            get => PlayerList.List.Networktitle;
            set
            {
                PlayerList.List.Networktitle = value;
            }
        }

        public static int Gamemode
        {
            get => PlayerList.List.NetworkgameModeId;
            set
            {
                PlayerList.List.NetworkgameModeId = value;
            }
        }

        private static RoundEnd __roundEnd_instance;

        private static RoundEnd RoundEnd
        {
            get
            {
                if (__roundEnd_instance == null)
                {
                    __roundEnd_instance = UnityEngine.Object.FindObjectOfType<RoundEnd>();
                }
                return __roundEnd_instance;
            }
        }

        public static string MapName => CustomNetworkManager.mapName;
        public static int MaxPlayers => CustomNetworkManager.manager.maxPlayers;
        public static bool IsPublic => CustomNetworkManager.publicServer;
        public static bool IsDedicated => CustomNetworkManager.isDedicated;

        public static GameSettings.JsonServerSettings ServerSettings => GameSettings.serverSettings;

        public static bool IsRoundStarted
        {
            get => __roundEnd_instance.starter.NetworkisRoundstarted;
            set
            {
                __roundEnd_instance.starter.NetworkisRoundstarted = value;
            }
        }

        public static void SendChatMessage(string message)
        {
            TcpConsole.chatqueue.Enqueue(message);
        }

        public static void EndRound(string message, float delay = 15f)
        {
            int num = 0;
            foreach (KeyValuePair<PlayerController,PlayerListElement> element in PlayerList.List.players)
            {
                if (element.Key != null && element.Value != null)
                {
                    if (element.Key.ClassId != 0)
                    {
                        num++;
                    }
                }
            }
            RoundEnd.EndRound(message, delay);
            WorldEvents.InvokeRoundEnd(num, false);
        }
    }
}