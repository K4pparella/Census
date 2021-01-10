namespace CensusCore.Harmony.Events.Player
{
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using VirtualBrightPlayz.SCP_ET;

    //TextChat.UserCode_CmdSendMessage
    [HarmonyPatch(typeof(TextChat), nameof(TextChat.UserCode_CmdSendMessage))]
    public class SendingChatMessagePatch
    {
        private static bool Prefix(TextChat __instance, ref string Message)
        {
            SendingChatMessageEventArgs ev = new SendingChatMessageEventArgs(__instance.controller, Message);
            CensusPlayerEvents.Instance.ExecuteSendingChatMessage(ev);
            if (!ev.IsAllowed)
            {
                return false;
            }
            Message = ev.Message;
            return true;
        }
    }
}