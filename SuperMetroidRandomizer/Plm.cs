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

    public delegate bool Access(List<ItemType> have);

    public class Plm
    {
        public string Name { get; set; }
        public long Address { get; set; }
        public ItemStorageType ItemStorageType { get; set; }
        public Access CanAccess { get; set; }
        public Item Item { get; set; }
        
        public Plm()
        {
            ItemStorageType = ItemStorageType.Normal;
        }
    }
}
