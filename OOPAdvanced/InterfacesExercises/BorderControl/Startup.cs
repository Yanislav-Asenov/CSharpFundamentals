using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        IDictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

        int numberOfBuyres = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfBuyres; i++)
        {
            string[] inputLineArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (inputLineArgs.Length == 3)
            {
                string name = inputLineArgs[0];
                int age = int.Parse(inputLineArgs[1]);
                string group = inputLineArgs[2];
                IBuyer rebel = new Rebel(name, age, group);
                buyers.Add(name, rebel);
            }
            else
            {
                string name = inputLineArgs[0];
                int age = int.Parse(inputLineArgs[1]);
                string id = inputLineArgs[2];
                string birthdate = inputLineArgs[3];
                IBuyer citizen = new Citizen(name, age, id, birthdate);
                buyers.Add(name, citizen);
            }
        }

        string targetBuyer = Console.ReadLine();
        while (targetBuyer != "End")
        {
            if (buyers.ContainsKey(targetBuyer))
            {
                buyers[targetBuyer].BuyFood();
            }

            targetBuyer = Console.ReadLine();
        }

        int totalPurchasedFood = buyers.Sum(x => x.Value.Food);
        Console.WriteLine(totalPurchasedFood);
    }
}