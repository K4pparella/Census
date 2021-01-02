namespace ExamplePlugin
{
    using CensusAPI.Features;
    using CensusCore.Events.EventArgs;
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

        [CensusWorldEvent(CensusWorldEventType.InteractingPizza)]
        public static void OnPizza(InteractingPizzaEventArgs ev)
        {
            ev.Player.SendChatMessage("You've interacted with a magic pizza and got extra hp!");
            ev.Player.MaxHealth += 500;
            ev.Player.Health = ev.Player.MaxHealth;
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
    }
}