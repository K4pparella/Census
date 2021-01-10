namespace CensusCore.Events.EventArgs.Player
{
    using CensusAPI.Features;
    using System;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.World;

    public class Interacting1123EventArgs : EventArgs
    {
        public Interacting1123EventArgs(PlayerController p, SCP_1123_real scp)
        {
            Player = Player.Get(p);
            Scp = scp;
            IsAllowed = true;
        }

        public bool IsAllowed { get; set; }
        public Player Player { get; }
        public SCP_1123_real Scp { get; }
    }
}