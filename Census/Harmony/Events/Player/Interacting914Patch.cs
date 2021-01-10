namespace CensusCore.Harmony.Events.Player
{
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.World;

    //SCP914Key.StartUseOnce
    [HarmonyPatch(typeof(SCP914Key), nameof(SCP914Key.StartUseOnce))]
    public class Interacting914KnobPatch
    {
        private static bool Prefix(SCP914Key __instance, PlayerController user, bool isLocal, ref string status, ref ButtonErrorType errorType)
        {
            if (__instance.scp.isRefining || __instance.scp.isModeSelectTurning)
            {
                return true;
            }
            Interacting914EventArgs ev = new Interacting914EventArgs(user, __instance);
            CensusPlayerEvents.Instance.ExecuteInteracting914(ev);
            if (!ev.IsAllowed)
            {
                status = "You cannot turn the key.";
                errorType = ButtonErrorType.ErrClick;
                return false;
            }
            return true;
        }
    }
}