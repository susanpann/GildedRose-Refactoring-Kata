using GildedRose.Items;
using GildedRoseKata;

namespace GildedRose.QualityStrategies;

public class IncreaseQualityStrategy : IStrategy
{
    public void Update(Item item)
    {
        if (item.Quality >= 50) return;

        item.ChangeQuality(1);
    }
}
