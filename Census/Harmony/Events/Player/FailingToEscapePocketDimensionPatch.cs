namespace CensusCore.Harmony.Events.Player
{
    //PocketDim.KillPD
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;
    using VirtualBrightPlayz.SCP_ET.World.SCP_106;
    using VirtualBrightPlayz.SCP_ET.NPCs.SCP;
    using HarmonyLib;

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