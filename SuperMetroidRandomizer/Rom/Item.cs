namespace SuperMetroidRandomizer.Rom
{
    public enum ItemType
    {
        MorphingBall,
        Bomb,
        ChargeBeam,
        Spazer,
        VariaSuit,
        HiJumpBoots,
        SpeedBooster,
        WaveBeam,
        GrappleBeam,
        GravitySuit,
        SpaceJump,
        SpringBall,
        PlasmaBeam,
        IceBeam,
        ScrewAttack,
        XRayScope,
        Missile,
        SuperMissile,
        PowerBomb,
        EnergyTank,
        ReserveTank,
        Nothing,
    }


    public class Item
    {
        public string Normal { get; set; }
        public string Hidden { get; set; }
        public string Chozo { get; set; }
        public ItemType Type
        {
            get { return type; }
            set
            {
                type = value;
                switch (type)
                {
                    case ItemType.MorphingBall:
                        Normal = MORPH;
                        Hidden = HIDDEN_MORPH;
                        Chozo = CHOZO_MORPH;
                        break;
                    case ItemType.Bomb:
                        Normal = BOMB;
                        Hidden = HIDDEN_BOMB;
                        Chozo = CHOZO_BOMB;
                        break;
                    case ItemType.ChargeBeam:
                        Normal = CHARGE;
                        Hidden = HIDDEN_CHARGE;
                        Chozo = CHOZO_CHARGE;
                        break;
                    case ItemType.Spazer:
                        Normal = SPAZER;
                        Hidden = HIDDEN_SPAZER;
                        Chozo = CHOZO_SPAZER;
                        break;
                    case ItemType.VariaSuit:
                        Normal = VARIA;
                        Hidden = HIDDEN_VARIA;
                        Chozo = CHOZO_VARIA;
                        break;
                    case ItemType.HiJumpBoots:
                        Normal = HIJUMP;
                        Hidden = HIDDEN_HIJUMP;
                        Chozo = CHOZO_HIJUMP;
                        break;
                    case ItemType.SpeedBooster:
                        Normal = SPEED;
                        Hidden = HIDDEN_SPEED;
                        Chozo = CHOZO_SPEED;
                        break;
                    case ItemType.WaveBeam:
                        Normal = WAVE;
                        Hidden = HIDDEN_WAVE;
                        Chozo = CHOZO_WAVE;
                        break;
                    case ItemType.GrappleBeam:
                        Normal = GRAPPLE;
                        Hidden = HIDDEN_GRAPPLE;
                        Chozo = CHOZO_GRAPPLE;
                        break;
                    case ItemType.GravitySuit:
                        Normal = GRAVITY;
                        Hidden = HIDDEN_GRAVITY;
                        Chozo = CHOZO_GRAVITY;
                        break;
                    case ItemType.SpaceJump:
                        Normal = SPACE;
                        Hidden = HIDDEN_SPACE;
                        Chozo = CHOZO_SPACE;
                        break;
                    case ItemType.SpringBall:
                        Normal = SPRING;
                        Hidden = HIDDEN_SPRING;
                        Chozo = CHOZO_SPRING;
                        break;
                    case ItemType.PlasmaBeam:
                        Normal = PLASMA;
                        Hidden = HIDDEN_PLASMA;
                        Chozo = CHOZO_PLASMA;
                        break;
                    case ItemType.IceBeam:
                        Normal = ICE;
                        Hidden = HIDDEN_ICE;
                        Chozo = CHOZO_ICE;
                        break;
                    case ItemType.ScrewAttack:
                        Normal = SCREW;
                        Hidden = HIDDEN_SCREW;
                        Chozo = CHOZO_SCREW;
                        break;
                    case ItemType.XRayScope:
                        Normal = XRAY;
                        Hidden = HIDDEN_XRAY;
                        Chozo = CHOZO_XRAY;
                        break;
                    case ItemType.Missile:
                        Normal = MISSILE;
                        Hidden = HIDDEN_MISSILE;
                        Chozo = CHOZO_MISSILE;
                        break;
                    case ItemType.SuperMissile:
                        Normal = SUPER;
                        Hidden = HIDDEN_SUPER;
                        Chozo = CHOZO_SUPER;
                        break;
                    case ItemType.PowerBomb:
                        Normal = PB;
                        Hidden = HIDDEN_PB;
                        Chozo = CHOZO_PB;
                        break;
                    case ItemType.EnergyTank:
                        Normal = ETANK;
                        Hidden = HIDDEN_ETANK;
                        Chozo = CHOZO_ETANK;
                        break;
                    case ItemType.ReserveTank:
                        Normal = RESERVE;
                        Hidden = HIDDEN_RESERVE;
                        Chozo = CHOZO_RESERVE;
                        break;
                    case ItemType.Nothing:
                        Normal = MISSILE;
                        Hidden = HIDDEN_MISSILE;
                        Chozo = CHOZO_MISSILE;
                        break;
                }

            }
        }

        private ItemType type;

        public Item(ItemType insertedItem)
        {
            Type = insertedItem;
        }

        private const string ETANK = "\xd7\xee";
        private const string MISSILE = "\xdb\xee";
        private const string SUPER = "\xdf\xee";
        private const string PB = "\xe3\xee";
        private const string BOMB = "\xe7\xee";
        private const string CHARGE = "\xeb\xee";
        private const string ICE = "\xef\xee";
        private const string HIJUMP = "\xf3\xee";
        private const string SPEED = "\xf7\xee";
        private const string WAVE = "\xfb\xee";
        private const string SPAZER = "\xff\xee";
        private const string SPRING = "\x03\xef";
        private const string VARIA = "\x07\xef";
        private const string PLASMA = "\x13\xef";
        private const string GRAPPLE = "\x17\xef";
        private const string MORPH = "\x23\xef";
        private const string RESERVE = "\x27\xef";
        private const string GRAVITY = "\x0b\xef";
        private const string XRAY = "\x0f\xef";
        private const string SPACE = "\x1b\xef";
        private const string SCREW = "\x1f\xef";
        private const string CHOZO_ETANK = "\x2b\xef";
        private const string CHOZO_MISSILE = "\x2f\xef";
        private const string CHOZO_SUPER = "\x33\xef";
        private const string CHOZO_PB = "\x37\xef";
        private const string CHOZO_BOMB = "\x3b\xef";
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
        private const string CHOZO_SPACE = "\x6f\xef";
        private const string CHOZO_SCREW = "\x73\xef";
        private const string CHOZO_MORPH = "\x77\xef";
        private const string CHOZO_RESERVE = "\x7b\xef";
        private const string HIDDEN_ETANK = "\x7f\xef";
        private const string HIDDEN_MISSILE = "\x83\xef";
        private const string HIDDEN_SUPER = "\x87\xef";
        private const string HIDDEN_PB = "\x8b\xef";
        private const string HIDDEN_BOMB = "\x8f\xef";
        private const string HIDDEN_CHARGE = "\x93\xef";
        private const string HIDDEN_ICE = "\x97\xef";
        private const string HIDDEN_HIJUMP = "\x9b\xef";
        private const string HIDDEN_SPEED = "\x9f\xef";
        private const string HIDDEN_WAVE = "\xa3\xef";
        private const string HIDDEN_SPAZER = "\xa7\xef";
        private const string HIDDEN_SPRING = "\xab\xef";
        private const string HIDDEN_VARIA = "\xaf\xef";
        private const string HIDDEN_GRAVITY = "\xb3\xef";
        private const string HIDDEN_XRAY = "\xb7\xef";
        private const string HIDDEN_PLASMA = "\xbb\xef";
        private const string HIDDEN_GRAPPLE = "\xbf\xef";
        private const string HIDDEN_SPACE = "\xc3\xef";
        private const string HIDDEN_SCREW = "\xc7\xef";
        private const string HIDDEN_MORPH = "\xcb\xef";
        private const string HIDDEN_RESERVE = "\xcf\xef";
    }
}
