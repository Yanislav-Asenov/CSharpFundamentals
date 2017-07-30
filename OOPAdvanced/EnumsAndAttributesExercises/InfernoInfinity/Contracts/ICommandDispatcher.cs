using System.Collections.Generic;

public interface ICommandDispatcher
{
    void DispatchCommand(string[] commandParameters, IDictionary<string, IWeapon> weapons, IWeaponFactory weaponFactory, IInputOutputManager inputOutputManager, IGemFactory gemFactory);
}