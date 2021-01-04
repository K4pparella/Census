namespace CensusCore.Events.EventArgs.Player
{
    using CensusAPI.Features;
    using UnityEngine;
    using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;
    using VirtualBrightPlayz.SCP_ET.Player;

    public class PickingUpItemEventArgs
    {
        public PickingUpItemEventArgs(PlayerController ctrl, ItemBase item, GameObject itemObject)
        {
            Player = Player.Get(ctrl);
            Item = Item;
            IsAllowed = true;
            CanPickup = true;
            ItemGameObject = itemObject;
        }

        public Player Player { get; }
        public GameObject ItemGameObject { get; set; }
        public ItemBase Item { get; set; }
        public bool IsAllowed { get; set; }
        public bool CanPickup { get; set; }
    }
}