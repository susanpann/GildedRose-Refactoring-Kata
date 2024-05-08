using GildedRose.Items;
using GildedRose.QualityStrategies;

namespace GildedRose;

public class DailyUpdater
{
    private readonly LegendaryStrategy _legendaryStrategy = new();
    private readonly ConjuredStrategy _conjuredStrategy = new();
    private readonly BackstagePassStrategy _backstagePassStrategy = new();
    private readonly IncreaseQualityStrategy _increaseQualityStrategy = new();
    private readonly DecreaseQualityStrategy _decreaseQualityStrategy = new();

    public void UpdateQuality(Item item)
    {
        if (item.IsLegendaryItem()) _legendaryStrategy.Update(item);
        else if (item.IsConjuredItem()) _conjuredStrategy.Update(item);
        else if (item.IsBackstagePass()) _backstagePassStrategy.Update(item);
        else if (item.IsIncreaseQualityItem()) _increaseQualityStrategy.Update(item);
        else _decreaseQualityStrategy.Update(item);
    }

    public void UpdateSellByDate(Item item)
    {
        if (!item.IsLegendaryItem())
        {
            item.DecrementSellByDate();
        }
    }
}