public class Tesla : Car, IElectricCar
{
    private int battery;

    public Tesla(string mode, string color, int battery) 
        : base(mode, color)
    {
        this.Battery = battery;
    }

    public int Battery
    {
        get => this.battery;
        set => this.battery = value;
    }

    public override string ToString()
    {
        return $"{base.ToString()} with {this.Battery} Batteries";
    }
}