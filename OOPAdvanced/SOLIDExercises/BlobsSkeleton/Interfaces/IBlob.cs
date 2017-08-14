namespace _02.Blobs.Interfaces
{
    public interface IBlob : IAttackable
    {
        string Name { get; }

        int Health { get; set; }

        int Damage { get; set; }
    }
}
