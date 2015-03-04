using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMetroidRandomizer
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

    public class Plm
    {
        public string Name { get; set; }
        public long Address { get; set; }
        public ItemStorageType ItemStorageType { get; set; }
        public Access CanAccess { get; set; }
        public Access CanAccessEasy { get; set; }
        public Access CanAccessHard { get; set; }
        public Item Item { get; set; }
        public Region Region { get; set; }
        public bool GravityOkay { get; set; }
        public bool NoHidden { get; set; }
        
        public Plm()
        {
            ItemStorageType = ItemStorageType.Normal;
        }
    }
}
