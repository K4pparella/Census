namespace CensusCore
{
    using PluginFramework.Attributes;
    using PluginFramework.Classes;
    using PluginFramework.Events.EventsArgs;
    using CensusAPI.Features;
    public class CensusEventHandlers: IScript
    {
        [PlayerEvent(PlayerEventType.OnPlayerJoinFinal)]
        public static void OnPlayerJoined(PlayerJoinFinalEvent ev)
        {
            Player ply = new Player(ev.player);
            Player.Dictionary.Add(ev.player, ply);
            Log.Info($"Player joined: {ply.Nickname}");
            ply.SendChatMessage($"This server is using Census-{CensusCore.Instance.Version}");
           
        }

        [PlayerEvent(PlayerEventType.OnPlayerLeave)]
        public static void OnPlayerLeft(PlayerLeaveEvent ev)
        {
            Player.Dictionary.Remove(ev.player);
        }
    }
}
