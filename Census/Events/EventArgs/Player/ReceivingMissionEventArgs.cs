namespace CensusCore.Events.EventArgs.Player
{
    using CensusAPI.Features;
    using VirtualBrightPlayz.SCP_ET.Player;

    public class ReceivingMissionEventArgs
    {
        public ReceivingMissionEventArgs(PlayerController ctrl, MissionInfo info, bool completed)
        {
            Player = Player.Get(ctrl);
            Mission = info;
            IsAllowed = true;
            Completed = completed;
        }

        public Player Player { get; }
        public MissionInfo Mission { get; set; }
        public bool IsAllowed { get; set; }
        public bool Completed { get; set; }
    }
}