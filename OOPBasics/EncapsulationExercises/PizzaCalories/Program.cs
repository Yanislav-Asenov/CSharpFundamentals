using System;
using System.Collections.Generic;
using System.Linq;
using PizzaCalories;

public class Program
{
    public static void Main()
    {
        string inputLine = Console.ReadLine();
        while (inputLine != "END")
        {
            string[] tokens = inputLine.Split();
            string productType = tokens[0];

            try
            {
                switch (productType)
                {
                    case "Dough":
                        Dough dough = new Dough(tokens[1], tokens[2], double.Parse(tokens[3]));
                        Console.WriteLine($"{dough.Calories:F2}");
                        break;
                    case "Topping":
                        Topping topping = new Topping(tokens[1], double.Parse(tokens[2]));
                        Console.WriteLine($"{topping.Calories:F2}");
                        break;
                    case "Pizza":
                        Pizza pizza = new Pizza(tokens[1], int.Parse(tokens[2]));

                        string[] doughArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        pizza.Dough = new Dough(doughArgs[1], doughArgs[2], double.Parse(doughArgs[3]));

                        for (int i = 0; i < pizza.NumberOfToppings; i++)
                        {
                            string[] toppingArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            pizza.AddTopping(new Topping(toppingArgs[1], double.Parse(toppingArgs[2])));
                        }

                        Console.WriteLine(pizza);
                        break;
                }
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
                Environment.Exit(1);
            }

            inputLine = Console.ReadLine();
        }
    }
}