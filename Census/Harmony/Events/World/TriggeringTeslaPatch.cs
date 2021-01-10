namespace CensusCore.Harmony.Events.World
{
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.World;
    using VirtualBrightPlayz.SCP_ET.World;
    using UnityEngine;
    using HarmonyLib;

    [HarmonyPatch(typeof(TeslaGateCollider), nameof(TeslaGateCollider.OnTriggerStay))]
    public class TriggeringTeslaPatch
    {
        private static bool Prefix(TeslaGateCollider __instance, Collider other)
        {
            TriggeringTeslaEventArgs ev = new TriggeringTeslaEventArgs(__instance, other);
            CensusWorldEvents.Instance.ExecuteTriggeringTesla(ev);
            if (ev.IsAllowed && !__instance.parent.isCharging && !__instance.parent.isShocking)
            {
                __instance.parent.Charge(0.7f);
            }
            return false;
        }
    }
}
