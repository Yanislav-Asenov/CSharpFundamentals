using System;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(string type, string rarity)
    {
        switch (type)
        {
            case "Axe":
                return new Axe(rarity);
            case "Knife":
                return new Knife(rarity);
            case "Sword":
                return new Sword(rarity);
            default:
                throw new ArgumentException("Invalid weapon type.");
        }
    }
}