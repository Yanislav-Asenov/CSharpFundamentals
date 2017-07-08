using System;

public class Cat : Feline
{
    private string breed;

    public Cat(string animalName, double animalWeight, string livingRegion, string breed) 
        : base(animalName, animalWeight, livingRegion)
    {
        this.Breed = breed;
    }

    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }

    public override string ToString()
    {
        return $"{this.AnimalType}[{this.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }

    public override void MakeSound()
    {
        Console.WriteLine("Meowwww");
    }
}

