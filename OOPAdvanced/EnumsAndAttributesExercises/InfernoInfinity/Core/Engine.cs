using System.Collections.Generic;

public class Engine : IEngine
{
    private IInputOutputManager inputOutputManager;
    private ICommandDispatcher commandDispatcher;
    private IDictionary<string, IWeapon> weapons;
    private IWeaponFactory weaponFactory;
    private IGemFactory gemFactory;

    public Engine(
        IInputOutputManager inputOutputManager, 
        ICommandDispatcher commandDispatcher, 
        IWeaponFactory weaponFactory, 
        IGemFactory gemFactory)
    {
        this.inputOutputManager = inputOutputManager;
        this.commandDispatcher = commandDispatcher;
        this.weapons = new Dictionary<string, IWeapon>();
        this.weaponFactory = weaponFactory;
        this.gemFactory = gemFactory;
    }

    public void Run()
    {
        while (true)
        {
            try
            {
                string input = this.inputOutputManager.ReadLine();
                string[] data = input.Split(';');
                this.commandDispatcher.DispatchCommand(data, this.weapons, this.weaponFactory, this.inputOutputManager, this.gemFactory);
            }
            catch
            {
            }
        }
    }
}