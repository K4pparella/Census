namespace CensusAPI.Features
{
    using Enums;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using UnityEngine;
    using VirtualBrightPlayz.SCP_ET;
    using VirtualBrightPlayz.SCP_ET.Database;
    using VirtualBrightPlayz.SCP_ET.Items;
    using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;
    using VirtualBrightPlayz.SCP_ET.World;
    using VirtualBrightPlayz.SCP_ET.World.FemurBreaker;
    using Object = UnityEngine.Object;

    public class Map
    {
        private static readonly List<Door> DoorsValue = new List<Door>();
        private static ReadOnlyCollection<Door> RODoors = DoorsValue.AsReadOnly();

        private static readonly List<TeslaGate> TeslasValue = new List<TeslaGate>();
        private static ReadOnlyCollection<TeslaGate> ROTeslas = TeslasValue.AsReadOnly();

        private static FemurBreakerButton femur;

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

        public static void SpawnItem(ItemType item, Vector3 position, Quaternion rotation)
        {
            DatabaseManager.Spawn(Object.Instantiate(ItemDB.DataBase.PrefabDB[(int)item], position, rotation));
        }

        public static FemurBreakerButton FemurBreakerButton
        {
            get
            {
                if (femur == null)
                {
                    femur = Object.FindObjectOfType<FemurBreakerButton>();
                }
                return femur;
            }
        }

        public static FemurBreakerControl FemurBreaker => FemurBreakerButton.control;

        public static Scp106RecontainmentStatus Scp106RecontainmentStatus
        {
            get => FemurBreaker.NetworkrecontainmentStatus;
            set
            {
                FemurBreaker.NetworkrecontainmentStatus = value;
            }
        }

        public static bool IsScp106Recontained => FemurBreaker.recontained;
    }
}