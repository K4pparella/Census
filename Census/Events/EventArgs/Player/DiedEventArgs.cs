namespace CensusCore.Events.EventArgs.Player
{
    using CensusAPI.Features;
    using VirtualBrightPlayz.SCP_ET.NPCs.Interfaces;
    using VirtualBrightPlayz.SCP_ET.Player;

    public class DiedEventArgs
    {
        public DiedEventArgs(PlayerController ctrl, PlayerStats.DeathTypes dt, IEntity attacker)
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