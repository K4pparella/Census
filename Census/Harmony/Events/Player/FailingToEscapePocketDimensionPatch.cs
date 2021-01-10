namespace CensusCore.Harmony.Events.Player
{
    //PocketDim.KillPD
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.World.SCP_106;

    [HarmonyPatch(typeof(PocketDim), nameof(PocketDim.KillPD))]
    public class FailingToEscapePocketDimensionPatch
    {
        private static bool Prefix(PocketDim __instance, PlayerController plr)
        {
            FailingToEscapePocketDimensionEventArgs ev = new FailingToEscapePocketDimensionEventArgs(plr);
            CensusPlayerEvents.Instance.ExecuteFailingToEscapePocketDimension(ev);
            return ev.IsAllowed;
        }
    }
}