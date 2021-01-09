namespace ExamplePlugin
{
    using CensusAPI.Enums;
    using CensusAPI.Features;
    using CensusCore.Events.Attributes;
    using CensusCore.Events.EventArgs.Player;
    using PluginFramework.Attributes;
    using PluginFramework.Classes;
    using PluginFramework.Events.EventsArgs;
    using System;
    using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;

    public class ExampleEventHandlers : IScript
    {
        [PlayerEvent(PlayerEventType.OnPlayerJoinFinal)]
        public static void OnPlayerJoin(PlayerJoinFinalEvent ev)
        {
            Player player = Player.Get(ev.player);
            player.SendChatMessage($"Hello, {player.Nickname}!");
            player.AddMission("Enjoy the game!");
        }

        [CensusPlayerEvent(CensusPlayerEventType.InteractingDoorButton)]
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

        [CensusPlayerEvent(CensusPlayerEventType.CraftingItem)]
        public static void OnPickup(CraftingItemEventArgs ev)
        {
            try
            {
                if (ev.Item1.ItemId == ItemType.Flashlight.ToString("g") && ev.Item2.ItemId == ItemType.Radio.ToString("g"))
                {
                    ev.Result = new ItemBattery
                    {
                        inv = ev.Player.Inventory
                    };
                }
            }
            catch (Exception)
            {
                Log.Warn("Event invoked, but something went wrong!");
            }
        }
    }
}