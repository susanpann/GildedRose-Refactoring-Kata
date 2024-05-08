using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    [TestCase(10, 0)]
    [TestCase(-10, 0)]
    public void QualityIsNever_Negative(int sellIn, int quality)
    {
        var itemName = "anotheritem-12928";
        var items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(sellIn - 1));
        Assert.That(testItem.Quality, Is.EqualTo(0));
    }
    
    [Theory]
    [TestCase("Aged Brie",10, 50)]
    [TestCase("Aged Brie", -2, 49)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 1, 48)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 5, 49)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 10, 50)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 15, 50)]
    public void QualityIsNever_AboveFifty(string itemName, int sellIn, int quality)
    {
        var items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(sellIn - 1));
        Assert.That(testItem.Quality, Is.EqualTo(50)); 
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
        Assert.That(testItem.Quality, Is.EqualTo(9));
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
    
    [Theory]
    [TestCase(50, 49, 50)]
    [TestCase(11, 50, 50)]
    [TestCase(12, 0, 1)]
    public void BackstagePassQualityIncreases_BeforeSellDate(int sellIn, int quality, int expectedQuality)
    {
        var itemName = "Backstage passes to a TAFKAL80ETC concert";
        var items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(sellIn - 1));
        Assert.That(testItem.Quality, Is.EqualTo(expectedQuality));
    }
    
    [Theory]
    [TestCase(10, 48, 50)]
    [TestCase(10, 49, 50)]
    [TestCase(6, 0, 2)]
    public void BackstagePassQualityIncreasesDouble_WithinTenDaysOfSellDate(int sellIn, int quality, int expectedQuality)
    {
        var itemName = "Backstage passes to a TAFKAL80ETC concert";
        var items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(sellIn - 1));
        Assert.That(testItem.Quality, Is.EqualTo(expectedQuality));
    }
    
    [Theory]
    [TestCase(5, 50, 50)]
    [TestCase(5, 49, 50)]
    [TestCase(5, 47, 50)]
    [TestCase(1, 49, 50)]
    [TestCase(1, 0, 3)]
    public void BackstagePassQualityIncreasesTriple_WithinFiveDaysOfSellDate(int sellIn, int quality, int expectedQuality)
    {
        var itemName = "Backstage passes to a TAFKAL80ETC concert";
        var items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(sellIn - 1));
        Assert.That(testItem.Quality, Is.EqualTo(expectedQuality));
    }
    
    [Theory]
    [TestCase(0, 50, 0)]
    [TestCase(-5, 49, 0)]
    [TestCase(0, -50, 0)]
    [TestCase(-10, -1, 0)]
    public void BackstagePassQualityBecomesZero_PastSellDate(int sellIn, int quality, int expectedQuality)
    {
        var itemName = "Backstage passes to a TAFKAL80ETC concert";
        var items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
        
        var app = new GildedRose(items);
        app.UpdateQuality();

        var testItem = items[0];
        Assert.That(testItem.Name, Is.EqualTo(itemName));
        Assert.That(testItem.SellIn, Is.EqualTo(sellIn - 1));
        Assert.That(testItem.Quality, Is.EqualTo(expectedQuality));
    }
} 