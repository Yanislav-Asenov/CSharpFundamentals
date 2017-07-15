using System;

public class Engine
{
    public void Run()
    {
        
        var carManager = new CarManager();

        while (true)
        {
            string[] commandArgs = Console.ReadLine().Split();
            int id = -1;
            string type = string.Empty;
            int raceId = -1;

            switch (commandArgs[0])
            {
                case "register":
                    id = int.Parse(commandArgs[1]);
                    type = commandArgs[2];
                    string brand = commandArgs[3];
                    string model = commandArgs[4];
                    int yearOfProduction = int.Parse(commandArgs[5]);
                    int horsepower = int.Parse(commandArgs[6]);
                    int acceleration = int.Parse(commandArgs[7]);
                    int suspension = int.Parse(commandArgs[8]);
                    int durability = int.Parse(commandArgs[9]);

                    carManager.Register(id, type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                    break;
                case "check":
                    id = int.Parse(commandArgs[1]);
                    Console.WriteLine(carManager.Check(id));
                    break;
                case "open":
                    id = int.Parse(commandArgs[1]);
                    type = commandArgs[2];
                    int length = int.Parse(commandArgs[3]);
                    string route = commandArgs[4];
                    int prizepool = int.Parse(commandArgs[5]);
                    carManager.Open(id, type, length, route, prizepool);
                    break;
                case "participate":
                    int carId = int.Parse(commandArgs[1]);
                    raceId = int.Parse(commandArgs[2]);
                    carManager.Participate(carId, raceId);
                    break;
                case "start":
                    raceId = int.Parse(commandArgs[1]);
                    Console.WriteLine(carManager.Start(raceId));
                    break;
                case "park":
                    carId = int.Parse(commandArgs[1]);
                    carManager.Park(carId);
                    break;
                case "unpark":
                    carId = int.Parse(commandArgs[1]);
                    carManager.Unpark(carId);
                    break;
                case "tune":
                    int tuneIndex = int.Parse(commandArgs[1]);
                    string addOn = commandArgs[2];
                    carManager.Tune(tuneIndex, addOn);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}