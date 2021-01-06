namespace CensusCore.Events.EventArgs.Player
{
    using CensusAPI.Features;
    using VirtualBrightPlayz.SCP_ET.Player;
    public class UsingFemurBreakerEventArgs
    {
        public UsingFemurBreakerEventArgs(PlayerController ctrl)
        {
            Player = Player.Get(ctrl);
            IsAllowed = true;
        }
        public Player Player { get; }
        public bool IsAllowed { get; set; }
    }
}
