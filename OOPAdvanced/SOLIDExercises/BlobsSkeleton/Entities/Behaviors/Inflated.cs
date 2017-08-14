namespace _02.Blobs.Entities.Behaviors
{
    using System;
    using _02.Blobs.Interfaces;

    public class Inflated : Behavior
    {
        private const int InflatedHealthGain = 50;
        private const int InflatedHealthDecrementer = 10;

        private int sourceInitialHealth;

        public override void ApplyRecurrentEffect(IBlob source)
        {
            source.Health += InflatedHealthGain;
            this.IsTriggered = true;
            this.ApplyRecurrentEffect(source);
        }

        public override void Trigger(IBlob source)
        {
            if (this.ToDelayRecurrentEffect)
            {
                this.ToDelayRecurrentEffect = false;
            }
            else
            {
                source.Health -= InflatedHealthDecrementer;
            }
        }
    }
}
