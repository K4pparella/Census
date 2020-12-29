using HarmonyLib;

namespace CensusCore.Harmony.Fixes
{
    [HarmonyPatch(typeof(Tayx.Graphy.GraphyManager), nameof(Tayx.Graphy.GraphyManager.Update))]
    public class NRESpamFix
    {
        private static bool Prefix(Tayx.Graphy.GraphyManager __instance){
            return false;
        }
    }
}
