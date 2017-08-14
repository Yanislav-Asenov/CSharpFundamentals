namespace KingsGambit.Models
{
    using KingsGambit.Contracts;
    using System;

    public class RoyalGuard : Entity, IServant
    {
        private const int RequiredHitsToDie = 3;

        private IAttackable king;
        private int requiredHitsToDie = RequiredHitsToDie;

        public RoyalGuard(string name, IAttackable king)
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
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
