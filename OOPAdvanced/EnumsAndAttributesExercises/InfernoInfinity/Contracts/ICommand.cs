using System.Collections.Generic;

public interface ICommand
{
    void Execute(string[] commandParameters, IDictionary<string, IWeapon> weapons, IWeaponFactory weaponFactory, IInputOutputManager inputOutputManager, IGemFactory gemFactory);
}