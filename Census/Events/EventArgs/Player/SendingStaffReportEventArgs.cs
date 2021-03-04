namespace CensusCore.Events.EventArgs.Player
{
    using System;
    using VirtualBrightPlayz.SCP_ET.ServerGroups;
    using Player = CensusAPI.Features.Player;
    public class SendingStaffReportEventArgs
    {
        public SendingStaffReportEventArgs(Player reporter, Player reported, string reason)
        {
            Reporter = reporter;
            Reported = reported;
            Reason = reason;
            CallbackMessage = string.Empty;
            Success = true;
            IsAllowed = true;
        }
        public Player Reporter { get; }
        public Player Reported { get; }
        public string CallbackMessage { get; set; }
        public bool Success { get; set; }
        public string Reason { get; set; }
        public bool IsAllowed { get; set; }
    }
}