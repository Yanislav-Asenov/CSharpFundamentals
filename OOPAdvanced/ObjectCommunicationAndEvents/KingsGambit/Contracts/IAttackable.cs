namespace KingsGambit.Contracts
{
    using System;

    public interface IAttackable : IEntity
    {
        event EventHandler ReceiveAttack;

        void RespondToAttack();
    }
}
