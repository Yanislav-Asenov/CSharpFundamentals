using NUnit.Framework;

[TestFixture]
public class InventoryTests
{
    [Test]
    public void AddCommonItemShouldIncreaseBonusStats()
    {
        // Assert
        IInventory inventory = new HeroInventory();
        IItem item = new CommonItem("Test Item 1", 15, 15, 15, 15, 15);

        // Act
        inventory.AddCommonItem(item);

        // Assert
        Assert.AreEqual(15, inventory.TotalStrengthBonus);
        Assert.AreEqual(15, inventory.TotalAgilityBonus);
        Assert.AreEqual(15, inventory.TotalIntelligenceBonus);
        Assert.AreEqual(15, inventory.TotalHitPointsBonus);
        Assert.AreEqual(15, inventory.TotalDamageBonus);
    }

    [Test]
    public void AddMultipleCommonItemsShouldIncreaseTotalBonusStats()
    {
        // Assert
        IInventory inventory = new HeroInventory();
        IItem item1 = new CommonItem("Test Item 1", 15, 15, 15, 15, 15);
        IItem item2 = new CommonItem("Test Item 2", 15, 15, 15, 15, 15);
        IItem item3 = new CommonItem("Test Item 3", 30, 30, 30, 30, 30);

        // Act
        inventory.AddCommonItem(item1);
        inventory.AddCommonItem(item2);
        inventory.AddCommonItem(item3);

        // Assert
        Assert.AreEqual(60, inventory.TotalStrengthBonus);
        Assert.AreEqual(60, inventory.TotalAgilityBonus);
        Assert.AreEqual(60, inventory.TotalIntelligenceBonus);
        Assert.AreEqual(60, inventory.TotalHitPointsBonus);
        Assert.AreEqual(60, inventory.TotalDamageBonus);
    }

    [Test]
    public void AddMultipleItemsWithTotalValueLargerThanIntegerShouldWork()
    {
        // Assert
        IInventory inventory = new HeroInventory();
        IItem item1 = new CommonItem("Test Item 1", int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);
        IItem item2 = new CommonItem("Test Item 2", int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);

        // Act
        inventory.AddCommonItem(item1);
        inventory.AddCommonItem(item2);

        // Assert
        long expectedResult = 0;
        expectedResult += int.MaxValue;
        expectedResult += int.MaxValue;

        Assert.AreEqual(expectedResult, inventory.TotalStrengthBonus);
        Assert.AreEqual(expectedResult, inventory.TotalAgilityBonus);
        Assert.AreEqual(expectedResult, inventory.TotalIntelligenceBonus);
        Assert.AreEqual(expectedResult, inventory.TotalHitPointsBonus);
        Assert.AreEqual(expectedResult, inventory.TotalDamageBonus);
    }
}