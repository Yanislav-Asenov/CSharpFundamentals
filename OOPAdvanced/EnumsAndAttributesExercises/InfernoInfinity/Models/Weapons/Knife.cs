public class Knife : Weapon
{
    private const int KnifeMinDamage = 3;
    private const int KnifeMaxDamage = 4;
    private const int KnifeNumberOfSockets = 2;

    public Knife(string rarity) 
        : base(KnifeMinDamage, KnifeMaxDamage, KnifeNumberOfSockets, rarity)
    {
    }
}