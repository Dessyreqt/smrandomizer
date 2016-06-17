using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SuperMetroidRandomizer.Net;
using SuperMetroidRandomizer.Rom;

namespace SuperMetroidRandomizer.IO
{
    public class RandomizerLog
    {
        private readonly List<Location> generatedItems;
        private readonly List<Location> orderedItems;
        private readonly string seed;

        public RandomizerLog(string seed)
        {
            generatedItems = new List<Location>();
            orderedItems = new List<Location>();
            this.seed = seed;
        }

        public void AddOrderedItem(Location location)
        {
            orderedItems.Add(location);
        }

        public void AddGeneratedItems(List<Location> locations)
        {
            generatedItems.AddRange(locations);        
        }

        public void WriteLog(string filename)
        {
            using (var writer = new StreamWriter(string.Format("{0}.spoilers.txt", filename)))
            {
                writer.Write(GetLogOutput());
            }
        }

        public string GetLogOutput()
        {
            var writer = new StringBuilder();

            writer.AppendLine("Super Metroid Randomizer Log");
            writer.AppendLine("----------------------------");
            writer.AppendLine(string.Format("Version: {0}", RandomizerVersion.CurrentDisplay));
            writer.AppendLine(string.Format("Creation Date: {0}", DateTime.Now));
            writer.AppendLine(string.Format("Seed: {0}", seed));
            writer.AppendLine();
            writer.AppendLine("Generated Item Order");
            writer.AppendLine("--------------------");
            foreach (var location in orderedItems)
            {
                writer.AppendLine(string.Format("{0}{1}", location.Name.PadRight(47, '.'), GetItemName(location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine();
            writer.AppendLine();
            writer.AppendLine("Crateria");
            writer.AppendLine("--------");
            foreach (var location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.Crateria))
            {
                writer.AppendLine(string.Format("{0}{1}", location.Name.PadRight(47, '.'), GetItemName(location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine("Brinstar");
            writer.AppendLine("--------");
            foreach (var location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.Brinstar))
            {
                writer.AppendLine(string.Format("{0}{1}", location.Name.PadRight(47, '.'), GetItemName(location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine("Norfair");
            writer.AppendLine("-------");
            foreach (var location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.Norfair))
            {
                writer.AppendLine(string.Format("{0}{1}", location.Name.PadRight(47, '.'), GetItemName(location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine("Wrecked Ship");
            writer.AppendLine("------------");
            foreach (var location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.WreckedShip))
            {
                writer.AppendLine(string.Format("{0}{1}", location.Name.PadRight(47, '.'), GetItemName(location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine("Maridia");
            writer.AppendLine("-------");
            foreach (var location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.Maridia))
            {
                writer.AppendLine(string.Format("{0}{1}", location.Name.PadRight(47, '.'), GetItemName(location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine("Lower Norfair");
            writer.AppendLine("-------------");
            foreach (var location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.LowerNorfair))
            {
                writer.AppendLine(string.Format("{0}{1}", location.Name.PadRight(47, '.'), GetItemName(location.Item)));
            }

            return writer.ToString();
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
