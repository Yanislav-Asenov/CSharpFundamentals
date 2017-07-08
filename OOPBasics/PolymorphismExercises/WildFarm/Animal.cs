public abstract class Animal
{
    private string animalName;
    private double animalWeight;
    private int foodEaten;

    protected Animal(string animalName, double animalWeight)
    {
        this.AnimalName = animalName;
        this.AnimalWeight = animalWeight;
    }

    public int FoodEaten
    {
        get { return foodEaten; }
        protected set { foodEaten = value; }
    }

    public double AnimalWeight
    {
        get { return animalWeight; }
        set { animalWeight = value; }
    }

    public string AnimalType
    {
        get => this.GetType().Name;
    }

    public string AnimalName
    {
        get { return animalName; }
        set { animalName = value; }
    }

    public virtual void MakeSound()
    {

    }

    public virtual void Eat(Food food)
    {
        this.FoodEaten += food.Quantity;
    }
}
