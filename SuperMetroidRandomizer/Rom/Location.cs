using System.Collections.Generic;

namespace SuperMetroidRandomizer.Rom
{
    public enum ItemStorageType
    {
        Normal,
        Hidden,
        Chozo,
    }

    public enum Region
    {
        Crateria,
        Brinstar,
        Norfair,
        LowerNorfair,
        WreckedShip,
        Maridia,
    }

    public delegate bool Access(List<ItemType> have);

    public class Location
    {
        public string Name { get; set; }
        public long Address { get; set; }
        public ItemStorageType ItemStorageType { get; set; }
        public Access CanAccess { get; set; }
        public Item Item { get; set; }
        public Region Region { get; set; }
        public bool GravityOkay { get; set; }
        public bool NoHidden { get; set; }
        public int Weight { get; set; }
        
        public Location()
        {
            ItemStorageType = ItemStorageType.Normal;
        }
    }
}
