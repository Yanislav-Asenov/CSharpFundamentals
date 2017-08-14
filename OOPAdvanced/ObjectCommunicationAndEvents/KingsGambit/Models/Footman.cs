namespace KingsGambit.Models
{
    using System;
    using KingsGambit.Contracts;

    public class Footman : Entity, IServant
    {
        private const int RequiredHitsToDie = 2;

        private IAttackable king;
        private int requiredHitsToDie = RequiredHitsToDie;

        public Footman(string name, IAttackable king)
            : base(name)
        {
            this.king = king;
            this.king.ReceiveAttack += this.RespondToKingAttack;
        }

        public event EventHandler Die;

        public void ReceiveAttack()
        {
            this.requiredHitsToDie--;

            if (this.requiredHitsToDie <= 0)
            {
                this.king.ReceiveAttack -= this.RespondToKingAttack;
                this.Die(this, EventArgs.Empty);
            }
        }

        public void RespondToKingAttack(object sender, EventArgs e)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
