using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        Dictionary<string, Engine> enginesByModel = new Dictionary<string, Engine>();

        int numberOfEngines = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfEngines; i++)
        {
            string[] engineArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string model = engineArgs[0];
            int power = int.Parse(engineArgs[1]);
            Engine engine = new Engine(model, power);

            if (engineArgs.Length > 3)
            {
                if (int.TryParse(engineArgs[2], out int displacement))
                {
                    engine.Displacement = displacement.ToString();
                    engine.Efficiency = engineArgs[3];
                }
                else
                {
                    engine.Efficiency = engineArgs[2];
                    engine.Displacement = engineArgs[3];
                }
            }
            else if (engineArgs.Length > 2)
            {
                if (int.TryParse(engineArgs[2], out int displacement))
                {
                    engine.Displacement = displacement.ToString();
                }
                else
                {
                    engine.Efficiency = engineArgs[2];
                }
            }

            enginesByModel.Add(model, engine);
        }

        int numberOfCars = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCars; i++)
        {
            string[] carArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = carArgs[0];
            string engineModel = carArgs[1];
            Car car = new Car(model, enginesByModel[engineModel]);

            if (carArgs.Length > 3)
            {
                if (int.TryParse(carArgs[2], out int weight))
                {
                    car.Weight = weight.ToString();
                    car.Color = carArgs[3];
                }
                else
                {
                    car.Color = carArgs[2];
                    car.Weight = carArgs[3];
                }
            }
            else if (carArgs.Length > 2)
            {
                if (int.TryParse(carArgs[2], out int weight))
                {
                    car.Weight = weight.ToString();
                }
                else
                {
                    car.Color = carArgs[2];
                }
            }

            Console.Write(car);
        }
    }
}

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public string Weight { get; set; }
    public string Color { get; set; }

    public Car(string model, Engine engine, string weight = "n/a", string color = "n/a")
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = color;
    }

    public override string ToString()
    {
        return $@"{this.Model}:
  {this.Engine.Model}:
    Power: {this.Engine.Power}
    Displacement: {this.Engine.Displacement}
    Efficiency: {this.Engine.Efficiency}
  Weight: {this.Weight}
  Color: {this.Color}
";
    }
}

public class Engine
{
    public string Model { get; set; }
    public int Power { get; set; }
    public string Displacement { get; set; }
    public string Efficiency { get; set; }

    public Engine(string model, int power, string displacement = "n/a", string efficiency = "n/a")
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }
}

