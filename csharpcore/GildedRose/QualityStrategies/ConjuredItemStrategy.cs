using GildedRose.Items;

namespace GildedRose.QualityStrategies;

public class ConjuredStrategy : IStrategy
{
    public void Update(Item item)
    {
        if (item.Quality <= 0) return;
        
        item.ChangeQuality(-2);
    }
}