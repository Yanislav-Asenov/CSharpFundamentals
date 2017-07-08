public class Truck : Vehicle
{
    private const double acOnFuelConsumptin = 1.6;

    public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
        : base(fuelQuantity, fuelConsumptionPerKm + acOnFuelConsumptin, tankCapacity)
    {
    }

    public override void Refue(double amount)
    {
        base.Refue(amount * 0.95);
    }

}