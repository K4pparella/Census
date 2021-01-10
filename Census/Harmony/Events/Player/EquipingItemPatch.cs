namespace CensusCore.Harmony.Events.Player
{
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;
    using HarmonyLib;
    //Inventory.UserCode_CmdEquipItem
    [HarmonyPatch(typeof(Inventory), nameof(Inventory.UserCode_CmdEquipItem))]
    public class EquipingItemPatch
    {
        private static bool Prefix(Inventory __instance,ref int index)
        {
            if(index == -1)
            {
                return true;
            }
            EquipingItemEventArgs ev = new EquipingItemEventArgs(__instance.plrCtrl, index);
            CensusPlayerEvents.Instance.ExecuteEquipingItem(ev);
            if (!ev.IsAllowed)
            {
                return false;
            }
            index = ev.Index;
            return true;
        }
    }
}