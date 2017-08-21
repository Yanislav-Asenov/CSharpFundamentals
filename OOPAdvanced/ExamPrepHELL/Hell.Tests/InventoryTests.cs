using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class InventoryTests
{
    private IInventory inventory;

    [SetUp]
    public void SetUp()
    {
        this.inventory = new HeroInventory();
    }

    [Test]
    public void AddCommonItemShouldIncreaseTotalStrengthBonus()
    {
        // Arrange
        IItem item = new CommonItem("Test Item 1", 15, 0, 0, 0, 0);

        // Act
        this.inventory.AddCommonItem(item);

        // Assert
        Assert.AreEqual(15, this.inventory.TotalStrengthBonus);
    }

    [Test]
    public void AddCommonItemShouldIncreaseTotalAgilityBonus()
    {
        // Arrange
        IItem item = new CommonItem("Test Item 1", 0, 15, 0, 0, 0);

        // Act
        this.inventory.AddCommonItem(item);

        // Assert
        Assert.AreEqual(15, this.inventory.TotalAgilityBonus);
    }

    [Test]
    public void AddCommonItemShouldIncreaseTotalIntelligenceBonus()
    {
        // Arrange
        IItem item = new CommonItem("Test Item 1", 0, 0, 15, 0, 0);

        // Act
        this.inventory.AddCommonItem(item);

        // Assert
        Assert.AreEqual(15, this.inventory.TotalIntelligenceBonus);
    }

    [Test]
    public void AddCommonItemShouldIncreaseTotalHitPointsBonus()
    {
        // Arrange
        IItem item = new CommonItem("Test Item 1", 0, 0, 0, 15, 0);

        // Act
        this.inventory.AddCommonItem(item);

        // Assert
        Assert.AreEqual(15, this.inventory.TotalHitPointsBonus);
    }

    [Test]
    public void AddCommonItemShouldIncreaseTotalDamageBonus()
    {
        // Arrange
        IItem item = new CommonItem("Test Item 1", 0, 0, 0, 0, 15);

        // Act
        this.inventory.AddCommonItem(item);

        // Assert
        Assert.AreEqual(15, this.inventory.TotalDamageBonus);
    }

    [Test]
    public void AddMultipleCommonItemsShouldIncreaseTotalStatBonuses()
    {
        // Arrange
        IItem item1 = new CommonItem("Test Item 1", 15, 15, 15, 15, 15);
        IItem item2 = new CommonItem("Test Item 2", 15, 15, 15, 15, 15);
        IItem item3 = new CommonItem("Test Item 3", 30, 30, 30, 30, 30);

        // Act
        this.inventory.AddCommonItem(item1);
        this.inventory.AddCommonItem(item2);
        this.inventory.AddCommonItem(item3);

        // Assert
        Assert.AreEqual(60, this.inventory.TotalStrengthBonus);
        Assert.AreEqual(60, this.inventory.TotalAgilityBonus);
        Assert.AreEqual(60, this.inventory.TotalIntelligenceBonus);
        Assert.AreEqual(60, this.inventory.TotalHitPointsBonus);
        Assert.AreEqual(60, this.inventory.TotalDamageBonus);
    }

    [Test]
    public void AddRecipeWhenRequiredItemsAreAvailableShouldIncreaseTotalStatBonuses()
    {
        // Arrange
        IItem item = new CommonItem("Test Item 1", 0, 0, 0, 0, 0);
        IRecipe recipe = new RecipeItem("Test Recipe 1", 15, 15, 15, 15, 15, new List<string>() { "Test Item 1" });

        // Act
        this.inventory.AddCommonItem(item);
        this.inventory.AddRecipeItem(recipe);

        // Assert
        Assert.AreEqual(recipe.StrengthBonus, this.inventory.TotalStrengthBonus);
        Assert.AreEqual(recipe.StrengthBonus, this.inventory.TotalAgilityBonus);
        Assert.AreEqual(recipe.StrengthBonus, this.inventory.TotalIntelligenceBonus);
        Assert.AreEqual(recipe.StrengthBonus, this.inventory.TotalHitPointsBonus);
        Assert.AreEqual(recipe.StrengthBonus, this.inventory.TotalDamageBonus);
    }

    [Test]
    public void AddRecipeWhenRequiredItemsAreNotAvailableShouldNotIncreaseTotalStatBonuses()
    {
        // Arrange
        IItem item = new CommonItem("Test Item 1", 0, 0, 0, 0, 0);
        IRecipe recipe = new RecipeItem("Test Recipe 1", 15, 15, 15, 15, 15, new List<string>() { "Test Item 2" });

        // Act
        this.inventory.AddCommonItem(item);
        this.inventory.AddRecipeItem(recipe);

        // Assert
        Assert.AreEqual(0, this.inventory.TotalStrengthBonus);
        Assert.AreEqual(0, this.inventory.TotalAgilityBonus);
        Assert.AreEqual(0, this.inventory.TotalIntelligenceBonus);
        Assert.AreEqual(0, this.inventory.TotalHitPointsBonus);
        Assert.AreEqual(0, this.inventory.TotalDamageBonus);
    }

    [Test]
    public void AddCommonItemWhichCompletesRecipeShouldCreateRecipeAndIncreaseTotalStatBonuses()
    {
        // Arrange
        IItem item1 = new CommonItem("Test Item 1", 0, 0, 0, 0, 0);
        IItem item2 = new CommonItem("Test Item 2", 0, 0, 0, 0, 0);
        IRecipe recipe = new RecipeItem("Test Recipe 1", 30, 30, 30, 30, 30, new List<string>() { "Test Item 1", "Test Item 2" });

        // Act
        this.inventory.AddRecipeItem(recipe);
        this.inventory.AddCommonItem(item1);
        this.inventory.AddCommonItem(item2);

        // Assert
        Assert.AreEqual(30, this.inventory.TotalStrengthBonus);
        Assert.AreEqual(30, this.inventory.TotalAgilityBonus);
        Assert.AreEqual(30, this.inventory.TotalIntelligenceBonus);
        Assert.AreEqual(30, this.inventory.TotalHitPointsBonus);
        Assert.AreEqual(30, this.inventory.TotalDamageBonus);
    }
}