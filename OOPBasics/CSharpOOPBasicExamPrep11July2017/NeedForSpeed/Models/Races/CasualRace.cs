using System;
using System.Collections.Generic;
using System.Linq;

public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool)
        : base(length, route, prizePool)
    {
    }

    protected override IList<Car> Winners
    {
        get
        {
            return this.participants
                .Select(x => x.Value)
                .OrderByDescending(p => this.GetCarPerformance(p))
                .Take(3)
                .ToList();
        }
    }

    public override int GetCarPerformance(Car car)
    {
        int performance = (car.HorsePower / car.Acceleration) + (car.Suspension + car.Durability);

        return performance;
    }
}