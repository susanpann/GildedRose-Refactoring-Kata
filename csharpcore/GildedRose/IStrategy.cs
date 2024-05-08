using GildedRoseKata;

public interface IStrategy
{
    void Update(Item item);
}

class DecreaseQualityStrategy : IStrategy
{
    public void Update(Item item)
    {
        if (item.Quality <= 0) return;
        
        item.ChangeQuality(-1);
    }
}

class IncreaseQualityStrategy : IStrategy
{
    public void Update(Item item)
    {
        if (item.Quality >= 50) return;

        item.ChangeQuality(1);
    }
}

class PassStrategy : IStrategy
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

class LegendaryStrategy : IStrategy
{
    public void Update(Item item)
    {
    }
}

class ConjuredStrategy : IStrategy
{
    public void Update(Item item)
    {
        if (item.Quality <= 0) return;
        
        item.ChangeQuality(-2);
    }
}