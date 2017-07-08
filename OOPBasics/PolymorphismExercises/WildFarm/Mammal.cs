public abstract class Mammal : Animal
{
    private string livingRegion;

    protected Mammal(string animalName, double animalWeight, string livingRegion) 
        : base(animalName, animalWeight)
    {
        this.LivingRegion = livingRegion;
    }

    public string LivingRegion
    {
        get { return livingRegion; }
        set { livingRegion = value; }
    }

    public override string ToString()
    {
        return $"{this.AnimalType}[{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}