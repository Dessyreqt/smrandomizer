using System.Collections.Generic;
using System.IO;
using SuperMetroidRandomizer.IO;
using SuperMetroidRandomizer.Net;
using SuperMetroidRandomizer.Properties;
using SuperMetroidRandomizer.Rom;

namespace SuperMetroidRandomizer.Random
{
    public enum RandomizerDifficulty
    {
        Casual = 0,
        Speedrunner = 1,
        Masochist = 2,
        Insane = 3,
    }

    public class RandomizerV11
    {
        private static SeedRandom random;
        private List<ItemType> haveItems;
        private List<ItemType> itemPool;
        private readonly int seed;
        private readonly IRomPlms romPlms;
        private RandomizerLog log;

	    public RandomizerV11(int seed, IRomPlms romPlms, RandomizerLog log)
        {
            random = new SeedRandom(seed);
            this.romPlms = romPlms;
            this.seed = seed;
            this.log = log;
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
            string usedFilename = FileName.Fix(filename, string.Format(romPlms.SeedFileString, seed));
            var hidePlms = !(romPlms is RomPlmsCasual);

            using (var rom = new FileStream(usedFilename, FileMode.OpenOrCreate))
            {
                rom.Write(Resources.RomImage, 0, 3145728);

                foreach (var plm in romPlms.Plms)
                {
                    rom.Seek(plm.Address, SeekOrigin.Begin);
                    var newItem = new byte[2];

                    if (!plm.NoHidden && plm.Item.Type != ItemType.Nothing && plm.Item.Type != ItemType.ChargeBeam && plm.ItemStorageType == ItemStorageType.Normal)
                    {
                        // hide the item half of the time (to be a jerk)
                        if (hidePlms && random.Next(2) == 0)
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

                WriteSeedInRom(rom);
                WriteControls(rom);

                rom.Close();
            }

            if (log != null)
            {
                log.WriteLog(usedFilename);
            }
        }

        private void WriteControls(FileStream rom)
        {
            foreach (var address in Controller.ShotAddresses)
            {
                rom.Seek(address, SeekOrigin.Begin);

                rom.Write(StringToByteArray(Controller.Buttons[Settings.Default.ControlsShot]), 0, 2);
            }

            foreach (var address in Controller.JumpAddresses)
            {
                rom.Seek(address, SeekOrigin.Begin);

                rom.Write(StringToByteArray(Controller.Buttons[Settings.Default.ControlsJump]), 0, 2);
            }

            foreach (var address in Controller.DashAddresses)
            {
                rom.Seek(address, SeekOrigin.Begin);

                rom.Write(StringToByteArray(Controller.Buttons[Settings.Default.ControlsDash]), 0, 2);
            }

            foreach (var address in Controller.ItemSelectAddresses)
            {
                rom.Seek(address, SeekOrigin.Begin);

                rom.Write(StringToByteArray(Controller.Buttons[Settings.Default.ControlsItemSelect]), 0, 2);
            }

            foreach (var address in Controller.ItemCancelAddresses)
            {
                rom.Seek(address, SeekOrigin.Begin);

                rom.Write(StringToByteArray(Controller.Buttons[Settings.Default.ControlsItemCancel]), 0, 2);
            }

            foreach (var address in Controller.AngleUpAddresses)
            {
                rom.Seek(address, SeekOrigin.Begin);

                rom.Write(StringToByteArray(Controller.Buttons[Settings.Default.ControlsAngleUp]), 0, 2);
            }

            foreach (var address in Controller.AngleDownAddresses)
            {
                rom.Seek(address, SeekOrigin.Begin);

                rom.Write(StringToByteArray(Controller.Buttons[Settings.Default.ControlsAngleDown]), 0, 2);
            }
        }

        private void WriteSeedInRom(FileStream rom)
        {
            string seedStr = string.Format(romPlms.SeedRomString, RandomizerVersion.Current, seed.ToString().PadLeft(7, '0')).PadRight(21).Substring(0, 21);
            rom.Seek(0x7fc0, SeekOrigin.Begin);
            rom.Write(StringToByteArray(seedStr), 0, 21);
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
                var currentPlms = romPlms.GetAvailablePlms(haveItems);
                var candidateItemList = new List<ItemType>();

                // Generate candidate item list
                foreach (var candidateItem in itemPool)
                {
                    haveItems.Add(candidateItem);

                    var newPlms = romPlms.GetAvailablePlms(haveItems);

                    if (newPlms.Count > currentPlms.Count)
                    {
                        romPlms.TryInsertCandidateItem(currentPlms, candidateItemList, candidateItem);
                    }

                    haveItems.Remove(candidateItem);
                }

                // Grab an item from the candidate list if there are any, otherwise, grab a random item
                if (candidateItemList.Count > 0)
                {
                    var insertedItem = candidateItemList[random.Next(candidateItemList.Count)];

                    itemPool.Remove(insertedItem);
                    haveItems.Add(insertedItem);

                    int insertedPlm = romPlms.GetInsertedPlm(currentPlms, insertedItem, random);
                    currentPlms[insertedPlm].Item = new Item(insertedItem);

                    if (log != null)
                    {
                        log.AddOrderedItem(currentPlms[insertedPlm]);
                    }
                }
                else
                {
                    ItemType insertedItem = romPlms.GetInsertedItem(currentPlms, itemPool, random);

                    itemPool.Remove(insertedItem);
                    haveItems.Add(insertedItem);

                    int insertedPlm = romPlms.GetInsertedPlm(currentPlms, insertedItem, random);
                    currentPlms[insertedPlm].Item = new Item(insertedItem);
                }
            } while (itemPool.Count > 0);

            var unavailablePlms = romPlms.GetUnavailablePlms(haveItems);

            foreach (var unavailablePlm in unavailablePlms)
            {
                unavailablePlm.Item = new Item(ItemType.Nothing);
            }

            if (log != null)
            {
                log.AddGeneratedItems(romPlms.Plms);
            }
        }

        private void GenerateItemList()
        {
            romPlms.ResetPlms();
            haveItems = new List<ItemType>();
            itemPool = romPlms.GetItemPool(random);
            var unavailablePlms = romPlms.GetUnavailablePlms(itemPool);

            for (int i = itemPool.Count; i < 100 - unavailablePlms.Count; i++)
            {
                itemPool.Add(ItemType.Nothing);
            }
        }
    }
}
