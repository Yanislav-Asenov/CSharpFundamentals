using KingsGambit.Contracts;
using System.Collections.Generic;

public class ServantsCollection
{
    private Dictionary<string, IServant> servantsByName = new Dictionary<string, IServant>();

    public void Add(string servantName, IServant servant)
    {
        this.servantsByName.Add(servantName, servant);
        servant.Die += OnServantDead;
    }

    private void OnServantDead(object sender, System.EventArgs e)
    {
        if (sender is IServant servant)
        {
            this.servantsByName.Remove(servant.Name);
        }
    }

    public void AttackServant(string servantName)
    {
        this.servantsByName[servantName].ReceiveAttack();
    }
}