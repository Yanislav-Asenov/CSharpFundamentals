using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    public void ShouldLoseDurabilityAfterEachAttack()
    {
        // Arrange
        IWeapon axe = new Axe(3, 3);
        ITarget dummy = new Dummy(10, 10);

        // Act
        axe.Attack(dummy);
        axe.Attack(dummy);
        axe.Attack(dummy);

        // Assert
        Assert.AreEqual(0, axe.DurabilityPoints, "Axe does not lose durability after each attack");
    }

    [Test]
    public void ShouldThrowExceptionWhenAttackingWithBrokenWeapon()
    {
        // Arrange
        IWeapon axe = new Axe(1, 1);
        ITarget dummy = new Dummy(10, 10);

        // Act
        axe.Attack(dummy);

        // Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            axe.Attack(dummy);
        });
    }
}