namespace CensusCore.Harmony.Events.Player
{
    //PocketDim.TeleportPlayer
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;
    using VirtualBrightPlayz.SCP_ET.World.SCP_106;
    using VirtualBrightPlayz.SCP_ET.NPCs.SCP;
    using HarmonyLib;
    //Inventory.UserCode_CmdDropItemIndex
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