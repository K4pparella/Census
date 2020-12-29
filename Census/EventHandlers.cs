namespace CensusCore
{
    using PluginFramework.Events.EventsArgs;
    using CensusAPI.Features;
    public class EventHandlers
    {
        public void OnPlayerJoined(PlayerJoinFinalEvent ev)
        {
            Player ply = new Player(ev.player);
            Player.Dictionary.Add(ev.player, ply);
            Log.Info($"Player joined: {ply.Nickname}");
        }

        public void OnPlayerLeft(PlayerLeaveEvent ev)
        {
            Player.Dictionary.Remove(ev.player);
        }
    }
}
