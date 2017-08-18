public class Assassin : AbstractHero
{
    private const int AssasinDefaultStrength = 25;
    private const int AssasinDefaultAgility = 100;
    private const int AssasinDefaultIntelligence = 15;
    private const int AssasinDefaultHitPoints = 150;
    private const int AssasinDefaultDamage = 300;

    public Assassin(string name)
        : base(
            name,
            AssasinDefaultStrength,
            AssasinDefaultAgility,
            AssasinDefaultIntelligence,
            AssasinDefaultHitPoints,
            AssasinDefaultDamage)
    {
    }
}