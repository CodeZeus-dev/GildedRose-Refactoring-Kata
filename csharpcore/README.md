# Gilded Rose Tech Test

In this project, the aim is to update the buy-and-sell system of the Gilded Rose team,
by adding a new feature to the system.

The steps followed in order for this process to be implemented were,

1. To write Unit Tests for the already implemented system;
2. To refactor the UpdateQuality() method within the GildedRose Class without changing
anything within the Item Class;
3. To write Unit Tests for the new feature (Conjured Items);
4. To write the appropriate code for making the tests pass;

## Approach & Methodology

The initial form of the UpdateQuality method was based on nested conditionals with
repetitive conditions within them. As this approach did not favor readability and
debugging (if need be) as well as any potential updates to the system, the methodology
followed was the following,

1. Replacing conditionals with simpler ones that check only for the item's name in the
Items list;
2. Calling the appropriate UpdateItem private method based on the type of the item;
3. Implementing further conditionals within the specialised private methods based on
the requirements of each item type;
4. Executing the UpdateSellIn, RestoreMinQuality and RestoreMaxQuality private methods
only if the item is not the "Sulfuras" legendary item;

In terms of the Unit Testing, XUnit is used and the tests are implemented according to
the item type, as each type has its own requirements, starting from normal items with no
special requirements and moving towards testing the new feature (Conjured Items).

## Further Refactoring

The current version could be further refactored by creating a new class per item type,
which will accomodate the respective item Update method, so that we split responsibilities
between classes.