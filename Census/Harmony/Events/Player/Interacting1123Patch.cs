namespace CensusCore.Harmony.Events.Player
{
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.Translation;
    using VirtualBrightPlayz.SCP_ET.World;

    //SCP_1123_real.StartUseOnce
    [HarmonyPatch(typeof(SCP_1123_real), nameof(SCP_1123_real.StartUseOnce))]
    public class Interacting1123Patch
    {
        private static bool Prefix(SCP_1123_real __instance, PlayerController plr, bool isLocal, ref string status, ref ButtonErrorType errorType)
        {
            Interacting1123EventArgs ev = new Interacting1123EventArgs(plr, __instance);
            CensusPlayerEvents.Instance.ExecuteInteracting1123(ev);
            if (!ev.IsAllowed)
            {
                status = TranslationManager.GetString(TextType.Misc, "1123NOTOUCH");
                errorType = ButtonErrorType.NoSound;
                return false;
            }
            return true;
        }
    }
}