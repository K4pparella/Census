namespace CensusAPI.Features
{
    using Enums;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.Player.Classes;

    public class Role
    {
        public static Class Get(RoleType type)
        {
            return ClassManager.singleton.classes[(int)type];
        }
    }
}