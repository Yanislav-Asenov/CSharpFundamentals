using System.Collections.Generic;

public class CreateWeaponCommand : ICommand
{
    public void Execute(
        string[] commandParameters, 
        IDictionary<string, IWeapon> weapons, 
        IWeaponFactory weaponFactory,
        IInputOutputManager inputOutputManager,
        IGemFactory gemFactory)
    {
        string[] tokens = commandParameters[0].Split(' ');
        string weaponRarity = tokens[0];
        string weaponType = tokens[1];
        string weaponName = commandParameters[1];

        IWeapon weapon = weaponFactory.CreateWeapon(weaponType, weaponRarity);
        weapons.Add(weaponName, weapon);
    }
}