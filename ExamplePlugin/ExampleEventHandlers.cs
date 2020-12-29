namespace ExamplePlugin
{
    using CensusAPI.Features;
    using PluginFramework.Attributes;
    using PluginFramework.Classes;
    using PluginFramework.Events.EventsArgs;

    public class ExampleEventHandlers : IScript
    {
        [PlayerEvent(PlayerEventType.OnPlayerJoinFinal)]
        public static void OnPlayerJoin(PlayerJoinFinalEvent ev)
        {
            Player player = Player.Get(ev.player);
            player.SendChatMessage($"Hello, {player.Nickname}!");
        }
    }
}