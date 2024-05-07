using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    private readonly string AgedBrie = "Aged Brie";
    private readonly string Sulfuras = "Sulfuras, Hand of Ragnaros";
    private readonly string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";

    private readonly int MaxQuality = 50;
    
    public GildedRose(IList<Item> items)
    {
        _items = items;
    }
    
    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            if (item.Name == AgedBrie || item.Name == BackstagePass)
            {
                if (item.Quality < MaxQuality)
                {
                    item.Quality++;

                    if (item.Name == BackstagePass && item.Quality < MaxQuality)
                    {
                        if (item.SellIn < 11)
                        {
                            item.Quality++;
                        }

                        if (item.SellIn < 6)
                        {
                            item.Quality++;
                        }
                    }
                }
            }
            else if (item.Quality > 0 && item.Name != Sulfuras)
            {
                item.Quality--;
            }
            
            if (item.Name != Sulfuras)
            {
                item.SellIn--;
            }
            
            if (item.SellIn >= 0) continue;
            
            if (item.Name == AgedBrie)
            {
                if (item.Quality < MaxQuality)
                {
                    item.Quality++;
                }
            }
            else if (item.Name == BackstagePass)
            {
                item.Quality = item.Quality - item.Quality;
            }
            else if (item.Name != Sulfuras && item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }
}