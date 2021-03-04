namespace CensusCore.Harmony.Events.Player
{
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using VirtualBrightPlayz.SCP_ET.ServerGroups;
    using System.Linq;
    using VirtualBrightPlayz.SCP_ET.Player;
    using Player = CensusAPI.Features.Player;

    [HarmonyPatch(typeof(IngameReport), nameof(IngameReport.UserCode_CmdReportToStaff))]
    public class SendingStaffReportPatch
    {
        private static bool Prefix(IngameReport __instance, int reporterId, int reportedId, ref string reason)
        {
            if (!PlayerList.List.players.Keys.ToList<PlayerController>()
                .Any((PlayerController ctrl) => ctrl.playerId == reporterId))
            {
                __instance.TargetReportCallback(__instance.ConnectionToClient, false, "REPORTMISSINGREPORTER", true);
                return false;
            }

            if (!PlayerList.List.players.Keys.ToList<PlayerController>()
                .Any((PlayerController ctrl) => ctrl.playerId == reportedId))
            {
                __instance.TargetReportCallback(__instance.ConnectionToClient, false, "REPORTMISSINGREPORTED", true);
                return false;
            }

            if (reportedId == reporterId)
            {
                __instance.TargetReportCallback(__instance.ConnectionToClient, false, "REPORTMISSINGREPORTER", true);
                return false;
            }

            reason = reason.Replace("<", "").Replace(">", "").Replace("@", "@ ");
            if (string.IsNullOrWhiteSpace(reason))
            {
                __instance.TargetReportCallback(__instance.ConnectionToClient, false, "REPORTMISSINGREASON", true);
                return false;
            }

            PlayerController playerController = PlayerList.List.players.Keys.ToList<PlayerController>()
                .Find((PlayerController ctrl) => ctrl.playerId == reportedId);
            PlayerController playerController2 = PlayerList.List.players.Keys.ToList<PlayerController>()
                .Find((PlayerController ctrl) => ctrl.playerId == reporterId);
            Player reported = CensusAPI.Features.Player.Get(playerController);
            Player reporter = CensusAPI.Features.Player.Get(playerController2);
            SendingStaffReportEventArgs ev = new SendingStaffReportEventArgs(reporter, reported, reason);
            CensusPlayerEvents.Instance.ExecuteSendingStaffReport(ev);
            if (!ev.IsAllowed)
            {
                __instance.TargetReportCallback(__instance.ConnectionToClient, ev.Success, ev.CallbackMessage, false);
                return false;
            }

            reason = ev.Reason;
            return true;
        }
    }
}