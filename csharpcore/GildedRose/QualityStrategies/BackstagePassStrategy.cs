using GildedRose.Items;
using GildedRoseKata;

namespace GildedRose.QualityStrategies;

public class BackstagePassStrategy : IStrategy
{
    public void Update(Item item)
    {
        if (item.PastSellByDate())
        {
            item.Quality = 0;
            return;
        }
        
        if (item.Quality >= 50) return;
        
        if (item.SellIn <= 5)
        {
            item.ChangeQuality(3);
        }
        else if (item.SellIn <= 10)
        {
            item.ChangeQuality(2);
        }
        else
        {
            item.ChangeQuality(1);
        }
    }
}