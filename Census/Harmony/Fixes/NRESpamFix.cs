namespace CensusCore.Harmony.Fixes
{
    using HarmonyLib;
    using System;

    [HarmonyPatch(typeof(Tayx.Graphy.GraphyManager), nameof(Tayx.Graphy.GraphyManager.Update))]
    public class NRESpamFix
    {
        private static bool Prefix(Tayx.Graphy.GraphyManager __instance)
        {
            try
            {
                if (__instance.m_focused && __instance.m_enableHotkeys)
                {
                    __instance.CheckForHotkeyPresses();
                }
            }
            catch (Exception)
            {
            }
            return false;
        }
    }
}