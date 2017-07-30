using System.Collections.Generic;

public class RemoveGemCommand : ICommand
{
    public void Execute(
        string[] commandParameters, 
        IDictionary<string, IWeapon> weapons, 
        IWeaponFactory weaponFactory, 
        IInputOutputManager inputOutputManager,
        IGemFactory gemFactory)
    {
        string targetAxeName = commandParameters[0];
        int socketIndex = int.Parse(commandParameters[1]);
        
        IWeapon targetAxe = weapons[targetAxeName];
        targetAxe.RemoveGem(socketIndex);
    }
}