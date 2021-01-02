namespace CensusCore.Events.EventArgs
{
    using System;
    using CensusAPI.Features;
    using VirtualBrightPlayz.SCP_ET;

    public class InteractingDoorButtonEventArgs: EventArgs
    {
        public InteractingDoorButtonEventArgs(Player p, Door[] doors)
        {
            Player = p;
            Doors = doors;
            IsAllowed = true;
        }
        public bool IsAllowed { get; set; }
        public Player Player { get; }
        public Door[] Doors { get; }
    }
}
