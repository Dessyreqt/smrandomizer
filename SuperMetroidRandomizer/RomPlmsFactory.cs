using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMetroidRandomizer
{
    public class RomPlmsFactory
    {
        public static IRomPlms GetRomPlms(RandomizerDifficulty difficulty)
        {
            switch (difficulty)
            {
                case RandomizerDifficulty.Easy:
                    return new RomPlmsEasy();
                case RandomizerDifficulty.Hard:
                    return new RomPlmsHard();
                default:
                    return new RomPlmsNormal();
            }
        }
    }
}
