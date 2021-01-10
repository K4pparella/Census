namespace CensusCore.Events.EventArgs.Player
{
    using CensusAPI.Features;
    using VirtualBrightPlayz.SCP_ET.Player;

    public class SendingChatMessageEventArgs
    {
        public SendingChatMessageEventArgs(PlayerController ply, string message)
        {
            Player = Player.Get(ply);
            Message = message;
            IsAllowed = true;
        }

        public Player Player { get; }
        public string Message { get; set; }
        public bool IsAllowed { get; set; }
    }
}