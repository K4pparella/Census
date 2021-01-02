namespace CensusCore.Harmony.Events
{
    using CensusAPI.Features;
    using global::CensusCore.Events;
    using HarmonyLib;
    using VirtualBrightPlayz.SCP_ET.Player;
    using VirtualBrightPlayz.SCP_ET.World;
    using VirtualBrightPlayz.SCP_ET.World.Interacts;

    //Not called, lol

    [HarmonyPatch(typeof(PizzaSlice), nameof(PizzaSlice.StartUseOnce))]
    public class InteractingPizzaPatch
    {
        private static bool Prefix(PizzaSlice __instance, PlayerController user)
        {
            CensusWorldEvents.InvokeInteractingPizza(Player.Get(user));
            return true;
        }
    }
}