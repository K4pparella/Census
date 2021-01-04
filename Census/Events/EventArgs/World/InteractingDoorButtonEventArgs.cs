namespace CensusCore.Events.EventArgs.World
{
    using System;
    using CensusAPI.Features;
    using VirtualBrightPlayz.SCP_ET;
    using VirtualBrightPlayz.SCP_ET.Player;
    public class InteractingDoorButtonEventArgs: EventArgs
    {
        public InteractingDoorButtonEventArgs(PlayerController p, Door[] doors)
        {
            Player = Player.Get(p);
            Doors = doors;
            IsAllowed = true;
        }
        public bool IsAllowed { get; set; }
        public Player Player { get; }
        public Door[] Doors { get; }
    }
}
