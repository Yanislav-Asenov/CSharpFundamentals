public class Axe : Weapon
{
    private const int AxeMinDamage = 5;
    private const int AxeMaxDamage = 10;
    private const int AxeNumberOfSockets = 4;

    public Axe(string rarity) 
        : base(AxeMinDamage, AxeMaxDamage, AxeNumberOfSockets, rarity)
    {
    }
}