namespace CensusCore.Harmony.Events.Player
{
    using global::CensusCore.Events;
    using global::CensusCore.Events.EventArgs.Player;
    using HarmonyLib;
    using System.Collections.Generic;
    using System.Reflection.Emit;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.World;
    using VirtualBrightPlayz.SCP_ET.World.Interacts;
    using VirtualBrightPlayz.SCP_ET.Translation;

    [HarmonyPatch(typeof(Interact), nameof(Interact.StartUseOnce))]
    public class InteractingDoorButtonPatch
    {
        private static bool Prefix(Interact __instance, PlayerController plr, ref string status, ref ButtonErrorType errorType)
        {
            InteractingDoorButtonEventArgs ev = new InteractingDoorButtonEventArgs(plr, __instance.doors);
            CensusPlayerEvents.Instance.ExecuteInteractingDoorButton(ev);
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