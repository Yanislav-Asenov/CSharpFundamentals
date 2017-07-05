using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var gandalf = new Gandalf();
        var foodFactory = new FoodFactory();
        Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .ForEach(f =>
            {
                var food = foodFactory.CreateFood(f);
                gandalf.Eat(food);
            });

        Console.WriteLine(gandalf.TotalPointsOfHappiness);

        MoodFactory moodFactory = new MoodFactory();
        Console.WriteLine(moodFactory.CreateMood(gandalf.TotalPointsOfHappiness).Name);
    }
}

