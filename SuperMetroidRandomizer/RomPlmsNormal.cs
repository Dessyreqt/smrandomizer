﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMetroidRandomizer
{
    public class RomPlmsNormal : IRomPlms
    {
        public List<Plm> Plms { get; set; }
        public string DifficultyName { get { return "Speedrunner"; } }
        public string SeedFileString { get { return "S{0:0000000}"; } }
        public string SeedRomString { get { return "SMRv{0} S{1}"; } }

        public void ResetPlms()
        {
            Plms = new List<Plm>
                       {
                           new Plm
                               {
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "power bomb (crateria surface)",
                                   Address = 0x781CC,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have) 
                                       && (have.Contains(ItemType.SpeedBooster) 
                                           || have.Contains(ItemType.SpaceJump) 
                                           || CanIbj(have)),
                               },
                           new Plm
                               { 
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "missile (outside wrecked ship bottom)",
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
                                   Name = "missile (outside wrecked ship top)",
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
                                   Name = "missile (outside wrecked ship middle)",
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
                                   Name = "missile (crateria moat)",
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
                                   Name = "energy tank (crateria gauntlet)",
                                   Address = 0x78264,
                                   CanAccess =
                                       have =>
                                       CanEnterAndLeaveGauntlet(have)
                               },
                           new Plm
                               {        
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Crateria,
                                   Name = "missile (crateria bottom)",
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
                                   Name = "bomb",
                                   Address = 0x78404,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.MorphingBall) &&
                                       CanOpenMissileDoors(have)
                               },
                           new Plm
                               {     
                                   NoHidden = true,
                                   GravityOkay = false,   
                                   Region = Region.Crateria,
                                   Name = "energy tank (crateria tunnel to brinstar)",
                                   Address = 0x78432,
                                   CanAccess =
                                       have =>
                                       CanDestroyBombWalls(have) 
                                       || have.Contains(ItemType.SpeedBooster),
                               },
                           new Plm
                               {       
                                   NoHidden = false,
                                   GravityOkay = false,   
                                   Region = Region.Crateria,
                                   Name = "missile (crateria gauntlet right)",
                                   Address = 0x78464,
                                   CanAccess =
                                       have =>
                                       CanEnterAndLeaveGauntlet(have) 
                               },
                           new Plm
                               {     
                                   NoHidden = false,
                                   GravityOkay = false,   
                                   Region = Region.Crateria,
                                   Name = "missile (crateria gauntlet left)",
                                   Address = 0x7846A,
                                   CanAccess =
                                       have =>
                                       CanEnterAndLeaveGauntlet(have) 
                               },
                           new Plm
                               {     
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Crateria,
                                   Name = "super missile (crateria)",
                                   Address = 0x78478,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && have.Contains(ItemType.SpeedBooster) 
                                       && (have.Contains(ItemType.EnergyTank) 
                                           || have.Contains(ItemType.VariaSuit) 
                                           || have.Contains(ItemType.GravitySuit)),
                               },
                           new Plm
                               {       
                                   NoHidden = false,
                                   GravityOkay = false,     
                                   Region = Region.Crateria,
                                   Name = "missile (crateria middle)",
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
                                   Name = "power bomb (green brinstar bottom)",
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
                                   Name = "super missile (pink brinstar)",
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
                                   Name = "missile (green brinstar below super missile)",
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
                                   Name = "super missile (green brinstar top)",
                                   Address = 0x7851E,
                                   CanAccess =
                                       have =>
                                       CanDestroyBombWalls(have) 
                                       && CanOpenMissileDoors(have) 
                                       && (have.Contains(ItemType.SpeedBooster) 
                                           || have.Contains(ItemType.SpeedBooster)),
                               },
                           new Plm
                               {           
                                   NoHidden = false,
                                   GravityOkay = false,   
                                   Region = Region.Brinstar,
                                   Name = "reserve tank (brinstar)",
                                   Address = 0x7852C,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanDestroyBombWalls(have) 
                                       && CanOpenMissileDoors(have) 
                                       && (have.Contains(ItemType.SpeedBooster) 
                                           || have.Contains(ItemType.SpeedBooster)),
                               },
                           new Plm
                               {            
                                   NoHidden = false,
                                   GravityOkay = false,   
                                   Region = Region.Brinstar,
                                   Name = "missile (green brinstar behind missile)",
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
                                   Name = "missile (green brinstar behind reserve tank)",
                                   Address = 0x78538,
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
                                   Name = "missile (pink brinstar top)",
                                   Address = 0x78608,
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
                                   Name = "missile (pink brinstar bottom)",
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
                                   Name = "charge beam",
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
                                   Name = "power bomb (pink brinstar)",
                                   Address = 0x7865C,
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
                                   Name = "missile (green brinstar pipe)",
                                   Address = 0x78676,
                                   CanAccess =
                                       have =>
                                       (CanPassBombPassages(have) 
                                           && have.Contains(ItemType.SuperMissile))
                                       || CanUsePowerBombs(have),
                               },
                           new Plm
                               {           
                                   NoHidden = true,
                                   GravityOkay = false,              
                                   Region = Region.Brinstar,
                                   Name = "morphing ball",         
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
                                   Name = "power bomb (blue brinstar)",
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
                                   Name = "missile (blue brinstar middle)",
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
                                   Name = "energy tank (blue brinstar)",
                                   Address = 0x7879E,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have) 
                               },
                           new Plm
                               {            
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "energy tank (green brinstar bottom)",
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
                                   Name = "super missile (green brinstar bottom)",
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
                                   Name = "energy tank (pink brinstar bottom)",
                                   Address = 0x787FA,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have) 
                                       && CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.SpeedBooster) 
                               },
                           new Plm
                               {            
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Brinstar,
                                   Name = "missile (blue brinstar bottom)",
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
                                   Name = "energy tank (pink brinstar top)",
                                   Address = 0x78824,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have) 
                                       && (have.Contains(ItemType.WaveBeam) 
                                           || have.Contains(ItemType.SuperMissile)),
                               },
                           new Plm
                               {           
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Brinstar,
                                   Name = "missile (blue brinstar top)",
                                   Address = 0x78836,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have) 
                                       && CanUsePowerBombs(have) 
                               },
                           new Plm
                               {           
                                   NoHidden = false,
                                   GravityOkay = false,   
                                   Region = Region.Brinstar,
                                   Name = "missile (blue brinstar behind missile)",
                                   Address = 0x7883C,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have) 
                                       && CanUsePowerBombs(have) 
                               },
                           new Plm
                               {           
                                   NoHidden = false,
                                   GravityOkay = false,      
                                   Region = Region.Brinstar,
                                   Name = "x-ray visor",
                                   Address = 0x78876,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have) 
                                       && CanUsePowerBombs(have) 
                                       && (have.Contains(ItemType.GrappleBeam) 
                                           || have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.IceBeam)),
                               },
                           new Plm
                               {           
                                   NoHidden = false,
                                   GravityOkay = false,            
                                   Region = Region.Brinstar,
                                   Name = "power bomb (red brinstar sidehopper room)",
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
                                   Name = "power bomb (red brinstar spike room)",
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
                                   Name = "missile (red brinstar spike room)",
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
                                   Name = "spazer",
                                   Address = 0x7896E,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have) 
                                       && CanPassBombPassages(have)
                               },
                           new Plm
                               {           
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "energy tank (kraid)",
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
                                   Name = "missile (kraid)",
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
                                   Name = "varia suit",
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
                                   Name = "missile (lava room)",
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
                                   Name = "ice beam",
                                   Address = 0x78B24,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessKraid(have)
                                       && (have.Contains(ItemType.GravitySuit) 
                                           || have.Contains(ItemType.VariaSuit) 
                                           || EnergyReserveCount(have) >= 2)
                               },
                           new Plm
                               {                  
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "missile (below ice beam)",
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
                           new Plm
                               {                   
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "energy tank (crocomire)",
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
                                   Name = "hi-jump boots",
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
                                   Name = "missile (above crocomire)",
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
                           new Plm
                               {                   
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "missile (hi-jump boots)",
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
                                   Name = "energy tank (hi-jump boots)",
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
                                   Name = "power bomb (crocomire)",
                                   Address = 0x78C04,
                                   CanAccess =
                                       have =>
                                       CanAccessCrocomire(have)   //TODO: see if you need high jump to get these
                               },
                           new Plm
                               {                    
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "missile (below crocomire)",
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
                                   Name = "missile (grapple beam)",
                                   Address = 0x78C2A,
                                   CanAccess =
                                       have =>
                                       CanAccessCrocomire(have)
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.GrappleBeam) 
                                           || have.Contains(ItemType.SpeedBooster) 
                                           || CanIbj(have)),
                               },
                           new Plm
                               {                     
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "grapple beam",
                                   Address = 0x78C36,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessCrocomire(have)
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.SpeedBooster)
                                           || CanIbj(have)),
                               },
                           new Plm
                               {                  
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "reserve tank (norfair)",
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
                           new Plm
                               {                  
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "missile (norfair reserve tank)",
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
                           new Plm
                               {                 
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "missile (bubble norfair green door)",
                                   Address = 0x78C52,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have) 
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.GrappleBeam)
                                           || have.Contains(ItemType.HiJumpBoots)
                                           || CanIbj(have)),
                               },
                           new Plm
                               {                       
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "missile (bubble norfair)",
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
                                   Name = "missile (speed booster)",
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
                                   Name = "speed booster",
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
                                   Name = "missile (wave beam)",
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
                                   Name = "wave beam",
                                   Address = 0x78CCA,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have)
                               },
                           new Plm
                               {                     
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "missile (gold torizo)",
                                   Address = 0x78E6E,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have)
                                       && have.Contains(ItemType.SpaceJump),
                               },
                           new Plm
                               {                     
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "super missile (gold torizo)",
                                   Address = 0x78E74,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have)
                                       && (have.Contains(ItemType.SpaceJump)
                                           || have.Contains(ItemType.SpeedBooster)
                                           || CanIbj(have)),
                               },
                           new Plm
                               {                         
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "missile (mickey mouse room)",
                                   Address = 0x78F30,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       (((have.Contains(ItemType.VariaSuit) || have.Contains(ItemType.GravitySuit)) &&
                                         have.Contains(ItemType.HiJumpBoots)) || have.Contains(ItemType.GravitySuit)) &&
                                       ((have.Contains(ItemType.Bomb) && have.Contains(ItemType.MorphingBall)) ||
                                        have.Contains(ItemType.HiJumpBoots) || have.Contains(ItemType.SpaceJump)),
                               },
                           new Plm
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "missile (lower norfair above fire flea room)",
                                   Address = 0x78FCA,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       (((have.Contains(ItemType.VariaSuit) || have.Contains(ItemType.GravitySuit)) &&
                                         have.Contains(ItemType.HiJumpBoots)) || have.Contains(ItemType.GravitySuit)) &&
                                       ((have.Contains(ItemType.Bomb) && have.Contains(ItemType.MorphingBall)) ||
                                        have.Contains(ItemType.HiJumpBoots) || have.Contains(ItemType.SpaceJump)),
                               },
                           new Plm
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "power bomb (lower norfair above fire flea room)",
                                   Address = 0x78FD2,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       (((have.Contains(ItemType.VariaSuit) || have.Contains(ItemType.GravitySuit)) &&
                                         have.Contains(ItemType.HiJumpBoots)) || have.Contains(ItemType.GravitySuit)) &&
                                       ((have.Contains(ItemType.Bomb) && have.Contains(ItemType.MorphingBall)) ||
                                        have.Contains(ItemType.HiJumpBoots) || have.Contains(ItemType.SpaceJump)),
                               },
                           new Plm
                               {                         
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "power bomb (above ridley)",
                                   Address = 0x790C0,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       (((have.Contains(ItemType.VariaSuit) || have.Contains(ItemType.GravitySuit)) &&
                                         have.Contains(ItemType.HiJumpBoots)) || have.Contains(ItemType.GravitySuit)) &&
                                       ((have.Contains(ItemType.Bomb) && have.Contains(ItemType.MorphingBall)) ||
                                        have.Contains(ItemType.HiJumpBoots) || have.Contains(ItemType.SpaceJump)),
                               },
                           new Plm
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "missile (lower norfair near wave beam)",
                                   Address = 0x79100,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       (((have.Contains(ItemType.VariaSuit) || have.Contains(ItemType.GravitySuit)) &&
                                         have.Contains(ItemType.HiJumpBoots)) || have.Contains(ItemType.GravitySuit)) &&
                                       ((have.Contains(ItemType.Bomb) && have.Contains(ItemType.MorphingBall)) ||
                                        have.Contains(ItemType.HiJumpBoots) || have.Contains(ItemType.SpaceJump)),
                               },
                           new Plm
                               {                         
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "energy tank (ridley)",
                                   Address = 0x79108,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       (((have.Contains(ItemType.VariaSuit) || have.Contains(ItemType.GravitySuit)) &&
                                         have.Contains(ItemType.HiJumpBoots)) || have.Contains(ItemType.GravitySuit)) &&
                                       ((have.Contains(ItemType.Bomb) && have.Contains(ItemType.MorphingBall)) ||
                                        have.Contains(ItemType.HiJumpBoots) || have.Contains(ItemType.SpaceJump)) &&
                                       have.Contains(ItemType.ChargeBeam),
                               },
                           new Plm
                               {                        
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "screw attack",
                                   Address = 0x79110,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       (((have.Contains(ItemType.VariaSuit) || have.Contains(ItemType.GravitySuit)) &&
                                         have.Contains(ItemType.HiJumpBoots)) ||
                                        (have.Contains(ItemType.GravitySuit) &&
                                         ((have.Contains(ItemType.Bomb) && have.Contains(ItemType.MorphingBall)) ||
                                          have.Contains(ItemType.HiJumpBoots) || have.Contains(ItemType.SpaceJump)))),
                               },
                           new Plm
                               {                        
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "energy tank (lower norfair fire flea room)",
                                   Address = 0x79184,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       (((have.Contains(ItemType.VariaSuit) || have.Contains(ItemType.GravitySuit)) &&
                                         have.Contains(ItemType.HiJumpBoots)) || have.Contains(ItemType.GravitySuit)) &&
                                       ((have.Contains(ItemType.Bomb) && have.Contains(ItemType.MorphingBall)) ||
                                        have.Contains(ItemType.HiJumpBoots) || have.Contains(ItemType.SpaceJump)),
                               },
                           new Plm
                               {                         
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.WreckedShip,
                                   Name = "missile (wrecked ship middle)",
                                   Address = 0x7C265,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)),
                               },
                           new Plm
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "reserve tank (wrecked ship)",
                                   Address = 0x7C2E9,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       have.Contains(ItemType.ChargeBeam) && have.Contains(ItemType.SpeedBooster) &&
                                       (have.Contains(ItemType.EnergyTank) ||
                                        (have.Contains(ItemType.VariaSuit) || have.Contains(ItemType.GravitySuit)) ||
                                        have.Contains(ItemType.GravitySuit)),
                               },
                           new Plm
                               {                           
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "missile (gravity suit)",
                                   Address = 0x7C2EF,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       have.Contains(ItemType.ChargeBeam) &&
                                       (have.Contains(ItemType.EnergyTank) ||
                                        (have.Contains(ItemType.VariaSuit) || have.Contains(ItemType.GravitySuit)) ||
                                        have.Contains(ItemType.GravitySuit)),
                               },
                           new Plm
                               {                          
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "missile (wrecked ship top)",
                                   Address = 0x7C319,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       have.Contains(ItemType.ChargeBeam) &&
                                       (have.Contains(ItemType.EnergyTank) ||
                                        (have.Contains(ItemType.VariaSuit) || have.Contains(ItemType.GravitySuit)) ||
                                        have.Contains(ItemType.GravitySuit)),
                               },
                           new Plm
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "energy tank (wrecked ship)",
                                   Address = 0x7C337,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       have.Contains(ItemType.ChargeBeam) &&
                                       (have.Contains(ItemType.EnergyTank) ||
                                        (have.Contains(ItemType.VariaSuit) || have.Contains(ItemType.GravitySuit)) ||
                                        have.Contains(ItemType.GravitySuit)) &&
                                       (have.Contains(ItemType.SpeedBooster) || have.Contains(ItemType.HiJumpBoots) ||
                                        have.Contains(ItemType.SpaceJump) || have.Contains(ItemType.GravitySuit)),
                               },
                           new Plm
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "super missile (wrecked ship left)",
                                   Address = 0x7C357,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       have.Contains(ItemType.ChargeBeam) &&
                                       (have.Contains(ItemType.EnergyTank) ||
                                        (have.Contains(ItemType.VariaSuit) || have.Contains(ItemType.GravitySuit)) ||
                                        have.Contains(ItemType.GravitySuit)),
                               },
                           new Plm
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "super missile (wrecked ship right)",
                                   Address = 0x7C365,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       have.Contains(ItemType.ChargeBeam) &&
                                       (have.Contains(ItemType.EnergyTank) ||
                                        (have.Contains(ItemType.VariaSuit) || have.Contains(ItemType.GravitySuit)) ||
                                        have.Contains(ItemType.GravitySuit)),
                               },
                           new Plm
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "gravity suit",
                                   Address = 0x7C36D,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       have.Contains(ItemType.ChargeBeam) &&
                                       (have.Contains(ItemType.EnergyTank) ||
                                        (have.Contains(ItemType.VariaSuit) || have.Contains(ItemType.GravitySuit)) ||
                                        have.Contains(ItemType.GravitySuit)),
                               },
                           new Plm
                               {                           
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "missile (green maridia shinespark)",
                                   Address = 0x7C437,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       have.Contains(ItemType.GravitySuit) && have.Contains(ItemType.SpeedBooster),
                               },
                           new Plm
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "super missile (green maridia)",
                                   Address = 0x7C43D,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       (have.Contains(ItemType.GravitySuit) ||
                                        (have.Contains(ItemType.HiJumpBoots) && have.Contains(ItemType.IceBeam))),
                               },
                           new Plm
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "energy tank (green maridia)",
                                   Address = 0x7C47D,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       (have.Contains(ItemType.GravitySuit) ||
                                        (have.Contains(ItemType.HiJumpBoots) && have.Contains(ItemType.IceBeam))) &&
                                       (have.Contains(ItemType.SpeedBooster) || have.Contains(ItemType.GrappleBeam) ||
                                        (have.Contains(ItemType.Bomb) && have.Contains(ItemType.MorphingBall)) ||
                                        have.Contains(ItemType.SpaceJump)),
                               },
                           new Plm
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "missile (green maridia tatori)",
                                   Address = 0x7C483,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       (have.Contains(ItemType.GravitySuit) ||
                                        (have.Contains(ItemType.HiJumpBoots) && have.Contains(ItemType.IceBeam))),
                               },
                           new Plm
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "super missile (yellow maridia)",
                                   Address = 0x7C4AF,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       (have.Contains(ItemType.GravitySuit) ||
                                        (have.Contains(ItemType.HiJumpBoots) && have.Contains(ItemType.IceBeam) &&
                                         have.Contains(ItemType.GrappleBeam))),
                               },
                           new Plm
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "missile (yellow maridia super missile)",
                                   Address = 0x7C4B5,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       (have.Contains(ItemType.GravitySuit) ||
                                        (have.Contains(ItemType.HiJumpBoots) && have.Contains(ItemType.IceBeam) &&
                                         have.Contains(ItemType.GrappleBeam))),
                               },
                           new Plm
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "missile (yellow maridia false wall)",
                                   Address = 0x7C533,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       (have.Contains(ItemType.GravitySuit) ||
                                        (have.Contains(ItemType.HiJumpBoots) && have.Contains(ItemType.IceBeam) &&
                                         have.Contains(ItemType.GrappleBeam))),
                               },
                           new Plm
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "plasma beam",
                                   Address = 0x7C559,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       ((have.Contains(ItemType.GravitySuit) &&
                                         (have.Contains(ItemType.SpeedBooster) || have.Contains(ItemType.IceBeam))) ||
                                        (have.Contains(ItemType.HiJumpBoots) && have.Contains(ItemType.IceBeam) &&
                                         have.Contains(ItemType.GrappleBeam) && have.Contains(ItemType.XRayScope))),
                               },
                           new Plm
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "missile (left maridia sand pit room)",
                                   Address = 0x7C5DD,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       (have.Contains(ItemType.GravitySuit) ||
                                        (have.Contains(ItemType.HiJumpBoots) && have.Contains(ItemType.IceBeam) &&
                                         have.Contains(ItemType.GrappleBeam))),
                               },
                           new Plm
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "reserve tank (maridia)",
                                   Address = 0x7C5E3,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       (have.Contains(ItemType.GravitySuit) ||
                                        (have.Contains(ItemType.HiJumpBoots) && have.Contains(ItemType.IceBeam) &&
                                         have.Contains(ItemType.GrappleBeam))),
                               },
                           new Plm
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "missile (right maridia sand pit room)",
                                   Address = 0x7C5EB,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       (have.Contains(ItemType.GravitySuit) ||
                                        (have.Contains(ItemType.HiJumpBoots) && have.Contains(ItemType.IceBeam) &&
                                         have.Contains(ItemType.GrappleBeam))),
                               },
                           new Plm
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "power bomb (right maridia sand pit room)",
                                   Address = 0x7C5F1,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       have.Contains(ItemType.GravitySuit),
                               },
                           new Plm
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "missile (pink maridia)",
                                   Address = 0x7C603,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       have.Contains(ItemType.GravitySuit) && have.Contains(ItemType.SpeedBooster),
                               },
                           new Plm
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "super missile (pink maridia)",
                                   Address = 0x7C609,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       have.Contains(ItemType.GravitySuit) && have.Contains(ItemType.SpeedBooster),
                               },
                           new Plm
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "spring ball",
                                   Address = 0x7C6E5,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       have.Contains(ItemType.GravitySuit) &&
                                       (have.Contains(ItemType.IceBeam) || have.Contains(ItemType.GrappleBeam)),
                               },
                           new Plm
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "missile (draygon)",
                                   Address = 0x7C74D,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       ((have.Contains(ItemType.GravitySuit) &&
                                         (have.Contains(ItemType.SpeedBooster) || have.Contains(ItemType.IceBeam))) ||
                                        (have.Contains(ItemType.HiJumpBoots) && have.Contains(ItemType.IceBeam) &&
                                         have.Contains(ItemType.GrappleBeam))),
                               },
                           new Plm
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "energy tank (botwoon)",
                                   Address = 0x7C755,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       ((have.Contains(ItemType.GravitySuit) &&
                                         (have.Contains(ItemType.SpeedBooster) || have.Contains(ItemType.IceBeam))) ||
                                        (have.Contains(ItemType.HiJumpBoots) && have.Contains(ItemType.IceBeam) &&
                                         have.Contains(ItemType.GrappleBeam))),
                               },
                           new Plm
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "space jump",
                                   Address = 0x7C7A7,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) &&
                                       (have.Contains(ItemType.PowerBomb) && have.Contains(ItemType.MorphingBall)) &&
                                       ((have.Contains(ItemType.GravitySuit) &&
                                         (have.Contains(ItemType.SpeedBooster) || have.Contains(ItemType.IceBeam))) ||
                                        (have.Contains(ItemType.HiJumpBoots) && have.Contains(ItemType.IceBeam) &&
                                         have.Contains(ItemType.GrappleBeam) && have.Contains(ItemType.XRayScope))),
                               },
                       };
        }

        private bool CanIbj(List<ItemType> have)
        {
            return (have.Contains(ItemType.Bomb)
                && have.Contains(ItemType.MorphingBall));
        }

        private bool CanDefeatDraygon(List<ItemType> have)
        {
            return CanDefeatBotwoon(have)
                && (have.Contains(ItemType.SpaceJump) 
                    || have.Contains(ItemType.GrappleBeam))
                && have.Count(x => x == ItemType.EnergyTank) >= 3;
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
                && have.Contains(ItemType.PowerBomb);
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
                && (have.Contains(ItemType.SpaceJump) 
                    || have.Contains(ItemType.HiJumpBoots) 
                    || CanIbj(have))
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
            return CanAccessRedBrinstar(have);
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

        public RomPlmsNormal()
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
            if (!(candidateItem == ItemType.GravitySuit && !currentPlms.Any(x => x.GravityOkay)))
            {
                candidateItemList.Add(candidateItem);
            }
        }

        public int GetInsertedPlm(List<Plm> currentPlms, ItemType insertedItem, SeedRandom random)
        {
            int retVal;

            do
            {
                retVal = random.Next(currentPlms.Count);
            } while (insertedItem == ItemType.GravitySuit && !currentPlms[retVal].GravityOkay);

            return retVal;
        }

        public ItemType GetInsertedItem(List<Plm> currentPlms, List<ItemType> itemPool, SeedRandom random)
        {
            ItemType retVal;

            do
            {
                retVal = itemPool[random.Next(itemPool.Count)];
            } while (retVal == ItemType.GravitySuit && !currentPlms.Any(x => x.GravityOkay));

            return retVal;
        }

        public List<ItemType> GetItemPool()
        {
            return new List<ItemType>
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
        }
    }
}