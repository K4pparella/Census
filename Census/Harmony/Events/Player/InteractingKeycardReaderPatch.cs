namespace CensusCore.Harmony.Events.Player
{
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.Translation;
    using VirtualBrightPlayz.SCP_ET.World;
    using VirtualBrightPlayz.SCP_ET.World.Interacts;

    //KeycardButton.StartUseOnce
    [HarmonyPatch(typeof(KeycardButton), nameof(KeycardButton.StartUseOnce))]
    public class InteractingKeycardReaderPatch
    {
        private static bool Prefix(KeycardButton __instance, PlayerController plr, ref string status, ref ButtonErrorType errorType)
        {
            InteractingKeycardReaderEventArgs ev = new InteractingKeycardReaderEventArgs(plr, __instance.ReqLevel, __instance.doors);
            CensusPlayerEvents.Instance.ExecuteInteractingKeycardReader(ev);
            if (!ev.IsAllowed)
            {
                status = TranslationManager.GetString(TextType.Misc, "INTERACTNOTHING");
                errorType = ButtonErrorType.ErrClick;
                return false;
            }
            return true;
        }
    }
}