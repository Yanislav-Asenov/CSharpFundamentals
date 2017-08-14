namespace _02.Blobs.Interfaces
{
    using _02.Blobs.Entities;

    public interface IBehavior
    {
        bool IsTriggered { get; set; }

        bool ToDelayRecurrentEffect { get; set; }

        void Trigger(IBlob source);

        void ApplyRecurrentEffect(IBlob source);
    }
}