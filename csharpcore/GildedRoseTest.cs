using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        // Normal items - no Special Requirements

        [Fact]
        public void QualityAndSellIn_DecreaseByOne_WhenSellInAbove0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "NormalItem", SellIn = 15, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("NormalItem", Items[0].Name);
            Assert.Equal(14, Items[0].SellIn);
            Assert.Equal(19, Items[0].Quality);
        }

        [Fact]
        public void Quality_DecreasesBy2_WhenSellInEquals0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "NormalItem", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("NormalItem", Items[0].Name);
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        public void Quality_DecreasesBy2_WhenSellInBelow0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "NormalItem", SellIn = -5, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("NormalItem", Items[0].Name);
            Assert.Equal(-6, Items[0].SellIn);
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        public void MinQuality_HasAValueOf0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "NormalItem", SellIn = 15, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("NormalItem", Items[0].Name);
            Assert.Equal(14, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        // Aged Brie - As SellIn decreases, the quality increases

        [Fact]
        public void AgedBrieQuality_IncreasesBy1_WhenSellInAbove0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 15, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Aged Brie", Items[0].Name);
            Assert.Equal(14, Items[0].SellIn);
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        public void AgedBrieQuality_IncreasesBy2_WhenSellInEquals0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Aged Brie", Items[0].Name);
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        public void AgedBrieQuality_IncreasesBy2_WhenSellInBelow0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -5, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Aged Brie", Items[0].Name);
            Assert.Equal(-6, Items[0].SellIn);
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        public void MaxAgedBrieQuality_HasAValueOf50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 15, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Aged Brie", Items[0].Name);
            Assert.Equal(14, Items[0].SellIn);
            Assert.Equal(50, Items[0].Quality);
        }

        // Sulfuras - SellIn does not change and Quality remains constant at 80

        [Fact]
        public void SellInRemainsConstant_QualityAlwaysEquals80_ForSulfuras()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Sulfuras, Hand of Ragnaros", Items[0].Name);
            Assert.Equal(0, Items[0].SellIn);
            Assert.Equal(80, Items[0].Quality);
            Assert.Equal("Sulfuras, Hand of Ragnaros", Items[1].Name);
            Assert.Equal(-1, Items[1].SellIn);
            Assert.Equal(80, Items[1].Quality);
        }

        // Backstage passes - As SellIn decreases, Quality increases
        /* 
         * if SellIn <= 10 :: ΔQuality = 2
         * if SellIn <= 5 :: ΔQuality = 3
         * if SellIn <= 0 :: Quality = 0
         */

        [Fact]
        public void BackstagePassesQuality_IncreasesBy1_WhenSellInAbove10()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 10 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.Equal(14, Items[0].SellIn);
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        public void BackstagePassesQuality_IncreasesBy2_WhenSellInEquals10()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        public void BackstagePassesQuality_IncreasesBy2_WhenSellInAbove5AndBelow10()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 10 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.Equal(7, Items[0].SellIn);
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        public void BackstagePassesQuality_IncreasesBy3_WhenSellInEquals5()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.Equal(4, Items[0].SellIn);
            Assert.Equal(13, Items[0].Quality);
        }

        [Fact]
        public void BackstagePassesQuality_IncreasesBy3_WhenSellInAbove0AndBelow5()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 10 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.Equal(2, Items[0].SellIn);
            Assert.Equal(13, Items[0].Quality);
        }

        [Fact]
        public void BackstagePassesQuality_Equals0_WhenSellInEquals0()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void BackstagePassesQuality_Equals0_WhenSellInBelow0()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -5, Quality = 10 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.Equal(-6, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        // Conjured - ΔQuality(Conjured) = 2*ΔQuality(NormalItem)
        [Fact]
        public void ConjuredQualityAndSellIn_DecreaseBy2_WhenSellInAbove0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 15, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Conjured", Items[0].Name);
            Assert.Equal(14, Items[0].SellIn);
            Assert.Equal(18, Items[0].Quality);
        }

        [Fact]
        public void ConjuredQuality_DecreasesBy4_WhenSellInEquals0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Conjured", Items[0].Name);
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(6, Items[0].Quality);
        }

        [Fact]
        public void ConjuredQuality_DecreasesBy4_WhenSellInBelow0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = -5, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Conjured", Items[0].Name);
            Assert.Equal(-6, Items[0].SellIn);
            Assert.Equal(6, Items[0].Quality);
        }

        [Fact]
        public void ConjuredMinQuality_HasAValueOf0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 15, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Conjured", Items[0].Name);
            Assert.Equal(14, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }
    }
}