namespace KingsGambit.Contracts
{
    using System;

    public interface IServant : IEntity
    {
        void Die();

        void RespondToKingAttack(object sender, EventArgs e);
    }
}
