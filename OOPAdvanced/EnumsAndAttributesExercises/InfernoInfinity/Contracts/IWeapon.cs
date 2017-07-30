public interface IWeapon
{
    int MinDamage { get; }

    int MaxDamage { get; }

    int NumberOfSockets { get; }

    void AddGem(IGem gem, int socketIndex);

    void RemoveGem(int socketIndex);
}