namespace CensusCore.Events.EventArgs.Player
{
    using CensusAPI.Features;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.NPCs.Interfaces;
    public class DyingEventArgs
    {
        public DyingEventArgs(PlayerController ctrl, PlayerStats.DeathTypes dt, IEntity attacker)
        {
            Player = Player.Get(ctrl);
            DamageType = dt;
            IsAllowed = true;
            Attacker = attacker;
        }

        public Player Player { get; }
        public IEntity Attacker { get; }
        public PlayerStats.DeathTypes DamageType { get; set; }
        public bool IsAllowed { get; set; }
    }
}
