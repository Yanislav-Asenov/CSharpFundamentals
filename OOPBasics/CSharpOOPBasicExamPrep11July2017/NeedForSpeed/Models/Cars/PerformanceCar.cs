using System.Collections.Generic;
using System.Text;

public class PerformanceCar : Car
{
    private const int PerformanceCarHorsepowerPercentageIncreasement = 50;
    private const int PerformanceCarSuspensionPercentageDecreasement = 25;

    private ICollection<string> addOns = new List<string>();

    public PerformanceCar(
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
            horsepower + (horsepower * PerformanceCarHorsepowerPercentageIncreasement) / 100,
            acceleration,
            suspension - (suspension * PerformanceCarSuspensionPercentageDecreasement) / 100,
            durability)
    {
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder(base.ToString());

        string joinedAddons = this.addOns.Count == 0 ? "None" : string.Join(", ", this.addOns);
        result.AppendLine($"Add-ons: {joinedAddons}");

        return result.ToString().Trim();
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);

        this.addOns.Add(addOn);
    }
}