using GildedRose.Items;
using GildedRoseKata;

namespace GildedRose.QualityStrategies;

public interface IStrategy
{
    void Update(Item item);
}