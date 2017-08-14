using System;

[AttributeUsage(AttributeTargets.Class)]
public class StrategyAttribute : Attribute
{
    private char id;

    public StrategyAttribute(char id)
    {
        this.Id = id;
    }

    public char Id
    {
        get => this.id;
        private set => this.id = value; 
    }

    public override bool Equals(object obj)
    {
        return this.Id.Equals(obj);
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}