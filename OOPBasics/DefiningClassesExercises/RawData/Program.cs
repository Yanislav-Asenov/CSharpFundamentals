using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();
        for (int i = 0; i < n; i++)
        {
            string[] carArgs = Console.ReadLine().Split();

            Engine engine = new Engine(int.Parse(carArgs[1]), int.Parse(carArgs[2]));
            Cargo cargo = new Cargo(int.Parse(carArgs[3]), carArgs[4]);
            Tire[] tires = new Tire[4];
            tires[0] = new Tire(double.Parse(carArgs[5]), int.Parse(carArgs[6]));
            tires[1] = new Tire(double.Parse(carArgs[7]), int.Parse(carArgs[8]));
            tires[2] = new Tire(double.Parse(carArgs[9]), int.Parse(carArgs[10]));
            tires[3] = new Tire(double.Parse(carArgs[11]), int.Parse(carArgs[12]));

            cars.Add(new Car(carArgs[0], engine, cargo, tires));
        }

        string command = Console.ReadLine();
        IEnumerable<string> resultCarModels;

        if (command == "fragile")
        {
            resultCarModels = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1)).Select(c => c.Model);
        }
        else
        {
            resultCarModels = cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250).Select(c => c.Model);
        }

        Console.WriteLine(string.Join(Environment.NewLine, resultCarModels));
    }
}

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }
    public Tire[] Tires { get; set; }

    public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.Tires = tires;
    }
}

public class Engine
{
    public int Speed { get; set; }
    public int Power { get; set; }

    public Engine(int speed, int power)
    {
        this.Speed = speed;
        this.Power = power;
    }
}

public class Cargo
{
    public int Weight { get; set; }
    public string Type { get; set; }

    public Cargo(int weight, string type)
    {
        this.Weight = weight;
        this.Type = type;
    }
}

public class Tire
{
    public double Pressure { get; set; }
    public int Age { get; set; }

    public Tire(double pressure, int age)
    {
        this.Pressure = pressure;
        this.Age = age;
    }
}

