using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SuperMetroidRandomizer.Net;
using SuperMetroidRandomizer.Rom;

namespace SuperMetroidRandomizer.IO
{
    public class RandomizerLog
    {
        private readonly List<Plm> generatedItems;
        private readonly List<Plm> orderedItems;
        private readonly string seed;

        public RandomizerLog(string seed)
        {
            generatedItems = new List<Plm>();
            orderedItems = new List<Plm>();
            this.seed = seed;
        }

        public void AddOrderedItem(Plm plm)
        {
            orderedItems.Add(plm);
        }

        public void AddGeneratedItems(List<Plm> plms)
        {
            generatedItems.AddRange(plms);        
        }

        public void WriteLog(string filename)
        {
            using (var writer = new StreamWriter(string.Format("{0}.spoilers.txt", filename)))
            {
                writer.WriteLine("Super Metroid Randomizer Log");
                writer.WriteLine("----------------------------");
                writer.WriteLine("Version: {0}", RandomizerVersion.CurrentDisplay);
                writer.WriteLine("Creation Date: {0}", DateTime.Now);
                writer.WriteLine("Seed: {0}", seed);
                writer.WriteLine();
                writer.WriteLine("Generated Item Order");
                writer.WriteLine("--------------------");
                foreach (var plm in orderedItems)
                {
                    writer.WriteLine("{0}{1}", plm.Name.PadRight(47, '.'), GetItemName(plm.Item));
                }
                writer.WriteLine();
                writer.WriteLine();
                writer.WriteLine();
                writer.WriteLine("Crateria");
                writer.WriteLine("--------");
                foreach (var plm in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.Crateria))
                {
                    writer.WriteLine("{0}{1}", plm.Name.PadRight(47, '.'), GetItemName(plm.Item));
                }
                writer.WriteLine();
                writer.WriteLine("Brinstar");
                writer.WriteLine("--------");
                foreach (var plm in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.Brinstar))
                {
                    writer.WriteLine("{0}{1}", plm.Name.PadRight(47, '.'), GetItemName(plm.Item));
                }
                writer.WriteLine();
                writer.WriteLine("Norfair");
                writer.WriteLine("-------");
                foreach (var plm in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.Norfair))
                {
                    writer.WriteLine("{0}{1}", plm.Name.PadRight(47, '.'), GetItemName(plm.Item));
                }
                writer.WriteLine();
                writer.WriteLine("Wrecked Ship");
                writer.WriteLine("------------");
                foreach (var plm in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.WreckedShip))
                {
                    writer.WriteLine("{0}{1}", plm.Name.PadRight(47, '.'), GetItemName(plm.Item));
                }
                writer.WriteLine();
                writer.WriteLine("Maridia");
                writer.WriteLine("-------");
                foreach (var plm in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.Maridia))
                {
                    writer.WriteLine("{0}{1}", plm.Name.PadRight(47, '.'), GetItemName(plm.Item));
                }
                writer.WriteLine();
                writer.WriteLine("Lower Norfair");
                writer.WriteLine("-------------");
                foreach (var plm in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.LowerNorfair))
                {
                    writer.WriteLine("{0}{1}", plm.Name.PadRight(47, '.'), GetItemName(plm.Item));
                }
            }
        }

        private string GetItemName(Item item)
        {
            switch (item.Type)
            {
                case ItemType.MorphingBall:
                    return "Morphing Ball";
                case ItemType.Bomb:
                    return "Bomb";
                case ItemType.ChargeBeam:
                    return "Charge Beam";
                case ItemType.Spazer:
                    return "Spazer";
                case ItemType.VariaSuit:
                    return "Varia Suit";
                case ItemType.HiJumpBoots:
                    return "Hi-Jump Boots";
                case ItemType.SpeedBooster:
                    return "Speed Booster";
                case ItemType.WaveBeam:
                    return "Wave Beam";
                case ItemType.GrappleBeam:
                    return "Grapple Beam";
                case ItemType.GravitySuit:
                    return "Gravity Suit";
                case ItemType.SpaceJump:
                    return "Space Jump";
                case ItemType.SpringBall:
                    return "Spring Ball";
                case ItemType.PlasmaBeam:
                    return "Plasma Beam";
                case ItemType.IceBeam:
                    return "Ice Beam";
                case ItemType.ScrewAttack:
                    return "Screw Attack";
                case ItemType.XRayScope:
                    return "X-Ray Scope";
                case ItemType.Missile:
                    return "Missile";
                case ItemType.SuperMissile:
                    return "Super Missile";
                case ItemType.PowerBomb:
                    return "Power Bomb";
                case ItemType.EnergyTank:
                    return "Energy Tank";
                case ItemType.ReserveTank:
                    return "Reserve Tank";
                case ItemType.Nothing:
                    return "Nothing";
                default:
                    throw new ArgumentException("Couldn't get item type!", "item");
            }
        }
    }
}
