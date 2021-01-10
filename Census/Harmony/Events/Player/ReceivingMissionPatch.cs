namespace CensusCore.Harmony.Events.Player
{
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using VirtualBrightPlayz.SCP_ET.Player;

    //PlayerMissionManager.AddMissionServer
    [HarmonyPatch(typeof(PlayerMissionManager), nameof(PlayerMissionManager.AddMissionServer))]
    public class ReceivingMissionPatch
    {
        private static bool Prefix(PlayerMissionManager __instance, ref MissionInfo? mission, ref bool Completed)
        {
            if (mission == null)
            {
                return true;
            }
            ReceivingMissionEventArgs ev = new ReceivingMissionEventArgs(__instance.stats.ctrl, mission.Value, Completed);
            CensusPlayerEvents.Instance.ExecuteReceivingMission(ev);
            if (!ev.IsAllowed)
            {
                return false;
            }
            mission = ev.Mission;
            Completed = ev.Completed;
            return true;
        }
    }
}