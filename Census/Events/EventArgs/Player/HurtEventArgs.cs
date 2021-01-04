namespace CensusCore.Events.EventArgs.Player
{
    using CensusAPI.Features;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.NPCs.Interfaces;
    public class HurtEventArgs
    {
        public HurtEventArgs(PlayerController ctrl, float amount, IEntity ent, PlayerStats.DeathTypes dt)
        {
            Player = Player.Get(ctrl);
            Amount = amount;
            IsAllowed = true;
            Attacker = ent;
            DamageType = dt;
        }

        public Player Player { get; }
        public IEntity Attacker { get; }
        public PlayerStats.DeathTypes DamageType { get; set; }
        public float Amount { get; set; }
        public bool IsAllowed { get; set; }
    }
}