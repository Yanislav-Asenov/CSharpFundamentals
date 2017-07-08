using System;

public abstract class Vehicle
{
    protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
    {
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    protected virtual double TankCapacity { get; set; }

    protected double FuelConsumptionPerKm { get; set; }

    public virtual double FuelQuantity { get; set; }

    public virtual bool Drive(double distance, bool isAcOn)
    {
        double requiredFuel = distance * this.FuelConsumptionPerKm;

        if (requiredFuel > this.FuelQuantity)
        {
            return false;
        }

        this.FuelQuantity -= requiredFuel;
        return true;
    }

    public string TryDriveDistance(double distance)
    {
        string classTypeName = this.GetType().Name;

        if (this.Drive(distance, true))
        {
            return $"{classTypeName} travelled {distance} km";
        }

        return $"{classTypeName} needs refueling";
    }

    public string TryDriveDistance(double distance, bool isAcOn)
    {
        string classTypeName = this.GetType().Name;

        if (this.Drive(distance, isAcOn))
        {
            return $"{classTypeName} travelled {distance} km";
        }

        return $"{classTypeName} needs refueling";
    }

    public virtual void Refue(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        this.FuelQuantity += amount;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}

