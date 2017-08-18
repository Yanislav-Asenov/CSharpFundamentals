public class Barbarian : AbstractHero
{
    private const int BarbarianDefaultStrength = 90;
    private const int BarbarianDefaultAgility = 25;
    private const int BarbarianDefaultIntelligence = 10;
    private const int BarbarianDefaultHitPoints = 350;
    private const int BarbarianDefaultDamage = 150;

    public Barbarian(string name) 
        : base(
            name, 
            BarbarianDefaultStrength, 
            BarbarianDefaultAgility, 
            BarbarianDefaultIntelligence, 
            BarbarianDefaultHitPoints, 
            BarbarianDefaultDamage)
    {
    }
}