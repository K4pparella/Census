namespace CensusCore.Harmony.Events.Player
{
    //PocketDim.ExitPD
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.World.SCP_106;

    [HarmonyPatch(typeof(PocketDim), nameof(PocketDim.ExitPD))]
    public class EscapingPockedDimensionPatch
    {
        private static bool Prefix(PocketDim __instance, PlayerController plr)
        {
            EscapingPocketDimensionEventArgs ev = new EscapingPocketDimensionEventArgs(plr);
            CensusPlayerEvents.Instance.ExecuteEscapingPocketDimension(ev);
            return ev.IsAllowed;
        }
    }
}