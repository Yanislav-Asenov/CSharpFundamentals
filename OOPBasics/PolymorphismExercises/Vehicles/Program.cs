using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        string[] carArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Vehicle car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]), double.Parse(carArgs[3]));

        string[] truckArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Vehicle truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]), double.Parse(truckArgs[3]));

        string[] busArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Vehicle bus = new Bus(double.Parse(busArgs[1]), double.Parse(busArgs[2]), double.Parse(busArgs[3]));

        int numberOfCommands = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] commandArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string commandType = commandArgs[0];
            string vehicleType = commandArgs[1];
            double distanceOrFuel = double.Parse(commandArgs[2]);

            try
            {
                switch (vehicleType)
                {
                    case "Car":
                        ExecuteAction(car, commandType, distanceOrFuel);
                        break;
                    case "Truck":
                        ExecuteAction(truck, commandType, distanceOrFuel);
                        break;
                    case "Bus":
                        ExecuteAction(bus, commandType, distanceOrFuel);
                        break;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }

    private static void ExecuteAction(Vehicle vehicle, string commandType, double distanceOrFuel)
    {
        switch (commandType)
        {
            case "Drive":
                Console.WriteLine(vehicle.TryDriveDistance(distanceOrFuel));
                break;
            case "DriveEmpty":
                Console.WriteLine(vehicle.TryDriveDistance(distanceOrFuel, false));
                break;
            case "Refuel":
                vehicle.Refue(distanceOrFuel);
                break;
        }
    }
}

