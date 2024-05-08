using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;
    private IStrategy _updateStrategy;
    
    public GildedRose(IList<Item> items)
    {
        _items = items;
    }
    
    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            if (item.IsLegendaryItem()) _updateStrategy = new LegendaryStrategy();
            else if (item.IsConjuredItem()) _updateStrategy = new ConjuredStrategy();
            else if (item.IsBackstagePass()) _updateStrategy = new PassStrategy();
            else if (item.IsIncreaseQualityItem()) _updateStrategy = new IncreaseQualityStrategy();
            else _updateStrategy = new DecreaseQualityStrategy();
            
            _updateStrategy.Update(item);
            
            if (!item.IsLegendaryItem())
            {
                item.DecrementSellByDate();
            }
        }
    }
}