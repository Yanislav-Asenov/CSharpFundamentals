namespace _02.Blobs.Entities.Behaviors
{
    using _02.Blobs.Interfaces;

    public class Aggressive : Behavior
    {
        private static int AggressiveDamageMultiplier = 2;
        private static int AggressiveDamageDecrementer = 5;

        private int sourceInitialDamage;

        private void ApplyTriggerEffect(IBlob source)
        {
            source.Damage *= AggressiveDamageMultiplier;
        }

        public override void Trigger(IBlob source)
        {
            this.sourceInitialDamage = source.Damage;
            this.IsTriggered = true;
            this.ApplyTriggerEffect(source);
        }

        public override void ApplyRecurrentEffect(IBlob source)
        {
            if (this.ToDelayRecurrentEffect)
            {
               this.ToDelayRecurrentEffect = false;
            }
            else
            {
                source.Damage -= AggressiveDamageDecrementer;

                if (source.Damage <= this.sourceInitialDamage)
                {
                    source.Damage = this.sourceInitialDamage;
                }
            }
        }
    }
}