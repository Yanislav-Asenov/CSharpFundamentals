namespace KingsGambit.Contracts
{
    using System;

    public interface IServant : IEntity
    {
        void ReceiveAttack();

        void RespondToKingAttack(object sender, EventArgs e);

        event EventHandler Die;
    }
}
