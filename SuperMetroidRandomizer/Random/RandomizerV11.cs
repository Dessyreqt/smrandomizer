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
        None,
        Casual,
        Speedrunner,
        Masochist,
        Insane,
    }

    public class RandomizerV11
    {
        private static SeedRandom random;
        private List<ItemType> haveItems;
        private List<ItemType> itemPool;
        private readonly int seed;
        private readonly IRomLocations romLocations;
        private RandomizerLog log;

	    public RandomizerV11(int seed, IRomLocations romLocations, RandomizerLog log)
        {
            random = new SeedRandom(seed);
            this.romLocations = romLocations;
            this.seed = seed;
            this.log = log;
        }

        public string CreateRom(string filename, bool spoilerOnly = false)
        {
            if (filename.Contains("\\") && !Directory.Exists(filename.Substring(0, filename.LastIndexOf('\\'))))
            {
                Directory.CreateDirectory(filename.Substring(0, filename.LastIndexOf('\\')));
            }

            GenerateItemList();
            GenerateItemPositions();
            WriteRom(filename);

            if (spoilerOnly)
            {
                return log?.GetLogOutput();
            }

            WriteRom(filename);

            return "";
        }

        private void WriteRom(string filename)
        {
            string usedFilename = FileName.Fix(filename, string.Format(romLocations.SeedFileString, seed));
            var hideLocations = !(romLocations is RomLocationsCasual);

            using (var rom = new FileStream(usedFilename, FileMode.OpenOrCreate))
            {
                rom.Write(Resources.RomImage, 0, 3145728);

                foreach (var location in romLocations.Locations)
                {
                    rom.Seek(location.Address, SeekOrigin.Begin);
                    var newItem = new byte[2];

                    if (!location.NoHidden && location.Item.Type != ItemType.Nothing && location.Item.Type != ItemType.ChargeBeam && location.ItemStorageType == ItemStorageType.Normal)
                    {
                        // hide the item half of the time (to be a jerk)
                        if (hideLocations && random.Next(2) == 0)
                        {
                            location.ItemStorageType = ItemStorageType.Hidden;
                        }
                    }

                    switch (location.ItemStorageType)
                    {
                        case ItemStorageType.Normal:
                            newItem = StringToByteArray(location.Item.Normal);
                            break;
                        case ItemStorageType.Hidden:
                            newItem = StringToByteArray(location.Item.Hidden);
                            break;
                        case ItemStorageType.Chozo:
                            newItem = StringToByteArray(location.Item.Chozo);
                            break;
                    }

                    rom.Write(newItem, 0, 2);

                    if (location.Item.Type == ItemType.Nothing)
                    {
                        // give same index as morph ball
                        rom.Seek(location.Address + 4, SeekOrigin.Begin);
                        rom.Write(StringToByteArray("\x1a"), 0, 1);
                    }

                    if (location.Item.Type == ItemType.ChargeBeam)
                    {
                        // we have 4 copies of charge to reduce tedium, give them all the same index
                        rom.Seek(location.Address + 4, SeekOrigin.Begin);
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
            string seedStr = string.Format(romLocations.SeedRomString, RandomizerVersion.Current, seed.ToString().PadLeft(7, '0')).PadRight(21).Substring(0, 21);
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
                var currentLocations = romLocations.GetAvailableLocations(haveItems);
                var candidateItemList = new List<ItemType>();

                // Generate candidate item list
                foreach (var candidateItem in itemPool)
                {
                    haveItems.Add(candidateItem);

                    var newLocations = romLocations.GetAvailableLocations(haveItems);

                    if (newLocations.Count > currentLocations.Count)
                    {
                        romLocations.TryInsertCandidateItem(currentLocations, candidateItemList, candidateItem);
                    }

                    haveItems.Remove(candidateItem);
                }

                // Grab an item from the candidate list if there are any, otherwise, grab a random item
                if (candidateItemList.Count > 0)
                {
                    var insertedItem = candidateItemList[random.Next(candidateItemList.Count)];

                    itemPool.Remove(insertedItem);
                    haveItems.Add(insertedItem);

                    int insertedLocation = romLocations.GetInsertedLocation(currentLocations, insertedItem, random);
                    currentLocations[insertedLocation].Item = new Item(insertedItem);

                    if (log != null)
                    {
                        log.AddOrderedItem(currentLocations[insertedLocation]);
                    }
                }
                else
                {
                    ItemType insertedItem = romLocations.GetInsertedItem(currentLocations, itemPool, random);

                    itemPool.Remove(insertedItem);
                    haveItems.Add(insertedItem);

                    int insertedLocation = romLocations.GetInsertedLocation(currentLocations, insertedItem, random);
                    currentLocations[insertedLocation].Item = new Item(insertedItem);
                }
            } while (itemPool.Count > 0);

            var unavailableLocations = romLocations.GetUnavailableLocations(haveItems);

            foreach (var unavailableLocation in unavailableLocations)
            {
                unavailableLocation.Item = new Item(ItemType.Nothing);
            }

            if (log != null)
            {
                log.AddGeneratedItems(romLocations.Locations);
            }
        }

        private void GenerateItemList()
        {
            romLocations.ResetLocations();
            haveItems = new List<ItemType>();
            itemPool = romLocations.GetItemPool(random);
            var unavailableLocations = romLocations.GetUnavailableLocations(itemPool);

            for (int i = itemPool.Count; i < 100 - unavailableLocations.Count; i++)
            {
                itemPool.Add(ItemType.Nothing);
            }
        }
    }
}
