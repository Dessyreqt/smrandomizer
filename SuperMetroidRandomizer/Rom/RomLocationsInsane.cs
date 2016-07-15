using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMetroidRandomizer.Random;

namespace SuperMetroidRandomizer.Rom
{
    public class RomLocationsInsane : IRomLocations
    {
        public List<Location> Locations { get; set; }
        public string DifficultyName { get { return "Insane"; } }
        public string SeedFileString { get { return "I{0:0000000}"; } }
        public string SeedRomString { get { return "SMRv{0} I{1}"; } }

        public void ResetLocations()
        {
            Locations = new List<Location>
                       {
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Power Bomb (Crateria surface)",
                                   Address = 0x781CC,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && (have.Contains(ItemType.SpeedBooster)
                                           || have.Contains(ItemType.SpaceJump)
                                           || CanIbj(have)),
                               },
                           new Location
                               {
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (outside Wrecked Ship bottom)",
                                   Address = 0x781E8,
                                   CanAccess =
                                       have =>
                                       CanAccessWs(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (outside Wrecked Ship top)",
                                   Address = 0x781EE,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanDefeatPhantoon(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (outside Wrecked Ship middle)",
                                   Address = 0x781F4,
                                   CanAccess =
                                       have =>
                                       CanDefeatPhantoon(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria moat)",
                                   Address = 0x78248,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile)
                                       && CanUsePowerBombs(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Energy Tank (Crateria gauntlet)",
                                   Address = 0x78264,
                                   CanAccess =
                                       have =>
                                       CanEnterAndLeaveGauntlet(have)
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria bottom)",
                                   Address = 0x783EE,
                                   CanAccess =
                                       have =>
                                       CanDestroyBombWalls(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Bomb",
                                   Address = 0x78404,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.MorphingBall) &&
                                       CanOpenMissileDoors(have)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Energy Tank (Crateria tunnel to Brinstar)",
                                   Address = 0x78432,
                                   CanAccess =
                                       have =>
                                       CanDestroyBombWalls(have)
                                       || have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria gauntlet right)",
                                   Address = 0x78464,
                                   CanAccess =
                                       have =>
                                       CanEnterAndLeaveGauntlet(have)
                                       && CanPassBombPassages(have)
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria gauntlet left)",
                                   Address = 0x7846A,
                                   CanAccess =
                                       have =>
                                       CanEnterAndLeaveGauntlet(have)
                                       && CanPassBombPassages(have)
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Super Missile (Crateria)",
                                   Address = 0x78478,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && have.Contains(ItemType.SpeedBooster)
                                       && (have.Contains(ItemType.EnergyTank)
                                           || have.Contains(ItemType.VariaSuit)
                                           || have.Contains(ItemType.GravitySuit)),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria middle)",
                                   Address = 0x78486,
                                   CanAccess =
                                       have =>
                                       CanPassBombPassages(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Power Bomb (green Brinstar bottom)",
                                   Address = 0x784AC,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Super Missile (pink Brinstar)",
                                   Address = 0x784E4,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanPassBombPassages(have)
                                       && have.Contains(ItemType.SuperMissile),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (green Brinstar below super missile)",
                                   Address = 0x78518,
                                   CanAccess =
                                       have =>
                                       CanPassBombPassages(have)
                                       && CanOpenMissileDoors(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Super Missile (green Brinstar top)",
                                   Address = 0x7851E,
                                   CanAccess =
                                       have =>
                                       CanDestroyBombWalls(have)
                                       && CanOpenMissileDoors(have)
                                       && (have.Contains(ItemType.SpeedBooster)
                                           || have.Contains(ItemType.SpeedBooster)),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Reserve Tank (Brinstar)",
                                   Address = 0x7852C,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanDestroyBombWalls(have)
                                       && CanOpenMissileDoors(have)
                                       && (have.Contains(ItemType.SpeedBooster)
                                           || have.Contains(ItemType.SpeedBooster)),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (green Brinstar behind missile)",
                                   Address = 0x78532,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanPassBombPassages(have)
                                       && CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (green Brinstar behind Reserve Tank)",
                                   Address = 0x78538,
                                   CanAccess =
                                       have =>
                                       CanDestroyBombWalls(have)
                                       && CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.SpeedBooster)
                                       && have.Contains(ItemType.MorphingBall),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (pink Brinstar top)",
                                   Address = 0x78608,
                                   CanAccess =
                                       have =>
                                       (CanDestroyBombWalls(have)
                                           && CanOpenMissileDoors(have))
                                       || CanUsePowerBombs(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (pink Brinstar bottom)",
                                   Address = 0x7860E,
                                   CanAccess =
                                       have =>
                                       (CanDestroyBombWalls(have)
                                           && CanOpenMissileDoors(have))
                                       || CanUsePowerBombs(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Charge Beam",
                                   Address = 0x78614,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       (CanPassBombPassages(have)
                                           && CanOpenMissileDoors(have))
                                       || CanUsePowerBombs(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Power Bomb (pink Brinstar)",
                                   Address = 0x7865C,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && have.Contains(ItemType.SuperMissile),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (green Brinstar pipe)",
                                   Address = 0x78676,
                                   CanAccess =
                                       have =>
                                       (CanPassBombPassages(have)
                                           && have.Contains(ItemType.SuperMissile))
                                       || CanUsePowerBombs(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Morphing Ball",
                                   Address = 0x786DE,
                                   CanAccess =
                                       have =>
                                       true,
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Power Bomb (blue Brinstar)",
                                   Address = 0x7874C,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (blue Brinstar middle)",
                                   Address = 0x78798,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.MorphingBall),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Energy Tank (blue Brinstar)",
                                   Address = 0x7879E,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Energy Tank (green Brinstar bottom)",
                                   Address = 0x787C2,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Super Missile (green Brinstar bottom)",
                                   Address = 0x787D0,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && have.Contains(ItemType.SuperMissile),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Energy Tank (pink Brinstar bottom)",
                                   Address = 0x787FA,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.SpeedBooster)
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (blue Brinstar bottom)",
                                   Address = 0x78802,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.MorphingBall),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Energy Tank (pink Brinstar top)",
                                   Address = 0x78824,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && (have.Contains(ItemType.WaveBeam)
                                           || have.Contains(ItemType.SuperMissile)),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (blue Brinstar top)",
                                   Address = 0x78836,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                                       && CanUsePowerBombs(have)
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (blue Brinstar behind missile)",
                                   Address = 0x7883C,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                                       && CanUsePowerBombs(have)
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "X-Ray Visor",
                                   Address = 0x78876,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have)
                                       && CanUsePowerBombs(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Power Bomb (red Brinstar sidehopper room)",
                                   Address = 0x788CA,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have)
                                       && CanUsePowerBombs(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Power Bomb (red Brinstar spike room)",
                                   Address = 0x7890E,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have)
                                       && CanUsePowerBombs(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (red Brinstar spike room)",
                                   Address = 0x78914,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have)
                                       && CanUsePowerBombs(have),
                               },
                           new Location
                               {
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Spazer",
                                   Address = 0x7896E,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have)
                                       && CanPassBombPassages(have)
                               },
                           new Location
                               {
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Energy Tank (Kraid)",
                                   Address = 0x7899C,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessKraid(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (Kraid)",
                                   Address = 0x789EC,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessKraid(have)
                                       && CanUsePowerBombs(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Varia Suit",
                                   Address = 0x78ACA,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessKraid(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (lava room)",
                                   Address = 0x78AE4,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Ice Beam",
                                   Address = 0x78B24,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessKraid(have)
                                       && (have.Contains(ItemType.GravitySuit)
                                           || have.Contains(ItemType.VariaSuit)
                                           || EnergyReserveCount(have) >= 2)
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (below Ice Beam)",
                                   Address = 0x78B46,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessKraid(have)
                                       && CanUsePowerBombs(have)
                                       && (have.Contains(ItemType.GravitySuit)
                                           || have.Contains(ItemType.VariaSuit)
                                           || EnergyReserveCount(have) >= 3)
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Energy Tank (Crocomire)",
                                   Address = 0x78BA4,
                                   CanAccess =
                                       have =>
                                       CanAccessCrocomire(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Norfair,
                                   Name = "Hi-Jump Boots",
                                   Address = 0x78BAC,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (above Crocomire)",
                                   Address = 0x78BC0,
                                   CanAccess =
                                       have =>
                                       CanAccessCrocomire(have)
                                       && (have.Contains(ItemType.SpaceJump)
                                           || have.Contains(ItemType.GrappleBeam)
                                           || (have.Contains(ItemType.HiJumpBoots)
                                               && have.Contains(ItemType.SpeedBooster))
                                           || CanIbj(have)),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Norfair,
                                   Name = "Missile (Hi-Jump Boots)",
                                   Address = 0x78BE6,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Norfair,
                                   Name = "Energy Tank (Hi-Jump Boots)",
                                   Address = 0x78BEC,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Power Bomb (Crocomire)",
                                   Address = 0x78C04,
                                   CanAccess =
                                       have =>
                                       CanAccessCrocomire(have)
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (below Crocomire)",
                                   Address = 0x78C14,
                                   CanAccess =
                                       have =>
                                       CanAccessCrocomire(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (Grapple Beam)",
                                   Address = 0x78C2A,
                                   CanAccess =
                                       have =>
                                       CanAccessCrocomire(have)
                                       && (have.Contains(ItemType.SpaceJump)
                                           || have.Contains(ItemType.GrappleBeam)
                                           || have.Contains(ItemType.SpeedBooster)
                                           || CanIbj(have)),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Grapple Beam",
                                   Address = 0x78C36,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessCrocomire(have)
                                       && (have.Contains(ItemType.SpaceJump)
                                           || have.Contains(ItemType.SpeedBooster)
                                           || CanIbj(have)
                                           || have.Contains(ItemType.IceBeam)),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Reserve Tank (Norfair)",
                                   Address = 0x78C3E,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have)
                                       && (have.Contains(ItemType.SpaceJump)
                                           || have.Contains(ItemType.GrappleBeam)
                                           || have.Contains(ItemType.HiJumpBoots)
                                           || CanIbj(have)),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (Norfair Reserve Tank)",
                                   Address = 0x78C44,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have)
                                       && (have.Contains(ItemType.SpaceJump)
                                           || have.Contains(ItemType.GrappleBeam)
                                           || have.Contains(ItemType.HiJumpBoots)
                                           || CanIbj(have)),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (bubble Norfair green door)",
                                   Address = 0x78C52,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have)
                                       && (have.Contains(ItemType.SpaceJump)
                                           || have.Contains(ItemType.GrappleBeam)
                                           || have.Contains(ItemType.HiJumpBoots)
                                           || CanIbj(have)),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (bubble Norfair)",
                                   Address = 0x78C66,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (Speed Booster)",
                                   Address = 0x78C74,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Speed Booster",
                                   Address = 0x78C82,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (Wave Beam)",
                                   Address = 0x78CBC,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Wave Beam",
                                   Address = 0x78CCA,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have)
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (Gold Torizo)",
                                   Address = 0x78E6E,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have)
                                       && have.Contains(ItemType.SpaceJump),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Super Missile (Gold Torizo)",
                                   Address = 0x78E74,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (Mickey Mouse room)",
                                   Address = 0x78F30,
                                   CanAccess =
                                       have =>
                                       CanPassWorstRoomInTheGame(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (lower Norfair above fire flea room)",
                                   Address = 0x78FCA,
                                   CanAccess =
                                       have =>
                                       CanPassWorstRoomInTheGame(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Power Bomb (lower Norfair above fire flea room)",
                                   Address = 0x78FD2,
                                   CanAccess =
                                       have =>
                                       CanPassWorstRoomInTheGame(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Power Bomb (above Ridley)",
                                   Address = 0x790C0,
                                   CanAccess =
                                       have =>
                                       CanPassWorstRoomInTheGame(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (lower Norfair near Wave Beam)",
                                   Address = 0x79100,
                                   CanAccess =
                                       have =>
                                       CanPassWorstRoomInTheGame(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Energy Tank (Ridley)",
                                   Address = 0x79108,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanPassWorstRoomInTheGame(have)
                                       && have.Contains(ItemType.ChargeBeam)
                                       && EnergyReserveCount(have) >= 2,
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Screw Attack",
                                   Address = 0x79110,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Energy Tank (lower Norfair fire flea room)",
                                   Address = 0x79184,
                                   CanAccess =
                                       have =>
                                       CanPassWorstRoomInTheGame(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.WreckedShip,
                                   Name = "Missile (Wrecked Ship middle)",
                                   Address = 0x7C265,
                                   CanAccess =
                                       have =>
                                       CanAccessWs(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.WreckedShip,
                                   Name = "Reserve Tank (Wrecked Ship)",
                                   Address = 0x7C2E9,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanDefeatPhantoon(have)
                                       && have.Contains(ItemType.SpeedBooster)
                                       && (have.Contains(ItemType.VariaSuit)
                                           || EnergyReserveCount(have) >= 1)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.WreckedShip,
                                   Name = "Missile (Gravity Suit)",
                                   Address = 0x7C2EF,
                                   CanAccess =
                                       have =>
                                       CanDefeatPhantoon(have)
                                       && (have.Contains(ItemType.VariaSuit)
                                           || EnergyReserveCount(have) >= 1)
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.WreckedShip,
                                   Name = "Missile (Wrecked Ship top)",
                                   Address = 0x7C319,
                                   CanAccess =
                                       have =>
                                       CanDefeatPhantoon(have)
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.WreckedShip,
                                   Name = "Energy Tank (Wrecked Ship)",
                                   Address = 0x7C337,
                                   CanAccess =
                                       have =>
                                       CanDefeatPhantoon(have)
                                       && (have.Contains(ItemType.Bomb)
                                           || have.Contains(ItemType.PowerBomb)
                                           || have.Contains(ItemType.GravitySuit)
                                           || have.Contains(ItemType.HiJumpBoots)
                                           || have.Contains(ItemType.SpaceJump)
                                           || have.Contains(ItemType.SpeedBooster)
                                           || have.Contains(ItemType.SpringBall)),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.WreckedShip,
                                   Name = "Super Missile (Wrecked Ship left)",
                                   Address = 0x7C357,
                                   CanAccess =
                                       have =>
                                       CanDefeatPhantoon(have)
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.WreckedShip,
                                   Name = "Super Missile (Wrecked Ship right)",
                                   Address = 0x7C365,
                                   CanAccess =
                                       have =>
                                       CanDefeatPhantoon(have)
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.WreckedShip,
                                   Name = "Gravity Suit",
                                   Address = 0x7C36D,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanDefeatPhantoon(have)
                                       && (have.Contains(ItemType.VariaSuit)
                                           || EnergyReserveCount(have) >= 1)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (green Maridia shinespark)",
                                   Address = 0x7C437,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have)
                                       && CanUsePowerBombs(have)
                                       && have.Contains(ItemType.GravitySuit)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Super Missile (green Maridia)",
                                   Address = 0x7C43D,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Energy Tank (green Maridia)",
                                   Address = 0x7C47D,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have)
                                       && (have.Contains(ItemType.SpeedBooster)
                                           || have.Contains(ItemType.GrappleBeam)
                                           || have.Contains(ItemType.SpaceJump)
                                           || CanIbj(have)
                                           || (have.Contains(ItemType.SpaceJump)
                                               && have.Contains(ItemType.SpringBall))),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (green Maridia tatori)",
                                   Address = 0x7C483,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Super Missile (yellow Maridia)",
                                   Address = 0x7C4AF,
                                   CanAccess =
                                       have =>
                                       CanAccessInnerMaridia(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (yellow Maridia super missile)",
                                   Address = 0x7C4B5,
                                   CanAccess =
                                       have =>
                                       CanAccessInnerMaridia(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (yellow Maridia false wall)",
                                   Address = 0x7C533,
                                   CanAccess =
                                       have =>
                                       CanAccessInnerMaridia(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Plasma Beam",
                                   Address = 0x7C559,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanDefeatDraygon(have)
                                       && have.Contains(ItemType.ChargeBeam),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (left Maridia sand pit room)",
                                   Address = 0x7C5DD,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Reserve Tank (Maridia)",
                                   Address = 0x7C5E3,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (right Maridia sand pit room)",
                                   Address = 0x7C5EB,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Power Bomb (right Maridia sand pit room)",
                                   Address = 0x7C5F1,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have)
                                       && have.Contains(ItemType.GravitySuit),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (pink Maridia)",
                                   Address = 0x7C603,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have)
                                       && have.Contains(ItemType.GravitySuit)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Super Missile (pink Maridia)",
                                   Address = 0x7C609,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have)
                                       && have.Contains(ItemType.GravitySuit)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Spring Ball",
                                   Address = 0x7C6E5,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have)
                                       && have.Contains(ItemType.GravitySuit)
                                       && (have.Contains(ItemType.IceBeam)
                                           || have.Contains(ItemType.GrappleBeam)),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (Draygon)",
                                   Address = 0x7C74D,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanDefeatBotwoon(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Energy Tank (Botwoon)",
                                   Address = 0x7C755,
                                   CanAccess =
                                       have =>
                                       CanDefeatBotwoon(have),
                               },
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Space Jump",
                                   Address = 0x7C7A7,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanDefeatDraygon(have),
                               },
                       };
        }

        private bool CanPassWorstRoomInTheGame(List<ItemType> have)
        {
            return CanAccessLowerNorfair(have)
                   && (have.Contains(ItemType.SpaceJump)
                       || have.Contains(ItemType.HiJumpBoots)
                       || have.Contains(ItemType.IceBeam)
                       || CanIbj(have));
        }

        private bool CanIbj(List<ItemType> have)
        {
            return (have.Contains(ItemType.Bomb)
                && have.Contains(ItemType.MorphingBall));
        }

        private bool CanDefeatDraygon(List<ItemType> have)
        {
            return CanDefeatBotwoon(have)
                && (have.Contains(ItemType.GravitySuit)
                    || ((have.Contains(ItemType.GrappleBeam)
                            || CanCrystalFlash(have))
                        && (have.Contains(ItemType.SpringBall)
                            || have.Contains(ItemType.XRayScope))));
        }

        private bool CanCrystalFlash(List<ItemType> have)
        {
            return have.Count(x => x == ItemType.Missile) >= 2
                && have.Count(x => x == ItemType.SuperMissile) >= 2
                && have.Count(x => x == ItemType.PowerBomb) >= 3;
        }

        private bool CanDefeatBotwoon(List<ItemType> have)
        {
            return CanAccessInnerMaridia(have)
                && (have.Contains(ItemType.IceBeam)
                    || have.Contains(ItemType.SpeedBooster)
                    || CanCrystalFlash(have));
        }

        private bool CanAccessInnerMaridia(List<ItemType> have)
        {
            return CanAccessRedBrinstar(have)
                && have.Contains(ItemType.PowerBomb)
                && (have.Contains(ItemType.GravitySuit)
                    || (have.Contains(ItemType.HiJumpBoots)
                        && have.Contains(ItemType.IceBeam)
                        && have.Contains(ItemType.GrappleBeam)));
        }

        private bool CanAccessOuterMaridia(List<ItemType> have)
        {
            return CanAccessRedBrinstar(have)
                && have.Contains(ItemType.PowerBomb)
                && (have.Contains(ItemType.GravitySuit)
                    || (have.Contains(ItemType.HiJumpBoots)
                        && have.Contains(ItemType.IceBeam)));
        }

        private bool CanAccessLowerNorfair(List<ItemType> have)
        {
            return CanAccessHeatedNorfair(have)
                && have.Contains(ItemType.PowerBomb)
                && (have.Contains(ItemType.VariaSuit)
                    || have.Contains(ItemType.GravitySuit));
        }

        private bool CanAccessCrocomire(List<ItemType> have)
        {
            return CanAccessHeatedNorfair(have)
                || (CanAccessKraid(have)
                    && CanUsePowerBombs(have)
                    && have.Contains(ItemType.SpeedBooster)
                    && (have.Contains(ItemType.GravitySuit)
                        || have.Contains(ItemType.VariaSuit)
                        || EnergyReserveCount(have) >= 3));
        }

        private bool CanAccessHeatedNorfair(List<ItemType> have)
        {
            return CanAccessRedBrinstar(have)
                && (have.Contains(ItemType.VariaSuit)
                    || have.Contains(ItemType.GravitySuit)
                    || EnergyReserveCount(have) >= 3);
        }

        private static int EnergyReserveCount(List<ItemType> have)
        {
            var energyTankCount = have.Count(x => x == ItemType.EnergyTank);
            var reserveTankCount = Math.Min(have.Count(x => x == ItemType.ReserveTank), energyTankCount + 1);
            return energyTankCount + reserveTankCount;
        }

        private bool CanAccessKraid(List<ItemType> have)
        {
            return CanAccessRedBrinstar(have)
                && CanPassBombPassages(have);
        }

        private bool CanAccessRedBrinstar(List<ItemType> have)
        {
            return have.Contains(ItemType.SuperMissile)
                && ((CanDestroyBombWalls(have)
                        && have.Contains(ItemType.MorphingBall))
                    || (CanUsePowerBombs(have)));
        }

        private bool CanPassBombPassages(List<ItemType> have)
        {
            return (have.Contains(ItemType.Bomb)
                    && have.Contains(ItemType.MorphingBall))
                || (have.Contains(ItemType.PowerBomb)
                    && have.Contains(ItemType.MorphingBall));
        }

        private static bool CanUsePowerBombs(List<ItemType> have)
        {
            return have.Contains(ItemType.PowerBomb)
                && have.Contains(ItemType.MorphingBall);
        }

        private static bool CanOpenMissileDoors(List<ItemType> have)
        {
            return have.Contains(ItemType.Missile)
                || have.Contains(ItemType.SuperMissile);
        }

        private static bool CanDestroyBombWalls(List<ItemType> have)
        {
            return (have.Contains(ItemType.Bomb)
                    && have.Contains(ItemType.MorphingBall))
                || (have.Contains(ItemType.PowerBomb)
                    && have.Contains(ItemType.MorphingBall))
                || have.Contains(ItemType.ScrewAttack);
        }

        private static bool CanEnterAndLeaveGauntlet(List<ItemType> have)
        {
            return (have.Contains(ItemType.Bomb)
                    && have.Contains(ItemType.MorphingBall))
                || (have.Count(x => x == ItemType.PowerBomb) >= 2
                    && have.Contains(ItemType.MorphingBall))
                || have.Contains(ItemType.ScrewAttack);
        }

        private static bool CanDefeatPhantoon(List<ItemType> have)
        {
            return CanAccessWs(have);
        }

        private static bool CanAccessWs(List<ItemType> have)
        {
            return have.Contains(ItemType.SuperMissile)
                && CanUsePowerBombs(have);
        }

        public RomLocationsInsane()
        {
            ResetLocations();
        }

        public List<Location> GetAvailableLocations(List<ItemType> haveItems)
        {
            var retVal = (from Location location in Locations where (location.Item == null) && location.CanAccess(haveItems) select location).ToList();
            var currentWeight = (from item in retVal orderby item.Weight descending select item.Weight).First() + 1;

            foreach (var item in retVal.Where(item => item.Weight == 0))
            {
                item.Weight = currentWeight;
            }

            var addedItems = new List<List<Location>>();
            for (int i = 1; i < currentWeight; i++)
            {
                addedItems.Add(retVal.Where(x => x.Weight > i).ToList());
            }

            foreach (var list in addedItems)
            {
                retVal.AddRange(list);
            }

            return retVal;
        }

        public List<Location> GetUnavailableLocations(List<ItemType> haveItems)
        {
            return (from Location location in Locations where location.Item == null && !location.CanAccess(haveItems) select location).ToList();
        }

        public void TryInsertCandidateItem(List<Location> currentLocations, List<ItemType> candidateItemList, ItemType candidateItem)
        {
			// only try gravity if gravity is okay in this spot
			// only insert multiples of an item into the candidate list if we aren't looking at the morph ball slot.
            if (!(candidateItem == ItemType.GravitySuit && !currentLocations.Any(x => x.GravityOkay)) && (currentLocations.All(x => x.Name != "Morphing Ball") || !candidateItemList.Contains(candidateItem)))
            {
                candidateItemList.Add(candidateItem);
            }
        }

        public int GetInsertedLocation(List<Location> currentLocations, ItemType insertedItem, SeedRandom random)
        {
            int retVal;

            do
            {
                retVal = random.Next(currentLocations.Count);
            } while (insertedItem == ItemType.GravitySuit && !currentLocations[retVal].GravityOkay);

            return retVal;
        }

        public ItemType GetInsertedItem(List<Location> currentLocations, List<ItemType> itemPool, SeedRandom random)
        {
            ItemType retVal;

            do
            {
                retVal = itemPool[random.Next(itemPool.Count)];
            } while (retVal == ItemType.GravitySuit && !currentLocations.Any(x => x.GravityOkay));

            return retVal;
        }

        public List<ItemType> GetItemPool(SeedRandom random)
        {
            var coreItems = new List<ItemType>
                            {
                                ItemType.MorphingBall,
                                ItemType.Missile,
                                ItemType.SuperMissile,
                                ItemType.PowerBomb,
                                ItemType.EnergyTank,
                                ItemType.ChargeBeam,
                                ItemType.ChargeBeam,
                                ItemType.ChargeBeam,
                                ItemType.ChargeBeam,
                            };
            var possibleEnergy = new List<List<ItemType>>
                                 {
                                     new List<ItemType>
                                     {
                                         ItemType.EnergyTank,
                                         ItemType.EnergyTank,
                                     },
                                     new List<ItemType>
                                     {
                                         ItemType.EnergyTank,
                                         ItemType.ReserveTank,
                                     },
                                     new List<ItemType>
                                     {
                                         ItemType.ReserveTank,
                                         ItemType.ReserveTank,
                                     },
                                 };
            var possibleSuit = new List<List<ItemType>>
                               {
                                   new List<ItemType>
                                   {
                                       ItemType.GravitySuit,
                                   },
                                   new List<ItemType>
                                   {
                                       ItemType.VariaSuit,
                                   },
                               };
            var possibleGravity = new List<List<ItemType>>
                                       {
                                           new List<ItemType>
                                           {
                                               ItemType.IceBeam,
                                           },
                                           new List<ItemType>
                                           {
                                               ItemType.SpeedBooster,
                                           },
                                           new List<ItemType>
                                           {
                                               ItemType.PowerBomb,
                                               ItemType.PowerBomb,
                                           }
                                       };
            var possibleVaria = new List<List<ItemType>>
                                       {
                                           new List<ItemType>
                                           {
                                               ItemType.IceBeam,
                                               ItemType.HiJumpBoots,
                                               ItemType.GrappleBeam,
                                               ItemType.SpringBall,
                                           },
                                       };
            var possibleMotherBrain = new List<List<ItemType>>
                                {
                                    new List<ItemType>
                                    {
                                        ItemType.VariaSuit,
                                    },
                                    new List<ItemType>
                                    {
                                         ItemType.EnergyTank,
                                         ItemType.EnergyTank,
                                         ItemType.EnergyTank,
                                    },
                                    new List<ItemType>
                                    {
                                         ItemType.EnergyTank,
                                         ItemType.EnergyTank,
                                         ItemType.ReserveTank,
                                    },
                                };

            var retVal = new List<ItemType>();

            retVal.AddRange(coreItems);
            retVal.AddRange(possibleEnergy[random.Next(possibleEnergy.Count)]);
            retVal.AddRange(possibleSuit[random.Next(possibleSuit.Count)]);
            if (retVal.Contains(ItemType.GravitySuit))
            {
                retVal.AddRange(possibleGravity[random.Next(possibleGravity.Count)]);
            }
            else if (retVal.Contains(ItemType.VariaSuit))
            {
                retVal.AddRange(possibleVaria[random.Next(possibleVaria.Count)]);
            }

            // Enable Crystal Flash
            if (retVal.Count(item => item == ItemType.PowerBomb) == 3)
            {
                retVal.Add(ItemType.Missile);
                retVal.Add(ItemType.SuperMissile);
            }

            var zebSkip = retVal.Contains(ItemType.SpeedBooster) || retVal.Contains(ItemType.IceBeam);

            while (!AmmoOkay(retVal, zebSkip))
            {
                var missileCount = retVal.Count(item => item == ItemType.Missile);
                var superMissileCount = retVal.Count(item => item == ItemType.SuperMissile);

                var addedItem = ItemType.SuperMissile;

                if (random.Next(2) == 0)
                {
                    addedItem = ItemType.Missile;
                }

                if (zebSkip)
                {
                    if (addedItem == ItemType.Missile)
                    {
                        if (missileCount == 2 && superMissileCount == 1)
                        {
                            retVal.Add(ItemType.Missile);
                            retVal.Add(ItemType.Missile);
                        }
                        else if (missileCount == 4)
                        {
                            retVal.Add(ItemType.SuperMissile);
                        }
                        else
                        {
                            retVal.Add(ItemType.Missile);
                        }
                    }
                    else if (addedItem == ItemType.SuperMissile)
                    {
                        if (superMissileCount == 3)
                        {
                            retVal.Add(ItemType.Missile);
                        }
                        else
                        {
                            retVal.Add(ItemType.SuperMissile);
                        }
                    }
                }
                else
                {
                    if (addedItem == ItemType.Missile)
                    {
                        if (missileCount == 4)
                        {
                            retVal.Add(ItemType.SuperMissile);
                        }
                        else
                        {
                            retVal.Add(ItemType.Missile);
                        }
                    }
                    else if (addedItem == ItemType.SuperMissile)
                    {
                        if (superMissileCount == 3)
                        {
                            retVal.Add(ItemType.SuperMissile);
                            retVal.Add(ItemType.SuperMissile);
                        }
                        else if (superMissileCount == 5)
                        {
                            retVal.Add(ItemType.Missile);
                        }
                        else
                        {
                            retVal.Add(ItemType.SuperMissile);
                        }
                    }
                }
            }

            if (!retVal.Contains(ItemType.VariaSuit))
            {
                retVal.AddRange(possibleMotherBrain[random.Next(possibleMotherBrain.Count)]);
            }

            return retVal;
        }

        private bool AmmoOkay(List<ItemType> have, bool zebSkip = true)
        {
            var retVal = false;
            var missileCount = have.Count(item => item == ItemType.Missile);
            var superMissileCount = have.Count(item => item == ItemType.SuperMissile);

            if (zebSkip)
            {
                // If we are skipping zebetites values are 4M 1SM; 2M 2SM; 1M 3SM
                if (missileCount == 4 && superMissileCount == 1)
                {
                    retVal = true;
                }
                if (missileCount == 2 && superMissileCount == 2)
                {
                    retVal = true;
                }
                if (missileCount == 1 && superMissileCount == 3)
                {
                    retVal = true;
                }
            }
            else
            {
                // If we are not skipping zebetites values are 4M 1SM; 3M 2SM; 2M 3SM; 1M 5SM
                if (missileCount == 4 && superMissileCount == 1)
                {
                    retVal = true;
                }
                if (missileCount == 3 && superMissileCount == 2)
                {
                    retVal = true;
                }
                if (missileCount == 2 && superMissileCount == 3)
                {
                    retVal = true;
                }
                if (missileCount == 1 && superMissileCount == 5)
                {
                    retVal = true;
                }
            }
            return retVal;
        }
    }
}
