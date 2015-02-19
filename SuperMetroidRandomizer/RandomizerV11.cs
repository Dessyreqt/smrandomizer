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
            if (filename.Contains("\\") && !Directory.Exists(filename.Substring(0, filename.LastIndexOf('\\'))))
                Directory.CreateDirectory(filename.Substring(0, filename.LastIndexOf('\\')));

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

                var noHidden = new List<string>
                                   {
                                       "morphing ball",
                                       "energy tank (crateria tunnel to brinstar)",
                                       "missile (gravity suit)",
                                       "missile (crateria moat)",
                                       "missile (green maridia shinespark)",
                                   };


                if (!noHidden.Contains(plm.Name) && plm.Item.Type != ItemType.Nothing && plm.Item.Type != ItemType.ChargeBeam && plm.ItemStorageType == ItemStorageType.Normal)
                {
                    // hide the item half of the time (to be a jerk)
                    if (random.Next(2) == 0)
                    {
                        plm.ItemStorageType = ItemStorageType.Hidden;
                    }
                }

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

                if (plm.Item.Type == ItemType.Nothing)
                {
                    // give same index as morph ball
                    rom.Seek(plm.Address + 4, SeekOrigin.Begin);
                    rom.Write(StringToByteArray("\x1a"), 0, 1);
                }

                if (plm.Item.Type == ItemType.ChargeBeam)
                {
                    // we have 4 copies of charge to reduce tedium, give them all the same index
                    rom.Seek(plm.Address + 4, SeekOrigin.Begin);
                    rom.Write(StringToByteArray("\xff"), 0, 1);
                }
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
                               ItemType.ChargeBeam,
                               ItemType.ChargeBeam,
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
                               ItemType.Missile,
                               ItemType.Missile,
                               ItemType.Missile,
                               ItemType.Missile,
                               ItemType.Missile,
                               ItemType.Missile,
                               ItemType.Missile,
                               ItemType.SuperMissile,
                               ItemType.SuperMissile,
                               ItemType.SuperMissile,
                               ItemType.SuperMissile,
                               ItemType.SuperMissile,
                               ItemType.SuperMissile,
                               ItemType.PowerBomb,
                               ItemType.PowerBomb,
                               ItemType.PowerBomb,
                               ItemType.PowerBomb,
                               ItemType.EnergyTank,
                               ItemType.EnergyTank,
                               ItemType.EnergyTank,
                               ItemType.EnergyTank,
                               ItemType.EnergyTank,
                               ItemType.EnergyTank,
                               ItemType.EnergyTank,
                           };

            for (int i = itemPool.Count; i < 100; i++)
            {
                itemPool.Add(ItemType.Nothing);
            }
        }
    }
}
