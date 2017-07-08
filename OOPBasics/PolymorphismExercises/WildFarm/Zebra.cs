using System;

public class Zebra : Mammal
{
    public Zebra(string animalName, double animalWeight, string livingRegion) 
        : base(animalName, animalWeight, livingRegion)
    {
    }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != "Vegetable")
        {
            throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
        }

        base.Eat(food);
    }

    public override void MakeSound()
    {
        Console.WriteLine("Zs");
    }
}

