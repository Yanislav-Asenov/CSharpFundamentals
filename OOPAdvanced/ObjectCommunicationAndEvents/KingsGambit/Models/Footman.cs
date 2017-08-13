namespace KingsGambit.Models
{
    using System;
    using KingsGambit.Contracts;

    public class Footman : Entity, IServant
    {
        private IAttackable king;

        public Footman(string name, IAttackable king)
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
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
