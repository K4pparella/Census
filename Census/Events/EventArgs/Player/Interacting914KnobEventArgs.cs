namespace CensusCore.Events.EventArgs.Player
{
    using CensusAPI.Features;
    using System;
    using VirtualBrightPlayz.SCP_ET;
    using VirtualBrightPlayz.SCP_ET.World;
    using VirtualBrightPlayz.SCP_ET.Player;

    public class Interacting914KnobEventArgs : EventArgs
    {
        public Interacting914KnobEventArgs(PlayerController p, SCP914Knob scp)
        {
            Player = Player.Get(p);
            Knob = scp;
            IsAllowed = true;
        }

        public bool IsAllowed { get; set; }
        public Player Player { get; }
        public SCP914Knob Knob { get; }
    }
}