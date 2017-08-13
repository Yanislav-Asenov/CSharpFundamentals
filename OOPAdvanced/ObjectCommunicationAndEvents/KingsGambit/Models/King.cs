namespace KingsGambit.Models
{
    using System;
    using KingsGambit.Contracts;

    public class King : Entity, IAttackable
    {
        public King(string name) 
            : base(name)
        {
        }

        public event EventHandler ReceiveAttack;

        public void RespondToAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            this.ReceiveAttack(this, EventArgs.Empty);
        }
    }
}
