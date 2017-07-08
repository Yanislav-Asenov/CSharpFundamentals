using System;

public class Car : Vehicle
{
    private const double acFuelConsumption = 0.9;

    public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
        : base(fuelQuantity, fuelConsumptionPerKm + acFuelConsumption, tankCapacity)
    {
    }

    public override double FuelQuantity
    {
        get => base.FuelQuantity;
        set
        {
            if (value > this.TankCapacity)
            {
                throw new ArgumentException("Cannot fit fuel in tank");
            }

            base.FuelQuantity = value;
        }
    }
}

