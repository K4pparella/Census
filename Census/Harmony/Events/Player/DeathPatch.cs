namespace CensusCore.Harmony.Events.Player
{
    using CensusAPI.Features;
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using System;
    using UnityEngine;
    using VirtualBrightPlayz.SCP_ET.NPCs.Interfaces;
    using VirtualBrightPlayz.SCP_ET.Player;

    [HarmonyPatch(typeof(PlayerStats), nameof(PlayerStats.KillPlayer), new Type[] { typeof(PlayerStats.DeathTypes), typeof(GameObject) })]
    public class DeathPatch
    {
        public static bool Prefix(PlayerStats __instance, ref PlayerStats.DeathTypes death, GameObject killer)
        {
            try
            {
                if (__instance.ClassId == 0 || __instance.ctrl._godMode)
                {
                    return true;
                }
                DyingEventArgs ev1 = new DyingEventArgs(__instance.ctrl, death, killer == null ? null : killer.GetComponent<IEntity>());
                CensusPlayerEvents.Instance.ExecuteDying(ev1);
                if (!ev1.IsAllowed)
                {
                    return false;
                }
                death = ev1.DamageType;
                return true;
            }
            catch (Exception e)
            {
                Log.Error($"Exception in DeathPatch: {e}");
                return true;
            }
        }

        public static void Postfix(PlayerStats __instance, PlayerStats.DeathTypes death, GameObject killer)
        {
            CensusPlayerEvents.InvokeDied(__instance.ctrl, death, killer);
        }
    }
}