namespace CensusCore.Harmony.Events.Player
{
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using VirtualBrightPlayz.SCP_ET.Player;

    //PlayerController.UserCode_CmdBlink
    [HarmonyPatch(typeof(PlayerController), nameof(PlayerController.UserCode_CmdBlink))]
    public class BlinkingPatch
    {
        private static bool Prefix(PlayerController __instance)
        {
            if (!__instance.stats.isBlinkingDisabled)
            {
                return true;
            }
            BlinkingEventArgs ev = new BlinkingEventArgs(__instance);
            CensusPlayerEvents.Instance.ExecuteBlinking(ev);
            return ev.IsAllowed;
        }
    }
}