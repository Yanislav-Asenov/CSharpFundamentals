using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, Car> cars = new Dictionary<string, Car>();
        for (int i = 0; i < n; i++)
        {
            string[] carArgs = Console.ReadLine().Split();

            string model = carArgs[0];
            double fuelAmount = double.Parse(carArgs[1]);
            double fuelConsumptionPerKm = double.Parse(carArgs[2]);

            if (!cars.ContainsKey(model))
            {
                cars.Add(model, new Car(model, fuelAmount, fuelConsumptionPerKm));
            }
        }

        string command = Console.ReadLine();
        while (command != "End")
        {
            string[] commandArgs = command.Split();
            string targetModel = commandArgs[1];
            double km = double.Parse(commandArgs[2]);

            cars[targetModel].Drive(km);

            command = Console.ReadLine();
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car.Value);
        }
    }
}

public class Car
{
    private double _distanceTraveled;

    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumptionPerKm { get; set; }

    public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
    {
        this._distanceTraveled = 0;
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public void Drive(double km)
    {
        double requiredFuel = km * FuelConsumptionPerKm;

        if (requiredFuel <= FuelAmount)
        {
            this.FuelAmount -= requiredFuel;
            this._distanceTraveled += km;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    public override string ToString()
    {
        return $"{this.Model} {this.FuelAmount:F2} {this._distanceTraveled:F0}";
    }
}