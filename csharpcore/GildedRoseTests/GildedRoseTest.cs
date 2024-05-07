using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void Foo()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 10 } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].Name, Is.EqualTo("foo"));
        Assert.That(items[0].SellIn, Is.EqualTo(9));
        Assert.That(items[0].Quality, Is.EqualTo(9));
    }

    [Test]
    public void QualityIsNever_Negative()
    {
        var itemName = "anotheritem-12928";
        var items = new List<Item> { new Item { Name = itemName, SellIn = 0, Quality = 0 } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(-1));
        Assert.That(testItem.Quality, Is.GreaterThanOrEqualTo(0));
    }
    
    [Test]
    public void QualityIsNever_AboveFifty()
    {
        var itemName = "Aged Brie";
        var items = new List<Item> { new Item { Name = itemName, SellIn = 10, Quality = 50 } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(9));
        Assert.That(testItem.Quality, Is.GreaterThanOrEqualTo(50));
    }
    
    [Test]
    public void QualityDegradesNormal_BeforeSellDate()
    {
        var itemName = "anotheritem-sdfgrtari";
        var items = new List<Item> { new Item { Name = itemName, SellIn = 10, Quality = 10 } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(9));
        Assert.That(testItem.Quality, Is.GreaterThanOrEqualTo(9));
    }
    
    [Test]
    public void QualityDegradesDouble_PastSellDate()
    {
        var itemName = "anotheritem-23580823";
        var items = new List<Item> { new Item { Name = itemName, SellIn = 0, Quality = 40 } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(-1));
        Assert.That(testItem.Quality, Is.EqualTo(38));
    }

    [Test]
    public void BrieQualityIncreases_BeforeSellDate()
    {
        var itemName = "Aged Brie";
        var items = new List<Item> { new Item { Name = itemName, SellIn = 1, Quality = 20 } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(0));
        Assert.That(testItem.Quality, Is.EqualTo(21));
    }
    
    [Test]
    public void BrieQualityIncreasesDouble_PastSellDate()
    {
        var itemName = "Aged Brie";
        var items = new List<Item> { new Item { Name = itemName, SellIn = 0, Quality = 20 } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(-1));
        Assert.That(testItem.Quality, Is.EqualTo(22));
    }
    
    [Test]
    public void SulfurasQuality_NeverChanges()
    {
        var itemName = "Sulfuras, Hand of Ragnaros";
        var items = new List<Item> { new Item { Name = itemName, SellIn = 1, Quality = 80 } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.Quality, Is.EqualTo(80));
        
        app.UpdateQuality();

        var testItemAgain = items[0];
        Assert.That(testItemAgain.Name, Is.EqualTo(itemName));
        Assert.That(testItemAgain.Quality, Is.EqualTo(80));
    }
    
    [Test]
    public void SulfurasSellDate_NeverChanges()
    {
        var itemName = "Sulfuras, Hand of Ragnaros";
        var items = new List<Item> { new Item { Name = itemName, SellIn = 10, Quality = 80 } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(10));
        
        app.UpdateQuality();

        var testItemAgain = items[0];
        Assert.That(testItemAgain.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(10));
    }
    
    [Test]
    public void BackstagePassQualityIncreases_BeforeSellDate()
    {
        var itemName = "Backstage passes to a TAFKAL80ETC concert";
        var items = new List<Item> { new Item { Name = itemName, SellIn = 15, Quality = 10 } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(14));
        Assert.That(testItem.Quality, Is.EqualTo(11));
    }
    
    [Test]
    public void BackstagePassQualityIncreasesDouble_WithinTenDaysOfSellDate()
    {
        var itemName = "Backstage passes to a TAFKAL80ETC concert";
        var items = new List<Item> { new Item { Name = itemName, SellIn = 10, Quality = 10 } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(9));
        Assert.That(testItem.Quality, Is.EqualTo(12));
    }
    
    [Test]
    public void BackstagePassQualityIncreasesTriple_WithinFiveDaysOfSellDate()
    {
        var itemName = "Backstage passes to a TAFKAL80ETC concert";
        var items = new List<Item> { new Item { Name = itemName, SellIn = 5, Quality = 10 } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(4));
        Assert.That(testItem.Quality, Is.EqualTo(13));
    }
    
        
    [Test]
    public void BackstagePassQualityBecomesZero_PastSellDate()
    {
        var itemName = "Backstage passes to a TAFKAL80ETC concert";
        var items = new List<Item> { new Item { Name = itemName, SellIn = 0, Quality = 10 } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(-1));
        Assert.That(testItem.Quality, Is.EqualTo(0));
    }
} 