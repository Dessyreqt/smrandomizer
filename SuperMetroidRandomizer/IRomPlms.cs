using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMetroidRandomizer
{
    public interface IRomPlms
    {
        List<Plm> Plms { get; set; }

        void ResetPlms();
        List<Plm> GetAvailablePlms(List<ItemType> haveItems, RandomizerDifficulty difficulty);
        List<Plm> GetUnavailablePlms(List<ItemType> haveItems, RandomizerDifficulty difficulty);
    }
}
