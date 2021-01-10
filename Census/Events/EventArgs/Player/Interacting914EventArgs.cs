namespace CensusCore.Events.EventArgs.Player
{
    using CensusAPI.Features;
    using System;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.World;

    public class Interacting914EventArgs : EventArgs
    {
        public Interacting914EventArgs(PlayerController p, SCP914Key scp)
        {
            Player = Player.Get(p);
            Scp = scp;
            IsAllowed = true;
        }

        public bool IsAllowed { get; set; }
        public Player Player { get; }
        public SCP914Key Scp { get; }
    }
}