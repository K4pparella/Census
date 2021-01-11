namespace CensusCore.Events.EventArgs.Player
{
    using CensusAPI.Features;
    using System;
    using VirtualBrightPlayz.SCP_ET;
    using VirtualBrightPlayz.SCP_ET.Player;

    public class InteractingKeycardReaderEventArgs : EventArgs
    {
        public InteractingKeycardReaderEventArgs(PlayerController p, int lvl, Door[] doors)
        {
            Player = Player.Get(p);
            Doors = doors;
            IsAllowed = true;
            RequiredLevel = lvl;
        }

        public bool IsAllowed { get; set; }
        public Player Player { get; }
        public Door[] Doors { get; }
        public int RequiredLevel { get; }
    }
}