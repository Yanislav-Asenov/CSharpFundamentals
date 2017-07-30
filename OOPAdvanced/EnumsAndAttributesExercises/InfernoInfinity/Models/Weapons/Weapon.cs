using System;

public abstract class Weapon : IWeapon
{
    private const int StrengthToMinDamage = 2;
    private const int StrengthToMaxDamage = 3;
    private const int AgilityToMinDamage = 1;
    private const int AgilityToMaxDamage = 4;

    private int minDamage;
    private int maxDamage;
    private int numberOfSockets;
    private WeaponRarity rarity;
    private int strength;
    private int agility;
    private int vitality;
    private IGem[] gems;

    protected Weapon(int minDamage, int maxDamage, int numberOfSockets, string rarity)
    {
        this.MinDamage = minDamage;
        this.MaxDamage = maxDamage;
        this.NumberOfSockets = numberOfSockets;
        Enum.TryParse(rarity, out this.rarity);
        this.gems = new Gem[numberOfSockets];
    }

    public int MinDamage
    {
        get
        {
            int baseDamage = this.minDamage * (int)this.Rarity;
            int strengthBonusDamage = this.Strength * StrengthToMinDamage;
            int agilityBonusDamage = this.Agility * AgilityToMinDamage;

            return baseDamage + strengthBonusDamage + agilityBonusDamage;
        }
        private set => this.minDamage = value;
    }

    public int MaxDamage
    {
        get
        {
            int baseDamage = this.maxDamage * (int)this.Rarity;
            int strengthBonusDamage = this.Strength * StrengthToMaxDamage;
            int agilityBonusDamage = this.Agility * AgilityToMaxDamage;

            return baseDamage + strengthBonusDamage + agilityBonusDamage;
        }
        private set => this.maxDamage = value;
    }

    public int NumberOfSockets
    {
        get => this.numberOfSockets;
        private set => this.numberOfSockets = value;
    }

    public int Strength
    {
        get => this.strength;
        private set => this.strength = value;
    }

    public int Agility
    {
        get => this.agility;
        private set => this.agility = value;
    }

    public int Vitality
    {
        get => this.vitality;
        private set => this.vitality = value;
    }

    public WeaponRarity Rarity => this.rarity;

    public override string ToString()
    {
        return $"{this.MinDamage}-{this.MaxDamage} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
    }

    private bool IsSocketIndexInRange(int socketIndex)
    {
        return socketIndex >= 0 && socketIndex < this.NumberOfSockets;
    }

    public void AddGem(IGem gem, int socketIndex)
    {
        if (this.IsSocketIndexInRange(socketIndex))
        {
            if (this.gems[socketIndex] != null)
            {
                this.RemoveGem(socketIndex);
            }

            this.gems[socketIndex] = gem;
            this.Strength += gem.Strength;
            this.Agility += gem.Agility;
            this.Vitality += gem.Vitality;
        }
    }

    public void RemoveGem(int socketIndex)
    {
        if (this.IsSocketIndexInRange(socketIndex))
        {
            IGem gem = this.gems[socketIndex];
            if (gem != null)
            {
                this.Strength -= gem.Strength;
                this.Agility -= gem.Agility;
                this.Vitality -= gem.Vitality;

                this.gems[socketIndex] = null;
            }
        }
    }
}