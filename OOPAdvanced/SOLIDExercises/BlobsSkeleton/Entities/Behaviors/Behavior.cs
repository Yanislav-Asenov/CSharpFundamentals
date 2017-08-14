namespace _02.Blobs.Entities.Behaviors
{
    using _02.Blobs.Interfaces;


    public abstract class Behavior : IBehavior
    {
        public Behavior()
        {
            this.ToDelayRecurrentEffect = true;
        }

        public bool IsTriggered { get; set; }

        public bool ToDelayRecurrentEffect { get; set; }

        public abstract void Trigger(IBlob source);

        public abstract void ApplyRecurrentEffect(IBlob source);
    }
}