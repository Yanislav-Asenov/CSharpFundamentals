using System.Text;

public abstract class Item : IItem
{
    private string name;
    private int strengthBonus;
    private int agilityBonus;
    private int intelligenceBonus;
    private int hitPointsBonus;
    private int damageBonus;

    protected Item(
        string name, 
        int strengthBonus, 
        int agilityBonus, 
        int intelligenceBonus, 
        int hitPointsBonus, 
        int damageBonus)
    {
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitPointsBonus;
        this.DamageBonus = damageBonus;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public int StrengthBonus
    {
        get => this.strengthBonus;
        private set => this.strengthBonus = value;
    }

    public int AgilityBonus
    {
        get => this.agilityBonus;
        private set => this.agilityBonus = value;
    }

    public int IntelligenceBonus
    {
        get => this.intelligenceBonus;
        private set => this.intelligenceBonus = value;
    }

    public int HitPointsBonus
    {
        get => this.hitPointsBonus;
        private set => this.hitPointsBonus = value;
    }

    public int DamageBonus
    {
        get => this.damageBonus;
        private set => this.damageBonus = value;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"###Item: {this.Name}");
        result.AppendLine($"###+{this.StrengthBonus} Strength");
        result.AppendLine($"###+{this.AgilityBonus} Agility");
        result.AppendLine($"###+{this.IntelligenceBonus} Intelligence");
        result.AppendLine($"###+{this.HitPointsBonus} HitPoints");
        result.AppendLine($"###+{this.DamageBonus} Damage");

        return result.ToString().Trim();
    }
}