using SuperMetroidRandomizer.Random;

namespace SuperMetroidRandomizer.Rom
{
    public class RomPlmsFactory
    {
        public static IRomPlms GetRomPlms(RandomizerDifficulty difficulty)
        {
            switch (difficulty)
            {
                case RandomizerDifficulty.Casual:
                    return new RomPlmsCasual();
                case RandomizerDifficulty.Masochist:
                    return new RomPlmsMasochist();
                case RandomizerDifficulty.Insane:
                    return new RomPlmsInsane();
                default:
                    return new RomPlmsSpeedrunner();
            }
        }
    }
}
