namespace CensusCore.Harmony.Events.Player
{
    using CensusAPI.Features;
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using System;
    using UnityEngine;
    using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;

    [HarmonyPatch(typeof(Inventory), nameof(Inventory.PickupItem))]
    public class PickingUpItemPatch
    {
        private static bool Prefix(Inventory __instance, ref bool __result, ItemBase item, GameObject itemObject)
        {
            try
            {
                if (__instance.Items.Count > 9)
                {
                    return true;
                }
                PickingUpItemEventArgs ev = new PickingUpItemEventArgs(__instance.plrCtrl, item, itemObject);
                CensusPlayerEvents.Instance.ExecutePickingUpItem(ev);
                if (!ev.IsAllowed)
                {
                    __result = false;
                    __instance.disablePickUpClientSound = true;
                    return false;
                }
                bool can = item.OnPickup(__instance.gameObject, ev.ItemGameObject) || ev.CanPickup;
                if (can)
                {
                    __instance.disablePickUpClientSound = false;
                    __instance.Items.Add(item);
                }
                else
                {
                    __instance.disablePickUpClientSound = true;
                }
                __instance.RpcSetInventory(__instance.CurItem, __instance.CurWornItem);
                __result = can;
                return false;
            }
            catch (Exception e)
            {
                Log.Error($"Exception in PickingUpItemPatch: {e}");
                return true;
            }
        }
    }
}