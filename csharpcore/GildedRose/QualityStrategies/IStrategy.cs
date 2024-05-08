using GildedRose.Items;

namespace GildedRose.QualityStrategies;

public interface IStrategy
{
    void Update(Item item);
}