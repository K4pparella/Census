namespace CensusCore.Harmony.Events.Player
{
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.World;
    using VirtualBrightPlayz.SCP_ET.World.FemurBreaker;
    using HarmonyLib;
    [HarmonyPatch(typeof(FemurBreakerButton), nameof(FemurBreakerButton.StartUseOnce))]
    public class UsingFemurBreakerPatch
    {
        private static bool Prefix(FemurBreakerButton __instance, PlayerController user, bool isLocal, ref string status, ref ButtonErrorType errorType)
        {
            UsingFemurBreakerEventArgs ev = new UsingFemurBreakerEventArgs(user);
            CensusPlayerEvents.Instance.ExecuteUsingFemurBreaker(ev);
            if (!ev.IsAllowed)
            {
                status = string.Empty;
                errorType = ButtonErrorType.NoSound;
                return false;
            }
            return true;
        }
    }
}
