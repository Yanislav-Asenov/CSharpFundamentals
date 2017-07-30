using System;
using System.Collections.Generic;

public class PrintWeaponCommand : ICommand
{
    public void Execute(
        string[] commandParameters, 
        IDictionary<string, IWeapon> weapons, 
        IWeaponFactory weaponFactory, 
        IInputOutputManager inputOutputManager, 
        IGemFactory gemFactory)
    {
        string targetWeaponName = commandParameters[0];
        IWeapon targetWeapon = weapons[targetWeaponName];
        inputOutputManager.WriteLine($"{targetWeaponName}: {targetWeapon.ToString()}");
    }
}