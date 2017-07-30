using System;

public abstract class Gem : IGem
{
    private int strength;
    private int agility;
    private int vitality;
    private GemClarity clarity;

    protected Gem(int strength, int agility, int vitality, string clarity)
    {
        this.Strength = strength;
        this.Agility = agility;
        this.Vitality = vitality;
        Enum.TryParse(clarity, out this.clarity);
    }

    public int Strength
    {
        get => this.strength + (int)this.Clarity;
        private set => this.strength = value;
    }

    public int Agility
    {
        get => this.agility + (int)this.Clarity;
        private set => this.agility = value;
    }

    public int Vitality
    {
        get => this.vitality + (int)this.Clarity;
        private set => this.vitality = value;
    }

    public GemClarity Clarity => this.clarity;
}