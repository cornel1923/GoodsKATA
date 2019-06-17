After fetching the sources I start looking on the requirements in order to better understand the current problem.

Beside the information of the specific Items like (AgedBrie, Sulfures and so on) that has specific rules on computing the  
quality value I understood that the main issue is the "UpdateMethod" method.
Because is so long and hard to follow a specific case I start the refactoring process.

Before starting the refactoring I've took a look on the existing unit tests but I didn't saw any that could help me on 
this refactoring process.
So, I start looking on the final results from "ThirtyDays.txt" and I start writting my on tests based on
those results (GlidedRoseDaysRunnerTest.cs).

Example of the test: 
For this item(+5 Dexterity Vest) I run the GildedRose.UpdateMethod(from private UpdateItem) for 30 days and 
assert the values (from the last day) with the results from output file(from last day).

Item updatedItem = UpdateItem(new Item
{
	Name = "+5 Dexterity Vest",
	SellIn = 10,
	Quality = 20
}, 30);

Assert.IsTrue(updatedItem.SellIn == -20 && updatedItem.Quality == 0);

I did this for the rest of the items.
_________________________________________________

Now, beeing covered by the tests I start the implementation part.

I saw on the current logic(UpdateMethod function) a set of rules that can apply to a specific item type.
I've created a new class "GoodsRules.cs" that contain the rules specific to an item type.
We also have a default rule that can be applied to any new added item.

When the new item "Conjured Mana Cake" was added, we only had to go on this class, add a new key to the dictionary and setup the rule.
HandleConjuredManaCake rule could also call the HandleDefaultGood rule and then a new update to quality could be performed. 
(I used only the default values).

This implementation was made in around 2 hours. I stoped here considering also your sugestion about timing.
There are things that can be further done like moving keys to constants or find a better template rule can 
be called on the specific ones and so one.
