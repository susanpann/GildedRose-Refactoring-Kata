using System.Collections.Generic;
using GildedRose.Items;

namespace GildedRose;

public class GildedRose
{
    private readonly IList<Item> _items;
    private readonly DailyUpdater updater = new();
    
    public GildedRose(IList<Item> items)
    {
        _items = items;
    }
    
    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            updater.UpdateQuality(item);
            updater.UpdateSellByDate(item);
        }
    }
}