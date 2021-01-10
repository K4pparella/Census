namespace CensusCore.Events.EventArgs.World
{
    using UnityEngine;
    using VirtualBrightPlayz.SCP_ET.World;
    using VirtualBrightPlayz.SCP_ET.NPCs.Interfaces;
    public class TriggeringTeslaEventArgs
    {
        public TriggeringTeslaEventArgs(TeslaGateCollider tesla, Collider collider)
        {
            Object = collider;
            Tesla = tesla.parent;
            IsAllowed = collider.GetComponent<ICanTriggerTesla>() != null && !collider.GetComponent<ICanTriggerTesla>().isValidTarget;
        }

        public Collider Object { get; }
        public TeslaGate Tesla { get; }
        public bool IsAllowed { get; set; }
    }
}
