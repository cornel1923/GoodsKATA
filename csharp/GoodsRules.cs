using System;
using System.Collections.Generic;

namespace csharp
{
    public class GoodsRules
    {
        private const int DefaultQualityValue = 1;
        private const int DefaultSellInValue = 1;

        public static Dictionary<string, Action<Item>> Rules = new Dictionary<string, Action<Item>>()
        {
            { "Aged Brie", HandleAgedBrie },
            { "Backstage passes to a TAFKAL80ETC concert", HandleBackstagePassesToATAFKAL80ETCConcert},
            { "Sulfuras, Hand of Ragnaros", HandleSulfurasHandOfRagnaros },
            { "Conjured Mana Cake", HandleConjuredManaCake},
            { "Default", HandleDefaultGood },
        };

        private static void HandleAgedBrie(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            LowerSellIn(item);

            if (item.SellIn < 0 && item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }

        private static void HandleBackstagePassesToATAFKAL80ETCConcert(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;

                if (item.SellIn < 11 && item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }

                if (item.SellIn < 6 && item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }

            LowerSellIn(item);

            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - item.Quality;
            }
        }

        private static void HandleSulfurasHandOfRagnaros(Item item)
        {
            //do nothing
        }

        private static void HandleConjuredManaCake(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - (DefaultQualityValue * 2);
            }

            LowerSellIn(item);

            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality = item.Quality - (DefaultQualityValue * 2);
            }
        }

        private static void HandleDefaultGood(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - DefaultQualityValue;
            }

            LowerSellIn(item);

            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }

        private static void LowerSellIn(Item item)
        {
            item.SellIn = item.SellIn - DefaultSellInValue;
        }
    }
}