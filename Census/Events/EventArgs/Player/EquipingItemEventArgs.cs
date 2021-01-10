namespace CensusCore.Events.EventArgs.Player
{
    using CensusAPI.Features;
    using VirtualBrightPlayz.SCP_ET.Player;

    public class EquipingItemEventArgs
    {
        public EquipingItemEventArgs(PlayerController ctrl, int item)
        {
            Player = Player.Get(ctrl);
            Index = item;
            IsAllowed = true;
        }

        public Player Player { get; }
        public int Index { get; set; }
        public bool IsAllowed { get; set; }
    }
}
