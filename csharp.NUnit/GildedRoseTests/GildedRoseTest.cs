using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void PositiveItemSellInDecreases()
    {
        var items = new List<Item> { new Item { Name = "Example", SellIn = 5, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(4));
    }
    
    [Test]
    public void ZeroItemSellInDecreases()
    {
        var items = new List<Item> { new Item { Name = "Example", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
    }

    [Test]
    public void ItemQualityDecreases()
    {
        var items = new List<Item> { new Item { Name = "Example", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(9));
    }
    
    [Test]
    public void ItemQualityCanNotBeNegative()
    {
        var items = new List<Item> { new Item { Name = "Example", SellIn = 10, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }
    
    [Test]
    public void ItemQualityDecreasesDoubleAfterSellBy()
    {
        var items = new List<Item> { new Item { Name = "Example", SellIn = -1, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(8));
    }
    
    [Test]
    public void SulfurasSellInDoesNotDecrease()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(10));
    }
    
    [Test]
    public void SulfurasQualityDoesNotDecrease()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(80));
    }

    [Test]
    public void AgedBrieQualityIncreases()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(1));
    }
    
    [Test]
    public void AgedBrieQualityIncreasesDoublePastSellBy()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -5, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(2));
    }
}