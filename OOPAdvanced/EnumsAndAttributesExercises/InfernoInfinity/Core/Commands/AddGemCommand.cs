using System.Collections.Generic;

public class AddGemCommand : ICommand
{
    public void Execute(string[] commandParameters, IDictionary<string, IWeapon> weapons, IWeaponFactory weaponFactory, IInputOutputManager inputOutputManager, IGemFactory gemFactory)
    {
        string targetAxeName = commandParameters[0];
        int socketIndex = int.Parse(commandParameters[1]);
        string[] tokens = commandParameters[2].Split(' ');
        string clarity = tokens[0];
        string type = tokens[1];
        IGem gem = gemFactory.CreateGem(type, clarity);

        IWeapon targetAxe = weapons[targetAxeName];
        targetAxe.AddGem(gem, socketIndex);
    }
}