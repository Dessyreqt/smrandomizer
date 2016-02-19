using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMetroidRandomizer
{
    public interface IRomPlms
    {
        List<Plm> Plms { get; set; }
        string DifficultyName { get; }
        string SeedFileString { get; }
        string SeedRomString { get; }

        void ResetPlms();
        List<Plm> GetAvailablePlms(List<ItemType> haveItems);
        List<Plm> GetUnavailablePlms(List<ItemType> haveItems);
        void TryInsertCandidateItem(List<Plm> currentPlms, List<ItemType> candidateItemList, ItemType candidateItem);
        int GetInsertedPlm(List<Plm> currentPlms, ItemType insertedItem, SeedRandom random);
        ItemType GetInsertedItem(List<Plm> currentPlms, List<ItemType> itemPool, SeedRandom random);
        List<ItemType> GetItemPool();
    }
}
