using System;
using System.Collections;
using System.IO;
using System.Linq;
using SuperMetroidRandomizer.IO;
using SuperMetroidRandomizer.Properties;
using SuperMetroidRandomizer.Rom;

namespace SuperMetroidRandomizer.Random
{
    public class RandomizerV10
    {
        private static readonly SeedRandom random = new SeedRandom();

        private const int ETANK_POS = 0;
        private const int MISSILE_POS = 1;
        private const int SUPER_POS = 2;
        private const int POWERBOMB_POS = 3;

        //private const int BOMB_ADDR = 0x78404;
        private const int RESREVE_BRINSTAR_ADDR = 0x7852c;
        private const int CHARGE_ADDR = 0x78614;
        //private const int MORPH_ADDR = 0x786de;
        private const int XRAY_ADDR = 0x78876;
        private const int SPAZER_ADDR = 0x7896e;
        private const int VARIA_ADDR = 0x78aca;
        private const int ICE_ADDR = 0x78b24;
        private const int HIJUMP_ADDR = 0x78bac;
        private const int GRAPPLE_ADDR = 0x78c36;
        private const int RESERVE_NORFAIR_ADDR = 0x78c3e;
        private const int SPEED_ADDR = 0x78c82;
        private const int WAVE_ADDR = 0x78cca;
        private const int SCREW_ADDR = 0x79110;
        private const int RESERVE_WS_ADDR = 0x7c2e9;
        private const int GRAVITY_ADDR = 0x7c36d;
        private const int PLASMA_ADDR = 0x7c559;
        private const int RESERVE_MARIDIA_ADDR = 0x7c5e3;
        private const int SPRING_ADDR = 0x7c6e5;
        private const int SPACE_JUMP_ADDR = 0x7c7a7;

        private const int EXTRA_CHOZO_PB_ADDR = 0x784ac;

        private const int SEG1_START = 0x78000;
        private const int SEG1_END = 0x79192;
        private const int SEG2_START = 0x7c215;
        private const int SEG2_END = 0x7c7bb;

        private const string ETANK = "\xd7\xee";
        private const string MISSILE = "\xdb\xee";
        private const string SUPER = "\xdf\xee";
        private const string PB = "\xe3\xee";
        //private const string BOMBS = "\xe7\xee";
        //private const string CHARGE = "\xeb\xee";
        //private const string ICE = "\xef\xee";
        //private const string HIJUMP = "\xf3\xee";
        //private const string SPEED_BOOSTER = "\xf7\xee";
        //private const string WAVE_BEAM = "\xfb\xee";
        //private const string SPAZER = "\xff\xee";
        //private const string SPRING = "\x03\xef";
        //private const string VARIA = "\x07\xef";
        //private const string PLASMA = "\x13\xef";
        //private const string GRAPPLE = "\x17\xef";
        //private const string MORPHBALL = "\x23\xef";
        //private const string RESERVE = "\x27\xef";
        //private const string GRAVITY = "\x0b\xef";
        //private const string XRAY = "\x0f\xef";
        //private const string SPACE_JUMP = "\x1b\xef";
        //private const string SCREW_ATTACK = "\x1f\xef";
        private const string CHOZO_ETANK = "\x2b\xef";
        private const string CHOZO_MISSILE = "\x2f\xef";
        private const string CHOZO_SUPER = "\x33\xef";
        private const string CHOZO_PB = "\x37\xef";
        //private const string CHOZO_BOMB = "\x3b\xef";
        private const string CHOZO_CHARGE = "\x3f\xef";
        private const string CHOZO_ICE = "\x43\xef";
        private const string CHOZO_HIJUMP = "\x47\xef";
        private const string CHOZO_SPEED = "\x4b\xef";
        private const string CHOZO_WAVE = "\x4f\xef";
        private const string CHOZO_SPAZER = "\x53\xef";
        private const string CHOZO_SPRING = "\x57\xef";
        private const string CHOZO_VARIA = "\x5b\xef";
        private const string CHOZO_GRAVITY = "\x5f\xef";
        private const string CHOZO_XRAY = "\x63\xef";
        private const string CHOZO_PLASMA = "\x67\xef";
        private const string CHOZO_GRAPPLE = "\x6b\xef";
        private const string CHOZO_SPACE_JUMP = "\x6f\xef";
        private const string CHOZO_SCREW_ATTACK = "\x73\xef";
        //private const string CHOZO_MORPH = "\x77\xef";
        private const string CHOZO_RESERVE = "\x7b\xef";
        private const string HIDDEN_ETANK = "\x7f\xef";
        private const string HIDDEN_MISSILE = "\x83\xef";
        private const string HIDDEN_SUPER = "\x87\xef";
        private const string HIDDEN_PB = "\x8b\xef";
        //private const string HIDDEN_BOMBS = "\x8f\xef";
        //private const string HIDDEN_CHARGE = "\x93\xef";
        //private const string HIDDEN_ICE = "\x97\xef";
        //private const string HIDDEN_SPEED = "\x9f\xef";
        //private const string HIDDEN_WAVE = "\xa3\xef";
        //private const string HIDDEN_SPAZER = "\xa7\xef";
        //private const string HIDDEN_SPRING = "\xab\xef";
        //private const string HIDDEN_VARIA = "\xaf\xef";
        //private const string HIDDEN_GRAV = "\xb3\xef";
        //private const string HIDDEN_XRAY = "\xb7\xef";
        //private const string HIDDEN_PLASMA = "\xbb\xef";
        //private const string HIDDEN_GRAPPLE = "\xbf\xef";
        //private const string HIDDEN_SPACE = "\xc3\xef";
        //private const string HIDDEN_MORPH = "\xc7\xef";
        //private const string HIDDEN_RESERVE = "\xcf\xef";

        // Item pickups
        readonly string[] pickups = { ETANK, MISSILE, SUPER, PB };
        readonly string[] chozoPickups = { CHOZO_ETANK, CHOZO_MISSILE, CHOZO_SUPER, CHOZO_PB };
        readonly string[] hiddenPickups = { HIDDEN_ETANK, HIDDEN_MISSILE, HIDDEN_SUPER, HIDDEN_PB };

        public Suitless IsSuitless { get; set; }

        int[] items = new int[77];
        int itemsPos;

        // Major items
        string[] majorItems = { CHOZO_CHARGE, CHOZO_ICE, CHOZO_HIJUMP, CHOZO_SPEED, CHOZO_WAVE, CHOZO_SPAZER, CHOZO_SPRING, CHOZO_VARIA, CHOZO_GRAVITY, CHOZO_XRAY, CHOZO_PLASMA, CHOZO_GRAPPLE, CHOZO_SPACE_JUMP, CHOZO_SCREW_ATTACK, CHOZO_RESERVE, CHOZO_RESERVE, CHOZO_RESERVE, CHOZO_RESERVE };
        
        public string CreateRom(string filename, string seed)
        {
            itemsPos = 0;

            if (string.IsNullOrWhiteSpace(seed))
            {
                GenerateItemList();
            }
            else
            {
                ParseSeed(seed);
            }

            var rom = new FileStream(FileName.Fix(filename, GetSeed()), FileMode.OpenOrCreate);
            rom.Write(Resources.RomImage, 0, 3145728);

            WriteMajorItems(ref rom);

            WriteMinorItems(ref rom);

            //Handle the Etecoon's item
            rom.Seek(EXTRA_CHOZO_PB_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, chozoPickups[items[itemsPos]]);

            WriteControls(rom);

            rom.Close();

            return GetSeed();
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

        private void ParseSeed(string seed)
        {
            if (seed.Length == 38)
                seed += "M";
            var parseSeed = seed.Replace('-', '/') + "=";

            var bytes = Convert.FromBase64String(parseSeed);
            var bits = new BitArray(bytes);
            int arrayLoc = 0;

            for (int i = 0; i < majorItems.Length; i++)
            {
                majorItems[i] = ReadMajorItem(bits, arrayLoc);
                arrayLoc += 4;
            }
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = ReadMinorItem(bits, arrayLoc);
                arrayLoc += 2;
            }
        }

        public bool RequiresSuitless()
        {
            return InMaridia(CHOZO_GRAVITY);
        }

        public bool LikelyImpossible()
        {
            return !ItemsOkay();
        }

        private static int ReadMinorItem(BitArray bits, int arrayLoc)
        {
            if (!bits[arrayLoc] && !bits[arrayLoc + 1])
                return 0;
            if (!bits[arrayLoc] && bits[arrayLoc + 1])
                return 1;
            if (bits[arrayLoc] && !bits[arrayLoc + 1])
                return 2;
            if (bits[arrayLoc] && bits[arrayLoc + 1])
                return 3;
            return 0;
        }

        private static string ReadMajorItem(BitArray bits, int arrayLoc)
        {
            if (!bits[arrayLoc] && !bits[arrayLoc + 1] && !bits[arrayLoc + 2] && !bits[arrayLoc + 3])
                return CHOZO_CHARGE;
            if (!bits[arrayLoc] && !bits[arrayLoc + 1] && !bits[arrayLoc + 2] && bits[arrayLoc + 3])
                return CHOZO_ICE;
            if (!bits[arrayLoc] && !bits[arrayLoc + 1] && bits[arrayLoc + 2] && !bits[arrayLoc + 3])
                return CHOZO_HIJUMP;
            if (!bits[arrayLoc] && !bits[arrayLoc + 1] && bits[arrayLoc + 2] && bits[arrayLoc + 3])
                return CHOZO_SPEED;
            if (!bits[arrayLoc] && bits[arrayLoc + 1] && !bits[arrayLoc + 2] && !bits[arrayLoc + 3])
                return CHOZO_WAVE;
            if (!bits[arrayLoc] && bits[arrayLoc + 1] && !bits[arrayLoc + 2] && bits[arrayLoc + 3])
                return CHOZO_SPAZER;
            if (!bits[arrayLoc] && bits[arrayLoc + 1] && bits[arrayLoc + 2] && !bits[arrayLoc + 3])
                return CHOZO_SPRING;
            if (!bits[arrayLoc] && bits[arrayLoc + 1] && bits[arrayLoc + 2] && bits[arrayLoc + 3])
                return CHOZO_VARIA;
            if (bits[arrayLoc] && !bits[arrayLoc + 1] && !bits[arrayLoc + 2] && !bits[arrayLoc + 3])
                return CHOZO_GRAVITY;
            if (bits[arrayLoc] && !bits[arrayLoc + 1] && !bits[arrayLoc + 2] && bits[arrayLoc + 3])
                return CHOZO_XRAY;
            if (bits[arrayLoc] && !bits[arrayLoc + 1] && bits[arrayLoc + 2] && !bits[arrayLoc + 3])
                return CHOZO_PLASMA;
            if (bits[arrayLoc] && !bits[arrayLoc + 1] && bits[arrayLoc + 2] && bits[arrayLoc + 3])
                return CHOZO_GRAPPLE;
            if (bits[arrayLoc] && bits[arrayLoc + 1] && !bits[arrayLoc + 2] && !bits[arrayLoc + 3])
                return CHOZO_SPACE_JUMP;
            if (bits[arrayLoc] && bits[arrayLoc + 1] && !bits[arrayLoc + 2] && bits[arrayLoc + 3])
                return CHOZO_SCREW_ATTACK;
            if (bits[arrayLoc] && bits[arrayLoc + 1] && bits[arrayLoc + 2] && !bits[arrayLoc + 3])
                return CHOZO_RESERVE;
            return CHOZO_CHARGE;
        }

        private string GetSeed()
        {
            var bits = new BitArray(226);
            int arrayLoc = 0;

            foreach (var item in majorItems)
            {
                WriteArrayValue(ref bits, arrayLoc, item);
                arrayLoc += 4;
            }
            foreach (var item in items)
            {
                WriteArrayValue(ref bits, arrayLoc, item);
                arrayLoc += 2;
            }

            var bytes = new byte[29];
            bits.CopyTo(bytes, 0);
            //make seed printable in a filename and remove the = at the end.
            return Convert.ToBase64String(bytes).Substring(0, 39).Replace('/', '-');
        }

        private static void WriteArrayValue(ref BitArray bits, int arrayLoc, int item)
        {
            if (item == 0)
            {
                bits[arrayLoc] = false;
                bits[arrayLoc + 1] = false;
            }
            if (item == 1)
            {
                bits[arrayLoc] = false;
                bits[arrayLoc + 1] = true;
            }
            if (item == 2)
            {
                bits[arrayLoc] = true;
                bits[arrayLoc + 1] = false;
            }
            if (item == 3)
            {
                bits[arrayLoc] = true;
                bits[arrayLoc + 1] = true;
            }
        }

        private static void WriteArrayValue(ref BitArray bits, int arrayLoc, string item)
        {
            if (item == CHOZO_CHARGE)
            {
                bits[arrayLoc] = false;
                bits[arrayLoc + 1] = false;
                bits[arrayLoc + 2] = false;
                bits[arrayLoc + 3] = false;
            }
            if (item == CHOZO_ICE)
            {
                bits[arrayLoc] = false;
                bits[arrayLoc + 1] = false;
                bits[arrayLoc + 2] = false;
                bits[arrayLoc + 3] = true;
            }
            if (item == CHOZO_HIJUMP)
            {
                bits[arrayLoc] = false;
                bits[arrayLoc + 1] = false;
                bits[arrayLoc + 2] = true;
                bits[arrayLoc + 3] = false;
            }
            if (item == CHOZO_SPEED)
            {
                bits[arrayLoc] = false;
                bits[arrayLoc + 1] = false;
                bits[arrayLoc + 2] = true;
                bits[arrayLoc + 3] = true;
            }
            if (item == CHOZO_WAVE)
            {
                bits[arrayLoc] = false;
                bits[arrayLoc + 1] = true;
                bits[arrayLoc + 2] = false;
                bits[arrayLoc + 3] = false;
            }
            if (item == CHOZO_SPAZER)
            {
                bits[arrayLoc] = false;
                bits[arrayLoc + 1] = true;
                bits[arrayLoc + 2] = false;
                bits[arrayLoc + 3] = true;
            }
            if (item == CHOZO_SPRING)
            {
                bits[arrayLoc] = false;
                bits[arrayLoc + 1] = true;
                bits[arrayLoc + 2] = true;
                bits[arrayLoc + 3] = false;
            }
            if (item == CHOZO_VARIA)
            {
                bits[arrayLoc] = false;
                bits[arrayLoc + 1] = true;
                bits[arrayLoc + 2] = true;
                bits[arrayLoc + 3] = true;
            }
            if (item == CHOZO_GRAVITY)
            {
                bits[arrayLoc] = true;
                bits[arrayLoc + 1] = false;
                bits[arrayLoc + 2] = false;
                bits[arrayLoc + 3] = false;
            }
            if (item == CHOZO_XRAY)
            {
                bits[arrayLoc] = true;
                bits[arrayLoc + 1] = false;
                bits[arrayLoc + 2] = false;
                bits[arrayLoc + 3] = true;
            }
            if (item == CHOZO_PLASMA)
            {
                bits[arrayLoc] = true;
                bits[arrayLoc + 1] = false;
                bits[arrayLoc + 2] = true;
                bits[arrayLoc + 3] = false;
            }
            if (item == CHOZO_GRAPPLE)
            {
                bits[arrayLoc] = true;
                bits[arrayLoc + 1] = false;
                bits[arrayLoc + 2] = true;
                bits[arrayLoc + 3] = true;
            }
            if (item == CHOZO_SPACE_JUMP)
            {
                bits[arrayLoc] = true;
                bits[arrayLoc + 1] = true;
                bits[arrayLoc + 2] = false;
                bits[arrayLoc + 3] = false;
            }
            if (item == CHOZO_SCREW_ATTACK)
            {
                bits[arrayLoc] = true;
                bits[arrayLoc + 1] = true;
                bits[arrayLoc + 2] = false;
                bits[arrayLoc + 3] = true;
            }
            if (item == CHOZO_RESERVE)
            {
                bits[arrayLoc] = true;
                bits[arrayLoc + 1] = true;
                bits[arrayLoc + 2] = true;
                bits[arrayLoc + 3] = false;
            }
        }

        private void WriteMinorItems(ref FileStream rom)
        {
            rom.Seek(SEG1_START, SeekOrigin.Begin);
            while (rom.Position < SEG1_END)
                WriteMinorItem(ref rom);
            rom.Seek(SEG2_START, SeekOrigin.Begin);
            while (rom.Position != SEG2_END)
                WriteMinorItem(ref rom);
        }

        private bool ItemsOkay()
        {
            //keep speed from spawning behind speed blocks
            if (AtWsReserve(CHOZO_SPEED))
                return false;

            //keep gravity from spawning at Spring Ball spot
            if (AtSpringball(CHOZO_GRAVITY))
                return false;

            //keep gravity and hi-jump from both being in Maridia or LN
            if ((AtScrewAttack(CHOZO_HIJUMP) || InMaridia(CHOZO_HIJUMP)) && (AtScrewAttack(CHOZO_GRAVITY) || InMaridia(CHOZO_GRAVITY)))
                return false;

            //both ice and speed can't appear behind Draygon
            if ((BehindDraygon(CHOZO_SPEED) && BehindDraygon(CHOZO_ICE)) || BehindDraygon(CHOZO_SPEED) && AtWsReserve(CHOZO_ICE))
                return false;

            //This scenario could lead to bad times
            if ((InMaridia(CHOZO_SPEED) || AtScrewAttack(CHOZO_SPEED)) && (AtWsReserve(CHOZO_XRAY) || AtWsReserve(CHOZO_ICE) || AtWsReserve(CHOZO_GRAPPLE) || AtWsReserve(CHOZO_HIJUMP)))
                return false;

            //handle suitless
            if (IsSuitless == Suitless.Possible || IsSuitless == Suitless.Forced)
            {
                //X-Ray, Ice, Grapple, and Hi-Jump should appear outside of Maridia
                if (InMaridia(CHOZO_XRAY) || InMaridia(CHOZO_ICE) || InMaridia(CHOZO_GRAPPLE) || InMaridia(CHOZO_HIJUMP))
                    return false;

                if (IsSuitless == Suitless.Forced)
                {
                    //make Gravity a reward for killing Draygon.
                    if (!BehindDraygon(CHOZO_GRAVITY))
                        return false;
                }
            }
            else
            {
                //Gravity shouldn't spawn in Maridia
                if (InMaridia(CHOZO_GRAVITY))
                    return false;

                //Can't trap gravity or Hi-Jump behind speed blocks if speed is also in Maridia
                if (InMaridia(CHOZO_SPEED) && (AtWsReserve(CHOZO_GRAVITY) || AtWsReserve(CHOZO_HIJUMP)))
                    return false;
            }

            return true;
        }

        private bool AtWsReserve(string item)
        {
            return majorItems[12] == item;
        }

        private bool AtScrewAttack(string item)
        {
            return majorItems[11] == item;
        }

        private bool AtSpringball(string item)
        {
            return majorItems[16] == item;
        }

        private bool BehindDraygon(string item)
        {
            return majorItems[14] == item || majorItems[17] == item;
        }

        private bool InMaridia(string item)
        {
            return majorItems[14] == item || majorItems[15] == item || majorItems[16] == item || majorItems[17] == item;
        }

        private void WriteMajorItems(ref FileStream rom)
        {
            rom.Seek(RESREVE_BRINSTAR_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[0]);
            rom.Seek(CHARGE_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[1]);
            rom.Seek(XRAY_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[2]);
            rom.Seek(SPAZER_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[3]);
            rom.Seek(VARIA_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[4]);
            rom.Seek(ICE_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[5]);
            rom.Seek(HIJUMP_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[6]);
            rom.Seek(GRAPPLE_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[7]);
            rom.Seek(RESERVE_NORFAIR_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[8]);
            rom.Seek(SPEED_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[9]);
            rom.Seek(WAVE_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[10]);
            rom.Seek(SCREW_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[11]);
            rom.Seek(RESERVE_WS_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[12]);
            rom.Seek(GRAVITY_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[13]);
            rom.Seek(PLASMA_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[14]);
            rom.Seek(RESERVE_MARIDIA_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[15]);
            rom.Seek(SPRING_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[16]);
            rom.Seek(SPACE_JUMP_ADDR + 2, SeekOrigin.Begin);
            WriteItem(ref rom, majorItems[17]);
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

        private void WriteMinorItem(ref FileStream rom)
        {
            var location = new byte[2];
            rom.Read(location, 0, 2);

            if (pickups.Any(c => location[0] == c[0] && location[1] == c[1]))
            {
                WriteItem(ref rom, pickups[items[itemsPos]]);
                itemsPos++;
                return;
            }

            if (hiddenPickups.Any(c => location[0] == c[0] && location[1] == c[1]))
            {
                WriteItem(ref rom, hiddenPickups[items[itemsPos]]);
                itemsPos++;
            }
        }

        private static void WriteItem(ref FileStream rom, string item)
        {
            var newItem = StringToByteArray(item);
            rom.Seek(-2, SeekOrigin.Current);
            rom.Write(newItem, 0, 2);
        }

        private void GenerateItemList()
        {
            for (int i = 0; i < 6; i++)
                items[i] = ETANK_POS;
            for (int i = 6; i < 15; i += 3)
            {
                items[i] = MISSILE_POS;
                items[i + 1] = SUPER_POS;
                items[i + 2] = POWERBOMB_POS;
            }
            for (int i = 15; i < items.Length; i++)
            {
                items[i] = random.Next(4);
            }

            ShuffleArray(ref items);

            do
            {
                ShuffleArray(ref majorItems);
            } while (!ItemsOkay());
        }

        private static void ShuffleArray(ref int[] items)
        {
            items = items.OrderBy(a => Guid.NewGuid()).ToArray();
        }

        private static void ShuffleArray(ref string[] items)
        {
            items = items.OrderBy(a => Guid.NewGuid()).ToArray();
        }

    }
}
