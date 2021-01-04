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
                Log.Error($"Exception while handling InteractingDoorButtonEvent: {e}");
            }
        }

        public static void InvokeDied(PlayerController player, PlayerStats.DeathTypes death, GameObject killer)
        {
            DiedEventArgs ev = new DiedEventArgs(player, death, killer == null ? null : killer.GetComponent<IEntity>());
            Instance.ExecuteDied(ev);
        }
    }
}