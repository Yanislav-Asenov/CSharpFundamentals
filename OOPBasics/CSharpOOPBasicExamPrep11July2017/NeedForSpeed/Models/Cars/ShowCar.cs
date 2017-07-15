using System.Text;

public class ShowCar : Car
{
    private int stars = 0;

    public ShowCar(
        string brand,
        string model,
        int yearOfProduction,
        int horsepower,
        int acceleration,
        int suspension,
        int durability)
        : base(
              brand,
              model,
              yearOfProduction,
              horsepower,
              acceleration,
              suspension,
              durability)
    {
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder(base.ToString());
        result.AppendLine($"{this.stars} *");

        return result.ToString().Trim();
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);

        this.stars += tuneIndex;
    }
}