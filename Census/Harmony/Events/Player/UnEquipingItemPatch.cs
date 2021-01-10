namespace CensusCore.Harmony.Events.Player
{
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;

    //Inventory.UserCode_CmdUnEquipItem
    [HarmonyPatch(typeof(Inventory), nameof(Inventory.UserCode_CmdUnEquipItem))]
    public class UnEquipingItemPatch
    {
        private static bool Prefix(Inventory __instance, ref int index)
        {
            if (__instance.CurItem == -1 || __instance.CurWornItem == -1)
            {
                return true;
            }
            UnEquipingItemEventArgs ev = new UnEquipingItemEventArgs(__instance.plrCtrl, index);
            CensusPlayerEvents.Instance.ExecuteUnEquipingItem(ev);
            if (!ev.IsAllowed)
            {
                return false;
            }
            index = ev.Index;
            return true;
        }
    }
}