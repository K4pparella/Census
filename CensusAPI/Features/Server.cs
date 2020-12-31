namespace CensusAPI.Features
{
    using Assets.MirrorEXT;
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

        public static string MapName => CustomNetworkManager.mapName;
        public static int MaxPlayers => CustomNetworkManager.manager.server.MaxConnections;
        public static bool IsPublic => CustomNetworkManager.publicServer;
        public static bool IsDedicated => CustomNetworkManager.isDedicated;

        public static GameSettings.JsonServerSettings ServerSettings => GameSettings.serverSettings;

        public static void SendChatMessage(string message)
        {
            foreach(Player p in Player.List)
            {
                p.SendChatMessage(message);
            }
        }


    }
}