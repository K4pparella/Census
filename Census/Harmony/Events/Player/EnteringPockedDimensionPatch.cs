namespace CensusCore.Harmony.Events.Player
{
    //PocketDim.TeleportPlayer
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using VirtualBrightPlayz.SCP_ET.NPCs.SCP;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.World.SCP_106;

    [HarmonyPatch(typeof(PocketDim), nameof(PocketDim.TeleportPlayer))]
    public class EnteringPockedDimensionPatch
    {
        private static bool Prefix(PocketDim __instance, PlayerController plr, SCP106 scp)
        {
            EnteringPocketDimensionEventArgs ev = new EnteringPocketDimensionEventArgs(plr, scp);
            CensusPlayerEvents.Instance.ExecuteEnteringPocketDimension(ev);
            return ev.IsAllowed;
        }
    }
}