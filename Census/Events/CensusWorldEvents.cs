namespace CensusCore.Events
{
    using CensusAPI.Features;
    using EventArgs.World;
    using System;

    public class CensusWorldEvents
    {
        public CensusWorldEvents()
        {
            Instance = this;
        }

        public static CensusWorldEvents Instance { get; private set; }

        public static event TriggeringTesla TriggeringTeslaEvent;

        public delegate void TriggeringTesla(TriggeringTeslaEventArgs ev);

        public void ExecuteTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            try
            {
                TriggeringTeslaEvent?.Invoke(ev);
            }
            catch (Exception e)
            {
                Log.Error($"Exception while handling TriggeringTeslaEvent: {e}");
            }
        }
        public static event WaitingForPlayers WaitingForPlayersEvent;

        public delegate void WaitingForPlayers();

        public void ExecuteWaitingForPlayers()
        {
            try
            {
                WaitingForPlayersEvent?.Invoke();
            }
            catch (Exception e)
            {
                Log.Error($"Exception while handling WaitingForPlayersEvent: {e}");
            }
        }
    }
}