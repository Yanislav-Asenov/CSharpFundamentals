namespace KingsGambit.Models
{
    using KingsGambit.Contracts;
    using System;

    public class RoyalGuard : Entity, IServant
    {
        private IAttackable king;

        public RoyalGuard(string name, IAttackable king)
            : base(name)
        {
            this.king = king;
            this.king.ReceiveAttack += this.RespondToKingAttack;
        }

        public void Die()
        {
            this.king.ReceiveAttack -= this.RespondToKingAttack;
        }

        public void RespondToKingAttack(object sender, EventArgs e)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
