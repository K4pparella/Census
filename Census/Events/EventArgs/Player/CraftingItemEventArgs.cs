namespace CensusCore.Events.EventArgs.Player
{
    using CensusAPI.Features;
    using UnityEngine;
    using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;
    using VirtualBrightPlayz.SCP_ET.Player;
    public class CraftingItemEventArgs
    {
        public CraftingItemEventArgs(PlayerController ctrl, ItemBase item1, ItemBase item2, ItemBase result)
        {
            Player = Player.Get(ctrl);
            Item1 = item1;
            Item2 = item2;
            Result = result;
            IsAllowed = true;
        }

        public Player Player { get; }
        public ItemBase Item1 { get; }
        public ItemBase Item2 { get; }
        public ItemBase Result { get; set; }
        public bool IsAllowed { get; set; }
    }
}
