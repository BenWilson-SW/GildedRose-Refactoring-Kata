using System;
using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    const String NORMAL_ITEM_NAME = "Example";
    const String SULFURAS_ITEM_NAME = "Sulfuras, Hand of Ragnaros";
    const String AGED_BRIE_ITEM_NAME = "Aged Brie";
    const String BACKSTAGE_PASS_ITEM_NAME = "Backstage passes to a TAFKAL80ETC concert";
    const String CONJURED_ITEM_NAME = "Conjured Mana Cake";
    
    [Test]
    public void PositiveItemSellInDecreases()
    {
        var items = new List<Item> { new Item { Name = NORMAL_ITEM_NAME, SellIn = 5, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(4));
    }
    
    [Test]
    public void ZeroItemSellInDecreases()
    {
        var items = new List<Item> { new Item { Name = NORMAL_ITEM_NAME, SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
    }

    [Test]
    public void ItemQualityDecreases()
    {
        var items = new List<Item> { new Item { Name = NORMAL_ITEM_NAME, SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(9));
    }
    
    [Test]
    public void ItemQualityCanNotBeNegative()
    {
        var items = new List<Item> { new Item { Name = NORMAL_ITEM_NAME, SellIn = 10, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }
    
    [Test]
    public void ItemQualityDecreasesDoubleAtSellBy()
    {
        var items = new List<Item> { new Item { Name = NORMAL_ITEM_NAME, SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(8));
    }
    
    [Test]
    public void ItemQualityDecreasesDoubleAfterSellBy()
    {
        var items = new List<Item> { new Item { Name = NORMAL_ITEM_NAME, SellIn = -1, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(8));
    }
    
    [Test]
    public void SulfurasSellInDoesNotDecrease()
    {
        var items = new List<Item> { new Item { Name = SULFURAS_ITEM_NAME, SellIn = 10, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(10));
    }
    
    [Test]
    public void SulfurasQualityDoesNotDecrease()
    {
        var items = new List<Item> { new Item { Name = SULFURAS_ITEM_NAME, SellIn = 10, Quality = 80 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(80));
    }

    [Test]
    public void AgedBrieQualityIncreases()
    {
        var items = new List<Item> { new Item { Name = AGED_BRIE_ITEM_NAME, SellIn = 10, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(1));
    }
    
    [Test]
    public void AgedBrieQualityIncreasesDoublePastSellBy()
    {
        var items = new List<Item> { new Item { Name = AGED_BRIE_ITEM_NAME, SellIn = -5, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(2));
    }
    
    [Test]
    public void BackstagePassQualityIncreases()
    {
        var items = new List<Item> { new Item { Name = BACKSTAGE_PASS_ITEM_NAME, SellIn = 15, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(1));
    }
    
    [Test]
    public void BackstagePassQualityIncreasesDoubleAtTen()
    {
        var items = new List<Item> { new Item { Name = BACKSTAGE_PASS_ITEM_NAME, SellIn = 10, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(2));
    }
    
    [Test]
    public void BackstagePassQualityIncreasesTripleAtFive()
    {
        var items = new List<Item> { new Item { Name = BACKSTAGE_PASS_ITEM_NAME, SellIn = 5, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(3));
    }
    
    [Test]
    public void BackstagePassQualityZeroAfterSellBy()
    {
        var items = new List<Item> { new Item { Name = BACKSTAGE_PASS_ITEM_NAME, SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }
    
    [Test]
    public void QualityCanNotBeOverFifty()
    {
        var items = new List<Item> { new Item { Name = BACKSTAGE_PASS_ITEM_NAME, SellIn = 1, Quality = 49 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }
    
    [Test]
    public void ConjuredItemsLoseQualityDouble()
    {
        var items = new List<Item> { new Item { Name = CONJURED_ITEM_NAME, SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(4));
    }
    
    [Test]
    public void ConjuredItemsLoseQualityQuadruplePastSellBy()
    {
        var items = new List<Item> { new Item { Name = CONJURED_ITEM_NAME, SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(6));
    }
}