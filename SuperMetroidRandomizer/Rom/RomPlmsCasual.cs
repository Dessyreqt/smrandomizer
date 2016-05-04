using System;
using System.Collections.Generic;
using System.Linq;
using SuperMetroidRandomizer.Random;

namespace SuperMetroidRandomizer.Rom
{
    public class RomPlmsCasual : IRomPlms
    {
        public List<Plm> Plms { get; set; }
        public string DifficultyName { get { return "Casual"; } }
        public string SeedFileString { get { return "C{0:0000000}"; } }
        public string SeedRomString { get { return "SMRv{0} C{1}"; } }

        public void ResetPlms()
        {
            Plms = new List<Plm>
                       {
                           new Plm
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
                                           || have.Contains(ItemType.SpaceJump)),
                               },
                           new Plm
                               { 
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (outside Wrecked Ship bottom)",
                                   Address = 0x781E8,
                                   CanAccess =
                                       have => 
                                       CanAccessWs(have),
                               },
                           new Plm
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
                           new Plm
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
                           new Plm
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
                           new Plm
                               {       
                                   NoHidden = true,
                                   GravityOkay = false,    
                                   Region = Region.Crateria,
                                   Name = "Energy Tank (Crateria gauntlet)",
                                   Address = 0x78264,
                                   CanAccess =
                                       have =>
                                       CanEnterAndLeaveGauntlet(have)
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.SpeedBooster)),
                               },
                           new Plm
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
                           new Plm
                               {        
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Crateria,
                                   Name = "Bomb",
                                   Address = 0x78404,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                                       && CanPassBombPassages(have),
                               },
                           new Plm
                               {     
                                   NoHidden = true,
                                   GravityOkay = false,   
                                   Region = Region.Crateria,
                                   Name = "Energy Tank (Crateria tunnel to Brinstar)",
                                   Address = 0x78432,
                                   CanAccess = 
                                       have => 
                                       CanDestroyBombWalls(have),
                               },
                           new Plm
                               {       
                                   NoHidden = false,
                                   GravityOkay = false,   
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria gauntlet right)",
                                   Address = 0x78464,
                                   CanAccess =
                                       have =>
                                       CanEnterAndLeaveGauntlet(have) 
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.SpeedBooster))
                                       && CanPassBombPassages(have),
                               },
                           new Plm
                               {     
                                   NoHidden = false,
                                   GravityOkay = false,   
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria gauntlet left)",
                                   Address = 0x7846A,
                                   CanAccess =
                                       have =>
                                       CanEnterAndLeaveGauntlet(have) 
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.SpeedBooster))
                                       && CanPassBombPassages(have),
                               },
                           new Plm
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
                                       && (EnergyReserveCount(have) >= 1 
                                           || have.Contains(ItemType.VariaSuit) 
                                           || have.Contains(ItemType.GravitySuit)),
                               },
                           new Plm
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
                           new Plm
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
                           new Plm
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
                           new Plm
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
                           new Plm
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
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Plm
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
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Plm
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
                           new Plm
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
                           new Plm
                               {             
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Brinstar,
                                   Name = "Missile (pink Brinstar top)",
                                   Address = 0x78608,
                                   CanAccess =
                                       have =>
                                       CanDestroyBombWalls(have) 
                                       && CanOpenMissileDoors(have)
                                       && (have.Contains(ItemType.GrappleBeam) 
                                           || have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.SpeedBooster))
                               },
                           new Plm
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
                           new Plm
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
                           new Plm
                               {            
                                   NoHidden = false,
                                   GravityOkay = false,     
                                   Region = Region.Brinstar,
                                   Name = "Power Bomb (pink Brinstar)",
                                   Address = 0x7865C,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have) 
                                       && have.Contains(ItemType.SuperMissile)
                                       && (have.Contains(ItemType.GrappleBeam) 
                                           || have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.SpeedBooster))
                              },
                           new Plm
                               {           
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Brinstar,
                                   Name = "Missile (green Brinstar pipe)",
                                   Address = 0x78676,
                                   CanAccess =
                                       have =>
                                       ((CanPassBombPassages(have) 
                                               && have.Contains(ItemType.SuperMissile))
                                           || CanUsePowerBombs(have))
                                       && (have.Contains(ItemType.HiJumpBoots) 
                                           || have.Contains(ItemType.SpaceJump)),
                               },
                           new Plm
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
                           new Plm
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
                           new Plm
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
                           new Plm
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
                                       && (have.Contains(ItemType.HiJumpBoots) 
                                           || have.Contains(ItemType.SpeedBooster) 
                                           || have.Contains(ItemType.SpaceJump)),
                               },
                           new Plm
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
                           new Plm
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
                           new Plm
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
                                       && have.Contains(ItemType.GravitySuit),
                               },
                           new Plm
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
                           new Plm
                               {             
                                   NoHidden = false,
                                   GravityOkay = false,     
                                   Region = Region.Brinstar,
                                   Name = "Energy Tank (pink Brinstar top)",
                                   Address = 0x78824,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have) 
                                       && have.Contains(ItemType.WaveBeam),
                               },
                           new Plm
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
                                       && (have.Contains(ItemType.SpeedBooster) 
                                           || have.Contains(ItemType.SpaceJump)),
                               },
                           new Plm
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
                                       && (have.Contains(ItemType.SpeedBooster) 
                                           || have.Contains(ItemType.SpaceJump)),
                               },
                           new Plm
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
                                       && CanUsePowerBombs(have) 
                                       && (have.Contains(ItemType.GrappleBeam) 
                                           || have.Contains(ItemType.SpaceJump)),
                               },
                           new Plm
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
                           new Plm
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
                           new Plm
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
                           new Plm
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
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.HiJumpBoots)),
                               },
                           new Plm
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
                           new Plm
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
                           new Plm
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
                           new Plm
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
                           new Plm
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
                                           || have.Contains(ItemType.VariaSuit))
                                       && have.Contains(ItemType.SpeedBooster)
                                       && (CanUsePowerBombs(have) 
                                           || have.Contains(ItemType.IceBeam)),
                               },
                           new Plm
                               {                  
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (below Ice Beam)",
                                   Address = 0x78B46,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have)
                                       && CanUsePowerBombs(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Plm
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
                           new Plm
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
                           new Plm
                               {                   
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (above Crocomire)",
                                   Address = 0x78BC0,
                                   CanAccess =
                                       have =>
                                       CanAccessCrocomire(have)
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.GrappleBeam)),
                               },
                           new Plm
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
                           new Plm
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
                           new Plm
                               {                    
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Power Bomb (Crocomire)",
                                   Address = 0x78C04,
                                   CanAccess =
                                       have =>
                                       CanAccessCrocomire(have)
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.GrappleBeam)),
                               },
                           new Plm
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
                           new Plm
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
                                           || have.Contains(ItemType.SpeedBooster)),
                               },
                           new Plm
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
                                           || (have.Contains(ItemType.SpeedBooster)
                                               && have.Contains(ItemType.HiJumpBoots))),
                               },
                           new Plm
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
                                           || have.Contains(ItemType.GrappleBeam)),
                               },
                           new Plm
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
                                           || have.Contains(ItemType.GrappleBeam)),
                               },
                           new Plm
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
                                           || have.Contains(ItemType.GrappleBeam)),
                               },
                           new Plm
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
                           new Plm
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
                           new Plm
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
                           new Plm
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
                           new Plm
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
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.GrappleBeam)),
                               },
                           new Plm
                               {                     
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (Gold Torizo)",
                                   Address = 0x78E6E,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Plm
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
                           new Plm
                               {                         
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (Mickey Mouse room)",
                                   Address = 0x78F30,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Plm
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (lower Norfair above fire flea room)",
                                   Address = 0x78FCA,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Plm
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Power Bomb (lower Norfair above fire flea room)",
                                   Address = 0x78FD2,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Plm
                               {                         
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Power Bomb (above Ridley)",
                                   Address = 0x790C0,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Plm
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (lower Norfair near Wave Beam)",
                                   Address = 0x79100,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Plm
                               {                         
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Energy Tank (Ridley)",
                                   Address = 0x79108,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have)
                                       && have.Contains(ItemType.ChargeBeam)
                                       && EnergyReserveCount(have) >= 4,
                               },
                           new Plm
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
                           new Plm
                               {                        
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Energy Tank (lower Norfair fire flea room)",
                                   Address = 0x79184,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Plm
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
                           new Plm
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
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Plm
                               {                           
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "Missile (Gravity Suit)",
                                   Address = 0x7C2EF,
                                   CanAccess =
                                       have => 
                                       CanDefeatPhantoon(have)
                               },
                           new Plm
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
                           new Plm
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "Energy Tank (Wrecked Ship)",
                                   Address = 0x7C337,
                                   CanAccess =
                                       have => 
                                       CanDefeatPhantoon(have) 
                                       && have.Contains(ItemType.GravitySuit) 
                                       && (have.Contains(ItemType.GrappleBeam) 
                                           || have.Contains(ItemType.SpaceJump)),
                               },
                           new Plm
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
                           new Plm
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
                           new Plm
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
                               },
                           new Plm
                               {                           
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (green Maridia shinespark)",
                                   Address = 0x7C437,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Plm
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
                           new Plm
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
                                           || have.Contains(ItemType.SpaceJump)),
                               },
                           new Plm
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
                           new Plm
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
                           new Plm
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
                           new Plm
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
                           new Plm
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
                                       && have.Contains(ItemType.SpaceJump)
                                       && (have.Contains(ItemType.ScrewAttack)
                                           || have.Contains(ItemType.PlasmaBeam)),
                               },
                           new Plm
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (left Maridia sand pit room)",
                                   Address = 0x7C5DD,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have)
                                       && have.Contains(ItemType.SpringBall),
                               },
                           new Plm
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Reserve Tank (Maridia)",
                                   Address = 0x7C5E3,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have)
                                       && have.Contains(ItemType.SpringBall),
                               },
                           new Plm
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
                           new Plm
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Power Bomb (right Maridia sand pit room)",
                                   Address = 0x7C5F1,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have),
                               },
                           new Plm
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (pink Maridia)",
                                   Address = 0x7C603,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Plm
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Super Missile (pink Maridia)",
                                   Address = 0x7C609,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Plm
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
                                       && have.Contains(ItemType.GrappleBeam)
                                       && have.Contains(ItemType.SpaceJump),
                               },
                           new Plm
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (Draygon)",
                                   Address = 0x7C74D,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanDefeatDraygon(have),
                               },
                           new Plm
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
                           new Plm
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

        private bool CanDefeatDraygon(List<ItemType> have)
        {
            return CanDefeatBotwoon(have)
                && have.Contains(ItemType.SpaceJump)
                && EnergyReserveCount(have) >= 3;
        }

        private bool CanDefeatBotwoon(List<ItemType> have)
        {
            return CanAccessInnerMaridia(have)
                && (have.Contains(ItemType.IceBeam) 
                    || have.Contains(ItemType.SpeedBooster));
        }

        private bool CanAccessInnerMaridia(List<ItemType> have)
        {
            return CanAccessOuterMaridia(have)
                && (have.Contains(ItemType.SpaceJump) 
                    || have.Contains(ItemType.GrappleBeam) 
                    || have.Contains(ItemType.SpeedBooster));
        }

        private bool CanAccessOuterMaridia(List<ItemType> have)
        {
            return CanAccessRedBrinstar(have)
                && have.Contains(ItemType.PowerBomb)
                && have.Contains(ItemType.GravitySuit)
                && (have.Contains(ItemType.SpaceJump) 
                    || have.Contains(ItemType.HiJumpBoots));
        }

        private bool CanAccessLowerNorfair(List<ItemType> have)
        {
            return CanAccessHeatedNorfair(have)
                && have.Contains(ItemType.PowerBomb)
                && have.Contains(ItemType.GravitySuit)
                && have.Contains(ItemType.SpaceJump);
        }

        private bool CanAccessCrocomire(List<ItemType> have)
        {
            return CanAccessHeatedNorfair(have)
                && ((have.Contains(ItemType.SpeedBooster) && CanUsePowerBombs(have)) 
                    || have.Contains(ItemType.WaveBeam));
        }

        private bool CanAccessHeatedNorfair(List<ItemType> have)
        {
            return CanAccessRedBrinstar(have)
                && (have.Contains(ItemType.SpaceJump) 
                    || have.Contains(ItemType.HiJumpBoots))
                && (have.Contains(ItemType.VariaSuit) 
                    || have.Contains(ItemType.GravitySuit));
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
                && (have.Contains(ItemType.SpaceJump) 
                    || have.Contains(ItemType.HiJumpBoots));
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
                || CanUsePowerBombs(have) 
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
            return CanAccessWs(have) 
                && have.Contains(ItemType.ChargeBeam)
                && (have.Contains(ItemType.GravitySuit) 
                    || have.Contains(ItemType.VariaSuit) 
                    || EnergyReserveCount(have) >= 2);
        }

        private static bool CanAccessWs(List<ItemType> have)
        {
            return have.Contains(ItemType.SuperMissile) 
                && CanUsePowerBombs(have)
                && (have.Contains(ItemType.SpaceJump) 
                    || have.Contains(ItemType.GrappleBeam) 
                    || have.Contains(ItemType.SpeedBooster));
        }

        public RomPlmsCasual()
        {
            ResetPlms();
        }

        public List<Plm> GetAvailablePlms(List<ItemType> haveItems)
        {
            return (from Plm plm in Plms where plm.Item == null && plm.CanAccess(haveItems) select plm).ToList();
        }

        public List<Plm> GetUnavailablePlms(List<ItemType> haveItems)
        {
            return (from Plm plm in Plms where plm.Item == null && !plm.CanAccess(haveItems) select plm).ToList();
        }

        public void TryInsertCandidateItem(List<Plm> currentPlms, List<ItemType> candidateItemList, ItemType candidateItem)
        {
            if (currentPlms.All(x => x.Name != "Morphing Ball") || !candidateItemList.Contains(candidateItem))
            {
                candidateItemList.Add(candidateItem);
            }
        }

        public int GetInsertedPlm(List<Plm> currentPlms, ItemType insertedItem, SeedRandom random)
        {
            return random.Next(currentPlms.Count);
        }

        public ItemType GetInsertedItem(List<Plm> currentPlms, List<ItemType> itemPool, SeedRandom random)
        {
            return itemPool[random.Next(itemPool.Count)];
        }

        public List<ItemType> GetItemPool(SeedRandom random)
        {
            return new List<ItemType>
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
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
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
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
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
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                       };
        }
    }
}
