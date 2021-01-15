using System.Collections.Generic;

namespace csharpcore
{
    static class Constants
    {
        public const int MinQuality = 0;
        public const int MaxQuality = 50;
    }
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
                if (Items[i].Name == "Aged Brie")
                {
                    UpdateAgedBrie(Items[i]);
                }
                else if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
                {
                    UpdateSulfuras(Items[i]);
                }
                else if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    UpdateBackstagePasses(Items[i]);
                }
                else if (Items[i].Name == "Conjured")
                {
                    UpdateConjured(Items[i]);
                }
                else
                {
                    UpdateNormalItem(Items[i]);
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    UpdateSellIn(Items[i]);

                    if (Items[i].Quality < 0)
                    {
                        RestoreMinQuality(Items[i]);
                    }
                    else if (Items[i].Quality > 50)
                    {
                        RestoreMaxQuality(Items[i]);
                    }
                }
            }
        }

        private void UpdateNormalItem(Item item)
        {
            if (item.SellIn > 0)
            {
                item.Quality--;
            }
            else
            {
                item.Quality -= 2;
            }
        }

        private void UpdateAgedBrie(Item item)
        {
            if (item.SellIn > 0)
            {
                item.Quality++;
            }
            else
            {
                item.Quality += 2;
            }
        }

        private void UpdateSulfuras(Item item)
        {
            item.Quality = 80;
        }

        private void UpdateBackstagePasses(Item item)
        {
            if (item.SellIn > 10)
            {
                item.Quality++;
            }
            else
            {
                if (item.SellIn <= 0)
                {
                    item.Quality = Constants.MinQuality;
                }
                else if (item.SellIn <= 5)
                {
                    item.Quality += 3;
                }
                else
                {
                    item.Quality += 2;
                }
            }
        }

        private void UpdateConjured(Item item)
        {
            if (item.SellIn > 0)
            {
                item.Quality -= 2;
            }
            else
            {
                item.Quality -= 4;
            }
        }

        private void UpdateSellIn(Item item)
        {
            item.SellIn--;
        }

        private void RestoreMinQuality(Item item)
        {
            item.Quality = Constants.MinQuality;
        }

        private void RestoreMaxQuality(Item item)
        {
            item.Quality = Constants.MaxQuality;
        }
    }
}
