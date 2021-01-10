namespace CensusCore.Events.EventArgs.Player
{
    using CensusAPI.Features;
    using VirtualBrightPlayz.SCP_ET.NPCs.SCP;
    using VirtualBrightPlayz.SCP_ET.Player;
    public class FailingToEscapePocketDimensionEventArgs
    {
        public FailingToEscapePocketDimensionEventArgs(PlayerController ctrl)
        {
            Player = Player.Get(ctrl);
            IsAllowed = true;
        }

        public Player Player { get; }
        public bool IsAllowed { get; set; }
    }
}
