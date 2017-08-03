using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void ShouldGainExperienceWhenTargetDies()
    {
        // Arrange
        var mockWeapon = new Mock<IWeapon>();
        mockWeapon.Setup(w => w.AttackPoints).Returns(20);
        mockWeapon.Setup(w => w.DurabilityPoints).Returns(20);

        var mockTarget = new Mock<ITarget>();
        mockTarget.Setup(t => t.GiveExperience()).Returns(20);
        mockTarget.Setup(t => t.IsDead()).Returns(true);

        var hero = new Hero("Test", mockWeapon.Object);

        // Act
        hero.Attack(mockTarget.Object);

        // Assert
        Assert.AreEqual(20, hero.Experience, "Does not gain experience when target dies.");
    }
}
    