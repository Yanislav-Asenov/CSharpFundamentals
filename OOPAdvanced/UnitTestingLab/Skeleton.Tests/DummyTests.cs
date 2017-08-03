using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void ShouldLoseHealthAfterTakingAnAttack()
    {
        // Arrange
        IWeapon axe = new Axe(10, 10);
        ITarget dummy = new Dummy(20, 20);

        // Act
        axe.Attack(dummy);

        // Assert
        Assert.AreEqual(10, dummy.Health, "Does not lose health after taking an attack");
    }

    [Test]
    public void ShouldThrowAnExceptionWhenDeadAndTakesAnAttack()
    {
        // Arrange
        IWeapon axe = new Axe(10, 10);
        ITarget dummy = new Dummy(0, 20);

        // Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            axe.Attack(dummy);
        }, "Dummy does not throw an exception when dead.");
    }

    [Test]
    public void ShouldGiveExperienceWhenDead()
    {
        // Arrange
        ITarget dummy = new Dummy(0, 20);

        // Act
        int experience = dummy.GiveExperience();

        // Assert
        Assert.AreEqual(20, experience, "Does not give experience when dead.");
    }

    [Test]
    public void ShouldThrowAnExceptionWhenAliveAndGivesExperience()
    {
        // Arrange
        var dummy = new Dummy(20, 20);

        Assert.Throws<InvalidOperationException>(() =>
        {
            dummy.GiveExperience();
        }, "Gives experience when alive.");
    }
}