public class Sword : Weapon
{
    private const int SwordMinDamage = 4;
    private const int SwordMaxDamage = 6;
    private const int SwordNumberOfSockets = 3;

    public Sword(string rarity) 
        : base(SwordMinDamage, SwordMaxDamage, SwordNumberOfSockets, rarity)
    {
    }
}