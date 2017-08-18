using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class AbstractHero : IHero, IComparable<AbstractHero>
{
    private IInventory inventory;
    private string name;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name, int strength, int agility, int intelligence, int hitPoints, int damage)
    {
        this.Name = name;
        this.Strength = strength;
        this.Agility = agility;
        this.Intelligence = intelligence;
        this.HitPoints = hitPoints;
        this.Damage = damage;
        this.inventory = new HeroInventory();
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public long Strength
    {
        get => this.strength + this.inventory.TotalStrengthBonus;
        private set => this.strength = value;
    }

    public long Agility
    {
        get => this.agility + this.inventory.TotalAgilityBonus;
        private set => this.agility = value;
    }

    public long Intelligence
    {
        get => this.intelligence + this.inventory.TotalIntelligenceBonus;
        private set => this.intelligence = value;
    }

    public long HitPoints
    {
        get => this.hitPoints + this.inventory.TotalHitPointsBonus;
        private set => this.hitPoints = value;
    }

    public long Damage
    {
        get => this.damage + this.inventory.TotalDamageBonus;
        private set => this.damage = value;
    }

    public long PrimaryStats
    {
        get => this.Strength + this.Agility + this.Intelligence;
    }

    public long SecondaryStats
    {
        get => this.HitPoints + this.Damage;
    }

    public IInventory Inventory
    {
        get => this.inventory;
        private set => this.inventory = value;
    }

    // REFLECTION
    public ICollection<IItem> Items
    {
        get
        {
            Type inventoryType = this.inventory.GetType();
            FieldInfo targetField = inventoryType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.IsPrivate && f.GetCustomAttributes<ItemAttribute>().Any());

            var targetFieldValue = targetField.GetValue(this.inventory) as IDictionary<string, IItem>;

            return targetFieldValue.Values;
        }
    }

    public void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }
    
    public int CompareTo(AbstractHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        var primary = this.PrimaryStats.CompareTo(other.PrimaryStats);
        if (primary != 0)
        {
            return primary;
        }

        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"Hero: {this.Name}, Class: {this.GetType().Name}");
        result.AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}");
        result.AppendLine($"Strength: {this.Strength}");
        result.AppendLine($"Agility: {this.Agility}");
        result.AppendLine($"Intelligence: {this.Intelligence}");
        
        string items = this.Items.Count == 0 ? 
            " None" : Environment.NewLine + string.Join(Environment.NewLine, this.Items.Select(i => i.ToString()));
        result.AppendLine($"Items:{items}");

        return result.ToString().Trim();
    }
}