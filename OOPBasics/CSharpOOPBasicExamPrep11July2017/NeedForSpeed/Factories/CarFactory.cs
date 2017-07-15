using System;

public class CarFactory
{
    public CarFactory()
    {
    }

    public Car CreateCar(
        string type,
        string brand,
        string model,
        int yearOfProduction,
        int horsepower,
        int acceleration,
        int suspension,
        int durability)
    {

        switch (type)
        {
            case "Performance":
                return new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
            case "Show":
                return new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
            default:
                throw new ArgumentException("Invalid car type");
        }
    }
}