using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SuperMetroidRandomizer.Properties;

namespace SuperMetroidRandomizer
{
    public class RandomizerV11
    {
        private static SeedRandom random;
        private List<ItemType> haveItems;
        private List<ItemType> itemPool;
        private int seed;

        public Suitless IsSuitless { get; set; }

        public RandomizerV11(int seed)
        {
            random = new SeedRandom(seed);
            this.seed = seed;
        }

        public void CreateRom(string filename)
        {
            GenerateItemList();
            GenerateItemPositions();
            WriteRom(filename);
        }

        private void WriteRom(string filename)
        {
            var rom = new FileStream(filename.Replace("<seed>", string.Format("{0:0000000}", seed)), FileMode.OpenOrCreate);
            rom.Write(Resources.RomImageV11, 0, 3145728);

            foreach (var plm in RomPlms.GetRomPlms().Plms)
            {
                rom.Seek(plm.Address, SeekOrigin.Begin);
                var newItem = new byte[2];
                switch (plm.ItemStorageType)
                {
                    case ItemStorageType.Normal:
                        newItem = StringToByteArray(plm.Item.Normal);
                        break;
                    case ItemStorageType.Hidden:
                        newItem = StringToByteArray(plm.Item.Hidden);
                        break;
                    case ItemStorageType.Chozo:
                        newItem = StringToByteArray(plm.Item.Chozo);
                        break;
                }

                rom.Write(newItem, 0, 2);
            }

            rom.Close();
        }

        private static byte[] StringToByteArray(string input)
        {
            var retVal = new byte[input.Length];
            var i = 0;

            foreach (var ch in input)
            {
                retVal[i] = (byte)ch;
                i++;
            }

            return retVal;
        }

        private void GenerateItemPositions()
        {
            do
            {
                var currentPlms = RomPlms.GetRomPlms().GetAvailablePlms(haveItems);
                var candidateItemList = new List<ItemType>();

                foreach (var candidateItem in itemPool)
                {
                    haveItems.Add(candidateItem);

                    var newPlms = RomPlms.GetRomPlms().GetAvailablePlms(haveItems);

                    if (newPlms.Count > currentPlms.Count)
                        candidateItemList.Add(candidateItem);

                    haveItems.Remove(candidateItem);
                }

                if (candidateItemList.Count > 0)
                {
                    var insertedItem = candidateItemList[random.Next(candidateItemList.Count)];
                    itemPool.Remove(insertedItem);
                    haveItems.Add(insertedItem);
                    var insertedPlm = random.Next(currentPlms.Count);
                    currentPlms[insertedPlm].Item = new Item(insertedItem);
                }
                else
                {
                    var insertedItem = itemPool[random.Next(itemPool.Count)];
                    itemPool.Remove(insertedItem);
                    haveItems.Add(insertedItem);
                    var insertedPlm = random.Next(currentPlms.Count);
                    currentPlms[insertedPlm].Item = new Item(insertedItem);
                }
            } while (itemPool.Count > 0);
        }

        private void GenerateItemList()
        {
            RomPlms.GetRomPlms().ResetPlms();
            haveItems = new List<ItemType>();
            itemPool = new List<ItemType>
                           {
                               ItemType.MorphingBall,
                               ItemType.Bomb,
                               ItemType.ChargeBeam,
                               ItemType.Spazer,
                               ItemType.VariaSuit,
                               ItemType.HiJumpBoots,
                               ItemType.SpeedBooster,
                               ItemType.WaveBeam,
                               ItemType.GrappleBeam,
                               ItemType.GravitySuit,
                               ItemType.SpaceJump,
                               ItemType.SpringBall,
                               ItemType.PlasmaBeam,
                               ItemType.IceBeam,
                               ItemType.ScrewAttack,
                               ItemType.XRayScope,
                               ItemType.ReserveTank,
                               ItemType.ReserveTank,
                               ItemType.ReserveTank,
                               ItemType.ReserveTank,
                               ItemType.Missile,
                               ItemType.Missile,
                               ItemType.Missile,
                               ItemType.SuperMissile,
                               ItemType.SuperMissile,
                               ItemType.SuperMissile,
                               ItemType.PowerBomb,
                               ItemType.PowerBomb,
                               ItemType.PowerBomb,
                               ItemType.EnergyTank,
                               ItemType.EnergyTank,
                               ItemType.EnergyTank,
                               ItemType.EnergyTank,
                               ItemType.EnergyTank,
                           };

            for (int i = 0; i < 66; i++)
            {
                var nextItem = random.Next(4);
                switch (nextItem)
                {
                    case 0:
                        itemPool.Add(ItemType.Missile);
                        break;
                    case 1:
                        itemPool.Add(ItemType.SuperMissile);
                        break;
                    case 2:
                        itemPool.Add(ItemType.PowerBomb);
                        break;
                    case 3:
                        itemPool.Add(ItemType.EnergyTank);
                        break;
                }
            }

        }
    }
}
