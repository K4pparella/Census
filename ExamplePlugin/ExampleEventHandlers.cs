namespace ExamplePlugin
{
    using CensusAPI.Features;
    using CensusCore.Events.EventArgs.Player;
    using CensusCore.Events.EventArgs.World;
    using CensusCore.Events.Attributes;
    using PluginFramework.Attributes;
    using PluginFramework.Classes;
    using PluginFramework.Events.EventsArgs;
    using System;

    public class ExampleEventHandlers : IScript
    {
        [PlayerEvent(PlayerEventType.OnPlayerJoinFinal)]
        public static void OnPlayerJoin(PlayerJoinFinalEvent ev)
        {
            Player player = Player.Get(ev.player);
            player.SendChatMessage($"Hello, {player.Nickname}!");
            player.AddMission("Enjoy the game!");
        }

        [CensusWorldEvent(CensusWorldEventType.InteractingDoorButton)]
        public static void OnDoor(InteractingDoorButtonEventArgs ev)
        {
            try
            {
                ev.Player.SendChatMessage("You've interacted with a door!");
            }
            catch (Exception)
            {
                Log.Warn("Event invoked, but something went wrong!");
            }
        }

        [CensusPlayerEvent(CensusPlayerEventType.Dying)]
        public static void OnDying(DyingEventArgs ev)
        {
            try
            {
                ev.Player.SendChatMessage("Ouch!");
                ev.IsAllowed = false;
            }
            catch (Exception)
            {
                Log.Warn("Event invoked, but something went wrong!");
            }
        }
    }
}