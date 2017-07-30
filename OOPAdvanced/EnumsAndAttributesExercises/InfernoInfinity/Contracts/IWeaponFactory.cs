public interface IWeaponFactory
{
    IWeapon CreateWeapon(string type, string rarity);
}