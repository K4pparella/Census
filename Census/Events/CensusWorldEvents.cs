namespace CensusCore.Events
{
    using CensusAPI.Features;
    using EventArgs.World;
    using System;
    using VirtualBrightPlayz.SCP_ET;
    using VirtualBrightPlayz.SCP_ET.Player;
    public class CensusWorldEvents
    {
        public CensusWorldEvents()
        {
            Instance = this;
        }

        public static CensusWorldEvents Instance { get; private set; }

        public static event InteractingDoorButton InteractingDoorButtonEvent;

        public delegate void InteractingDoorButton(InteractingDoorButtonEventArgs ev);

        public void ExecuteInteractingDoorButton(InteractingDoorButtonEventArgs ev)
        {
            try
            {
                InteractingDoorButtonEvent?.Invoke(ev);
            }
            catch (Exception e)
            {
                Log.Error($"Exception while handling InteractingDoorButtonEvent: {e}");
            }
        }
    }
}