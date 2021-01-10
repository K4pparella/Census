namespace CensusCore.Events.EventArgs.Player
{
    using CensusAPI.Features;
    using VirtualBrightPlayz.SCP_ET.NPCs.SCP;
    using VirtualBrightPlayz.SCP_ET.Player;

    public class EnteringPocketDimensionEventArgs
    {
        public EnteringPocketDimensionEventArgs(PlayerController ctrl, SCP106 scp)
        {
            Player = Player.Get(ctrl);
            IsAllowed = true;
            Scp106 = scp;
        }

        public Player Player { get; }
        public SCP106 Scp106 { get; }
        public bool IsAllowed { get; set; }
    }
}