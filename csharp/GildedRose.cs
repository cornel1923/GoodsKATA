using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];

                if (GoodsRules.Rules.ContainsKey(item.Name))
                {
                    GoodsRules.Rules[item.Name](item);
                }
                else
                {
                    GoodsRules.Rules["Default"](item);
                }
            }
        }
    }
}