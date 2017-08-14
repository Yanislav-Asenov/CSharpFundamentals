namespace _02.Blobs.Entities
{
    using _02.Blobs.Entities.Attacks;
    using _02.Blobs.Interfaces;
    using System;

    public class Blob : IBlob
    {
        private int health;
        private IAttack attack;
        private int triggerCount;

        private int initialHealth;
        private int initialDamage;

        public Blob(string name, int health, int damage, IBehavior behavior, IAttack attack)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Behavior = behavior;
            this.attack = attack;

            this.initialHealth = health;
            this.initialDamage = damage;
        }

        public string Name { get; private set; }

        public int Health
        {
            get { return this.health; }
            set
            {
                this.health = value;

                if (this.health < 0)
                {
                    this.health = 0;
                }

                if (this.health <= this.initialHealth / 2 && !this.Behavior.IsTriggered)
                {
                    this.TriggerBehavior();
                }
            }
        }

        public IBehavior Behavior { get; private set; }

        public int Damage { get; set; }

        public void Attack(IBlob target)
        {
            if (this.attack is PutridFart)
            {
                this.AttackAffectTarget(this, target);
            }
        }

        public void Respond(int damage)
        {
            this.Health -= damage;
        }

        public void TriggerBehavior()
        {
            this.Behavior.Trigger(this);
        }

        public void Update()
        {
            if (this.Behavior.IsTriggered)
            {
                throw new InvalidOperationException("Behavior already activated!");
            }

            this.Behavior.ApplyRecurrentEffect(this);
        }

        private void AttackAffectSource(IBlob source)
        {
            source.Health = source.Health - source.Health / 2;
        }

        private void AttackAffectTarget(IBlob source, IBlob target)
        {
            target.Respond(source.Damage);
        }

        public override string ToString()
        {
            if (this.Health <= 0)
            {
                return $"IBlob {this.Name} KILLED";
            }

            return $"IBlob {this.Name}: {this.Health} HP, {this.Damage} Damage";
        }
    }
}