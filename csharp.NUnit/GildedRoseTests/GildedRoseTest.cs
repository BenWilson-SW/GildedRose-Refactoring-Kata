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
}