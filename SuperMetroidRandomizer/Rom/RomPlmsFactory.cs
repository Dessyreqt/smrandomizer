using SuperMetroidRandomizer.Random;

namespace SuperMetroidRandomizer.Rom
{
    public class RomPlmsFactory
    {
        public static IRomPlms GetRomPlms(RandomizerDifficulty difficulty)
        {
            switch (difficulty)
            {
                case RandomizerDifficulty.Easy:
                    return new RomPlmsCasual();
                case RandomizerDifficulty.Hard:
                    return new RomPlmsMasochist();
                default:
                    return new RomPlmsSpeedrunner();
            }
        }
    }
}
