namespace CensusAPI.Features
{
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.Player.Classes;
    using Enums;
    public class Role
    {
        public static Class Get(RoleType type)
        {
            return ClassManager.singleton.classes[(int)type];
        }
    }
}
