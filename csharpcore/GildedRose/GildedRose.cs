using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    private readonly string AgedBrie = "Aged Brie";
    private readonly string Sulfuras = "Sulfuras, Hand of Ragnaros";
    private readonly string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";

    private readonly int DegradeRate = -1;
    private readonly int MaxQuality = 50;
    
    public GildedRose(IList<Item> items)
    {
        _items = items;
    }
    
    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            if (item.Name == Sulfuras) continue;
            
            if (item.Name == AgedBrie || item.Name == BackstagePass)
            {
                IncreaseQuality(item);
            }
            else
            {
                DecreaseQuality(item);
            }
            
            item.SellIn--;
        }
    }
    
    private void IncreaseQuality(Item item)
    {
        if (item.Name == BackstagePass && PastSellByDate(item.SellIn))
        {
            item.Quality = 0;
            return;
        }
        
        if (item.Quality >= MaxQuality) return;

        if (item.Name == BackstagePass)
        {
            if (item.SellIn <= 5)
            {
                ChangeQuality(item, -DegradeRate * 3);
            }
            else if (item.SellIn <= 10)
            {
                ChangeQuality(item, -DegradeRate * 2);
            }
            else
            {
                ChangeQuality(item, -DegradeRate);
            }
        }
        
        if (item.Name == AgedBrie)
        {
            if (PastSellByDate(item.SellIn))
            {
                ChangeQuality(item, -DegradeRate * 2);
            } else
            {
                ChangeQuality(item, -DegradeRate);
            }
        }
    }

    private void DecreaseQuality(Item item)
    {
        if (item.Quality <= 0) return;

        if (PastSellByDate(item.SellIn))
        {
            ChangeQuality(item, DegradeRate * 2);
        }
        else
        {
            ChangeQuality(item, DegradeRate);
        }
    }

    private void ChangeQuality(Item item, int rate)
    {
        item.Quality += rate;
        
        if (item.Quality > 50) 
        {
            item.Quality = 50;
        } 
        else if (item.Quality < 0)
        {
            item.Quality = 0;
        }
    }
    
    private bool PastSellByDate(int sellIn)
    {
        return sellIn <= 0;
    }
}