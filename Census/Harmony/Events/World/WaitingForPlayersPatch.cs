using CensusCore.Events;
using CensusCore.Events.EventArgs.World;

namespace CensusCore.Harmony.Events.World
{
    using HarmonyLib;
    using VirtualBrightPlayz.SCP_ET.Network;

    [HarmonyPatch(typeof(CustomLobby), nameof(CustomLobby.Start))]
    public class WaitingForPlayersPatch
    {
        private static void Finalizer()
        {
            CensusWorldEvents.Instance.ExecuteWaitingForPlayers();
        }
    }
}