namespace CensusCore.Harmony.Events.Player
{
    using CensusAPI.Features;
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using System;
    using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;

    [HarmonyPatch(typeof(Inventory), nameof(Inventory.UserCode_CmdCraftItems))]
    public class CraftingItemPatch
    {
        private static bool Prefix(Inventory __instance, int index1, int index2)
        {
            try
            {
                if (index1 != -1 && index2 != -1 && index1 != index2)
                {
                    ItemBase item1 = __instance.Items[index1];
                    ItemBase item2 = __instance.Items[index2];
                    ItemBase result = null;
                    if (item1 is ItemCraftable && item2 is ItemCraftable)
                    {
                        ItemCraftable itemCraftable = (ItemCraftable)__instance.Items[index1];
                        ItemCraftable itemCraftable2 = (ItemCraftable)__instance.Items[index2];
                        itemCraftable.Craft(itemCraftable2, out result);
                    }
                    CraftingItemEventArgs ev = new CraftingItemEventArgs(__instance.plrCtrl, item1, item2, result);
                    CensusPlayerEvents.Instance.ExecuteCraftingItem(ev);
                    if (!ev.IsAllowed)
                    {
                        return false;
                    }

                    if (ev.Result != null)
                    {
                        __instance.Items[index1] = ev.Result;
                        __instance.RemoveItem(__instance.Items.IndexOf(item2));
                        __instance.RpcSetInventory(__instance.CurItem, __instance.CurWornItem);
                    }
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Log.Error($"Exception in CraftingItemPatch: {e}");
                return true;
            }
        }
    }
}