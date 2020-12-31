namespace CensusAPI.Features
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using VirtualBrightPlayz.SCP_ET.World;
    using VirtualBrightPlayz.SCP_ET;
    using VirtualBrightPlayz.SCP_ET.Items;
    using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;
    using Object = UnityEngine.Object;

    public class Map
    {
        private static readonly List<Door> DoorsValue = new List<Door>();
        private static ReadOnlyCollection<Door> RODoors = DoorsValue.AsReadOnly();

        private static readonly List<TeslaGate> TeslasValue = new List<TeslaGate>();
        private static ReadOnlyCollection<TeslaGate> ROTeslas = TeslasValue.AsReadOnly();

        public static List<WorldItemBase> Items => ItemDB.DataBase.WorldItems;

        public static ReadOnlyCollection<Door> Doors
        {
            get
            {
                if (DoorsValue.Count == 0)
                    DoorsValue.AddRange(Object.FindObjectsOfType<Door>());

                return RODoors;
            }
        }

        public static ReadOnlyCollection<TeslaGate> Teslas
        {
            get
            {
                if (TeslasValue.Count == 0)
                    TeslasValue.AddRange(Object.FindObjectsOfType<TeslaGate>());

                return ROTeslas;
            }
        }

        public static void SetLCZLockdownState(string val, bool sound = false)
        {
            LCZMissionControl.control.RpcUpdateLockdownState(val, sound);
        }

        public static bool IsLCZCheckpointLocked
        {
            get => !LCZMissionControl.control.checkpointsUnlocked;
            set
            {
                LCZMissionControl.control.checkpointsUnlocked = !value;
            }
        }
    }
}