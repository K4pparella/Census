namespace CensusAPI.Features
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using VirtualBrightPlayz.SCP_ET;
    using VirtualBrightPlayz.SCP_ET.Items;
    using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;
    using Object = UnityEngine.Object;

    public class Map
    {
        private static readonly List<Door> DoorsValue = new List<Door>();
        public static ReadOnlyCollection<Door> RODoors = DoorsValue.AsReadOnly();

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
    }
}