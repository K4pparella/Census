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
    }
}