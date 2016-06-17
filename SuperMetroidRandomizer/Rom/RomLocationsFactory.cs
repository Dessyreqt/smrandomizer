using SuperMetroidRandomizer.Random;

namespace SuperMetroidRandomizer.Rom
{
    public class RomLocationsFactory
    {
        public static IRomLocations GetRomLocations(RandomizerDifficulty difficulty)
        {
            switch (difficulty)
            {
                case RandomizerDifficulty.Casual:
                    return new RomLocationsCasual();
                case RandomizerDifficulty.Masochist:
                    return new RomLocationsMasochist();
                case RandomizerDifficulty.Insane:
                    return new RomLocationsInsane();
                default:
                    return new RomLocationsSpeedrunner();
            }
        }
    }
}
