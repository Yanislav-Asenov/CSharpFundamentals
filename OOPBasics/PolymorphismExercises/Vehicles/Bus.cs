using System;

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
        : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
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

    public override bool Drive(double distance, bool isAcOn)
    {
        double requiredFuel = 0;
        if (isAcOn)
        {
            requiredFuel = distance * (this.FuelConsumptionPerKm + 1.4);
        }
        else
        {
            requiredFuel = distance * this.FuelConsumptionPerKm;
        }

        if (requiredFuel > this.FuelQuantity)
        {
            return false;
        }

        this.FuelQuantity -= requiredFuel;
        return true;
    }
}

