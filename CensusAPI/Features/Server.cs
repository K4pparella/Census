namespace CensusAPI.Features
{
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.Misc;
    public class Server
    {
        public static string Title{
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

        public static GameSettings.JsonServerSettings ServerSettings => GameSettings.serverSettings; 

    }
}
