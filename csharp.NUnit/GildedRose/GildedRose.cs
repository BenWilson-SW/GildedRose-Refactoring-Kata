using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            var item = Items[i];

            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                continue;                
            }
            
            int newQuality;
            switch (item.Name)
            {
                case "Aged Brie":
                    newQuality = GetNewBrieQuality(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    newQuality = GetNewBackstagePassQuality(item);
                    break;
                case "Conjured Mana Cake":
                    newQuality = GetNewConjuredQuality(item);
                    break;
                default:
                    newQuality = GetNewItemQuality(item);
                    break;
            }
            
            item.Quality = Math.Clamp(newQuality, 0, 50);
            item.SellIn -= 1;
        }
    }

    private int GetNewBrieQuality(Item brie)
    {
        if (brie.SellIn <= 0)
        {
            return brie.Quality + 2;
        }

        return brie.Quality + 1;
    }
    
    private int GetNewBackstagePassQuality(Item backstagePass)
    {
        if (backstagePass.SellIn <= 0)
        {
            return 0;
        }

        if (backstagePass.SellIn <= 5)
        {
            return backstagePass.Quality + 3;
        }
        
        if (backstagePass.SellIn <= 10)
        {
            return backstagePass.Quality + 2;
        }

        return backstagePass.Quality + 1;
    }

    private int GetNewConjuredQuality(Item conjuredItem)
    {
        if (conjuredItem.SellIn <= 0)
        {
            return conjuredItem.Quality - 4;
        }

        return conjuredItem.Quality - 2;
    }

    private int GetNewItemQuality(Item item)
    {
        if (item.SellIn <= 0)
        {
            return item.Quality - 2;
        }

        return item.Quality - 1;
    }
}