namespace GildedRoseKata;

public static class ItemExtentions
{
    public static void ChangeQuality(this Item item, int rate)
    {
        var finalRate = item.PastSellByDate() ? rate * 2 : rate;
        item.Quality += finalRate;
        
        if (item.Quality > 50) 
        {
            item.Quality = 50;
        } 
        else if (item.Quality < 0)
        {
            item.Quality = 0;
        }
    }

    public static void DecrementSellByDate(this Item item)
    {
        item.SellIn--;
    }
    
    public static bool PastSellByDate(this Item item)
    {
        return item.SellIn <= 0;
    }

    public static bool IsLegendaryItem(this Item item)
    {
        return item.Name.StartsWith("Sulfuras", System.StringComparison.CurrentCultureIgnoreCase);
    }
    
    public static bool IsConjuredItem(this Item item)
    {
        return item.Name.StartsWith("Conjured", System.StringComparison.CurrentCultureIgnoreCase);
    }
    
    public static bool IsBackstagePass(this Item item)
    {
        return item.Name.StartsWith("Backstage pass", System.StringComparison.CurrentCultureIgnoreCase);
    }
    
    public static bool IsIncreaseQualityItem(this Item item)
    {
        return item.Name.Equals("Aged Brie", System.StringComparison.CurrentCultureIgnoreCase);
    }
}