namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            SortedSet<string> carNumbers = new SortedSet<string>();

            string inputLine = Console.ReadLine();

            while (inputLine.ToUpper() != "END")
            {
                string[] inputArgs = inputLine.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string direction = inputArgs[0];
                string carNumber = inputArgs[1];

                switch (direction)
                {
                    case "IN":
                        carNumbers.Add(carNumber);
                        break;
                    case "OUT":
                        if (carNumbers.Contains(carNumber))
                        {
                            carNumbers.Remove(carNumber);
                        }
                        break;
                }

                inputLine = Console.ReadLine();
            }

            if (carNumbers.Count > 0)
            {
                Console.WriteLine(string.Join("\n", carNumbers));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
