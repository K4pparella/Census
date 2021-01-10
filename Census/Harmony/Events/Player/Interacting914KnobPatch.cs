namespace CensusCore.Harmony.Events.Player
{
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.World;

    //SCP914Knob.StartUseOnce
    [HarmonyPatch(typeof(SCP914Knob), nameof(SCP914Knob.StartUseOnce))]
    public class Interacting914KnobPatch
    {
        private static bool Prefix(SCP914Knob __instance, PlayerController user, bool isLocal, ref string status, ref ButtonErrorType errorType)
        {
            if (__instance.scp.isModeSelectTurning)
            {
                return true;
            }
            Interacting914KnobEventArgs ev = new Interacting914KnobEventArgs(user, __instance);
            CensusPlayerEvents.Instance.ExecuteInteracting914Knob(ev);
            if (!ev.IsAllowed)
            {
                status = "";
                errorType = ButtonErrorType.NoSound;
                return false;
            }
            return true;
        }
    }
}