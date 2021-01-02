namespace CensusCore.Events
{
    using CensusAPI.Features;
    using EventArgs;
    using System;
    using VirtualBrightPlayz.SCP_ET;

    public class CensusWorldEvents
    {
        public CensusWorldEvents()
        {
            Instance = this;
        }

        public static CensusWorldEvents Instance { get; private set; }

        public static event InteractingDoorButton InteractingDoorButtonEvent;

        public delegate void InteractingDoorButton(InteractingDoorButtonEventArgs ev);

        public static event InteractingPizza InteractingPizzaEvent;

        public delegate void InteractingPizza(InteractingPizzaEventArgs ev);

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

        public static void InvokeInteractingDoorButton(Player player, Door[] doors)
        {
            InteractingDoorButtonEventArgs ev = new InteractingDoorButtonEventArgs(player, doors);
            Instance.ExecuteInteractingDoorButton(ev);
        }

        public void ExecuteInteractingPizza(InteractingPizzaEventArgs ev)
        {
            try
            {
                InteractingPizzaEvent?.Invoke(ev);
            }
            catch (Exception e)
            {
                Log.Error($"Exception while handling InteractingPizzaEvent: {e}");
            }
        }

        public static void InvokeInteractingPizza(Player player)
        {
            InteractingPizzaEventArgs ev = new InteractingPizzaEventArgs(player);
            Instance.ExecuteInteractingPizza(ev);
        }
    }
}