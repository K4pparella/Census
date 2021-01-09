namespace CensusCore.Events
{
    using CensusAPI.Features;
    using EventArgs.Player;
    using System;
    using UnityEngine;
    using VirtualBrightPlayz.SCP_ET.NPCs.Interfaces;
    using VirtualBrightPlayz.SCP_ET.Player;

    public class CensusPlayerEvents
    {
        public CensusPlayerEvents()
        {
            Instance = this;
        }

        public static CensusPlayerEvents Instance { get; private set; }

        public static event Hurt HurtEvent;

        public delegate void Hurt(HurtEventArgs ev);

        public void ExecuteHurt(HurtEventArgs ev)
        {
            try
            {
                HurtEvent?.Invoke(ev);
            }
            catch (Exception e)
            {
                Log.Error($"Exception while handling HurtEvent: {e}");
            }
        }

        public static event Dying DyingEvent;

        public delegate void Dying(DyingEventArgs ev);

        public void ExecuteDying(DyingEventArgs ev)
        {
            try
            {
                DyingEvent?.Invoke(ev);
            }
            catch (Exception e)
            {
                Log.Error($"Exception while handling DyingEvent: {e}");
            }
        }

        public static event Died DiedEvent;

        public delegate void Died(DiedEventArgs ev);

        public void ExecuteDied(DiedEventArgs ev)
        {
            try
            {
                DiedEvent?.Invoke(ev);
            }
            catch (Exception e)
            {
                Log.Error($"Exception while handling DiedEvent: {e}");
            }
        }

        public static void InvokeDied(PlayerController player, PlayerStats.DeathTypes death, GameObject killer)
        {
            DiedEventArgs ev = new DiedEventArgs(player, death, killer == null ? null : killer.GetComponent<IEntity>());
            Instance.ExecuteDied(ev);
        }

        public static event PickingUpItem PickingUpItemEvent;

        public delegate void PickingUpItem(PickingUpItemEventArgs ev);

        public void ExecutePickingUpItem(PickingUpItemEventArgs ev)
        {
            try
            {
                PickingUpItemEvent?.Invoke(ev);
            }
            catch (Exception e)
            {
                Log.Error($"Exception while handling PickingUpItemEvent: {e}");
            }
        }

        public static event CraftingItem CraftingItemEvent;

        public delegate void CraftingItem(CraftingItemEventArgs ev);

        public void ExecuteCraftingItem(CraftingItemEventArgs ev)
        {
            try
            {
                CraftingItemEvent?.Invoke(ev);
            }
            catch (Exception e)
            {
                Log.Error($"Exception while handling CraftingItemEvent: {e}");
            }
        }

        public static event UsingFemurBreaker UsingFemurBreakerEvent;

        public delegate void UsingFemurBreaker(UsingFemurBreakerEventArgs ev);

        public void ExecuteUsingFemurBreaker(UsingFemurBreakerEventArgs ev)
        {
            try
            {
                UsingFemurBreakerEvent?.Invoke(ev);
            }
            catch (Exception e)
            {
                Log.Error($"Exception while handling UsingFemurBreakerEvent: {e}");
            }
        }

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