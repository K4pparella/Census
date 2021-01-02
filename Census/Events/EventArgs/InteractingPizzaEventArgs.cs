namespace CensusCore.Events.EventArgs
{
    using System;
    using CensusAPI.Features;
    using VirtualBrightPlayz.SCP_ET;
    public class InteractingPizzaEventArgs
    {
        public InteractingPizzaEventArgs(Player p)
        {
            Player = p;
        }
        public Player Player { get; }
    }
}
