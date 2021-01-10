namespace CensusCore.Harmony.Events.Player
{
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;

    //Inventory.UserCode_CmdDropItemIndex
    [HarmonyPatch(typeof(Inventory), nameof(Inventory.UserCode_CmdDropItemIndex))]
    public class DroppingItemPatch
    {
        private static bool Prefix(Inventory __instance, ref int index)
        {
            if (index == -1)
            {
                return true;
            }
            DroppingItemEventArgs ev = new DroppingItemEventArgs(__instance.plrCtrl, index);
            CensusPlayerEvents.Instance.ExecuteDroppingItem(ev);
            if (!ev.IsAllowed)
            {
                return false;
            }
            index = ev.Index;
            return true;
        }
    }
}