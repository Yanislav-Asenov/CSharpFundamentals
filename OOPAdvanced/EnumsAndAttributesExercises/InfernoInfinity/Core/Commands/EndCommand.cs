using System;
using System.Collections.Generic;

public class EndCommand : ICommand
{
    public void Execute(
        string[] commandParameters, 
        IDictionary<string, IWeapon> weapons, 
        IWeaponFactory weaponFactory,
        IInputOutputManager inputOutputManager,
        IGemFactory gemFactory)
    {
        Environment.Exit(0);
    }
}