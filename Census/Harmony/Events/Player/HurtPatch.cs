namespace CensusCore.Harmony.Events.Player
{
    using System;
    using CensusAPI.Features;
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using UnityEngine;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.NPCs.Interfaces;

    [HarmonyPatch(typeof(PlayerHealthController), nameof(PlayerHealthController.PlrDamage))]
    public class HurtPatch
    {
        private static bool Prefix(PlayerHealthController __instance, ref float damage, GameObject attacker, ref PlayerStats.DeathTypes DamageType)
        {
            try
            {
                if (!__instance.IsServer)
                {
                    return true;
                }
                if (__instance.Health <= 0f || __instance.ctrl.ClassId == 0 || __instance.ctrl._godMode)
                {
                    return true;
                }
                HurtEventArgs ev = new HurtEventArgs(__instance.ctrl, damage, attacker.GetComponent<IEntity>(), DamageType);
                CensusPlayerEvents.Instance.ExecuteHurt(ev);
                if (!ev.IsAllowed)
                {
                    return false;
                }
                damage = ev.Amount;
                DamageType = ev.DamageType;
                return true;
            }catch(Exception e)
            {
                Log.Error($"Exception in HurtPatch: {e}");
                return true;
            }
        }
    }
}