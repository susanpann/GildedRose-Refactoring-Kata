using System.Collections.Generic;
using GildedRose.Items;
using GildedRose.QualityStrategies;

namespace GildedRose;

public class GildedRose
{
    private readonly IList<Item> _items;
    private readonly DailyUpdater updater = new DailyUpdater();
    
    public GildedRose(IList<Item> items)
    {
        _items = items;
    }
    
    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            updater.UpdateQuality(item);
            if (!item.IsLegendaryItem())
            {
                item.DecrementSellByDate();
            }
        }
    }
}

public class DailyUpdater
{
    private IStrategy _updateStrategy;

    public void UpdateQuality(Item item)
    {
        if (item.IsLegendaryItem()) _updateStrategy = new LegendaryStrategy();
        else if (item.IsConjuredItem()) _updateStrategy = new ConjuredStrategy();
        else if (item.IsBackstagePass()) _updateStrategy = new BackstagePassStrategy();
        else if (item.IsIncreaseQualityItem()) _updateStrategy = new IncreaseQualityStrategy();
        else _updateStrategy = new DecreaseQualityStrategy();
            
        _updateStrategy.Update(item);
    }

    public void UpdateSellByDate(Item item)
    {
        
    }
}