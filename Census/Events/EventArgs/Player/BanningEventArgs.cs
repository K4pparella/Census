namespace CensusCore.Events.EventArgs.Player
{
    using System;
    using Player = CensusAPI.Features.Player;

    public class BanningEventArgs
    {
        public BanningEventArgs(Player plyban, TimeSpan duration, string reason)
        {
            PlayerBan = plyban;
            Reason = reason;
            Duration = duration;
            IsAllowed = true;
        }

        public Player PlayerBan { get; }
        public string Reason { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsAllowed { get; set; }
    }
}