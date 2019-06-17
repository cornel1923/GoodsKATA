using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    [TestFixture]
    public class GlidedRoseDaysRunnerTest
    {
        public GildedRose App { get; set; }

        [Test]
        public void Test_plus5DexterityVest_30Days()
        {
            Item updatedItem = UpdateItem(new Item
            {
                Name = "+5 Dexterity Vest",
                SellIn = 10,
                Quality = 20
            }, 30);

            Assert.IsTrue(updatedItem.SellIn == -20 && updatedItem.Quality == 0);
        }

        [Test]
        public void Test_AgedBrie_30Days()
        {
            Item updatedItem = UpdateItem(new Item
            {
                Name = "Aged Brie",
                SellIn = 2,
                Quality = 0
            }, 30);

            Assert.IsTrue(updatedItem.SellIn == -28 && updatedItem.Quality == 50);
        }

        [Test]
        public void Test_ElixirOfTheMongoose_30Days()
        {
            Item updatedItem = UpdateItem(new Item
            {
                Name = "Elixir of the Mongoose",
                SellIn = 5,
                Quality = 7
            }, 30);

            Assert.IsTrue(updatedItem.SellIn == -25 && updatedItem.Quality == 0);
        }

        [Test]
        public void Test_SulfurasHandofRagnaros_30Days_SellInZero()
        {
            Item updatedItem = UpdateItem(new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 0,
                Quality = 80
            }, 30);

            Assert.IsTrue(updatedItem.SellIn == 0 && updatedItem.Quality == 80);
        }

        [Test]
        public void Test_SulfurasHandofRagnaros_30Days_SellInMinusOne()
        {
            Item updatedItem = UpdateItem(new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = -1,
                Quality = 80
            }, 30);

            Assert.IsTrue(updatedItem.SellIn == -1 && updatedItem.Quality == 80);
        }

        [Test]
        public void Test_BackstagePassesToATAFKAL80ETCConcert_30Days_SellInMinusOne()
        {
            Item updatedItem = UpdateItem(new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            }, 30);

            Assert.IsTrue(updatedItem.SellIn == -15 && updatedItem.Quality == 0);
        }

        [Test]
        public void Test_BackstagePassesToATAFKAL80ETCConcert_30Days_SellIn15()
        {
            Item updatedItem = UpdateItem(new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            }, 30);

            Assert.IsTrue(updatedItem.SellIn == -15 && updatedItem.Quality == 0);
        }

        [Test]
        public void Test_BackstagePassesToATAFKAL80ETCConcert_30Days_SellIn10()
        {
            Item updatedItem = UpdateItem(new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 40
            }, 30);

            Assert.IsTrue(updatedItem.SellIn == -20 && updatedItem.Quality == 0);
        }

        [Test]
        public void Test_BackstagePassesToATAFKAL80ETCConcert_30Days_SellIn5()
        {
            Item updatedItem = UpdateItem(new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 49
            }, 30);

            Assert.IsTrue(updatedItem.SellIn == -25 && updatedItem.Quality == 0);
        }

        [Test]
        public void Test_ConjuredManaCake_30Days()
        {
            Item updatedItem = UpdateItem(new Item
            {
                Name = "Conjured Mana Cake",
                SellIn = 3,
                Quality = 6
            }, 30);

            Assert.IsTrue(updatedItem.SellIn == -27 && updatedItem.Quality == 0);
        }

        private Item UpdateItem(Item item, int numberOfDays)
        {
            IList<Item> items = new List<Item> { item };

            App = new GildedRose(items);

            for (var i = 0; i < 30; i++)
            {
                App.UpdateQuality();
            }

            return items.Single();
        }
    }
}