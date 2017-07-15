using System;
using System.Collections.Generic;
using System.Linq;

public class Garage
{
    private Dictionary<int, Car> parkedCars = new Dictionary<int, Car>();
    
    public void ParkCar(int carId, Car car)
    {
        if (this.parkedCars.ContainsKey(carId))
        {
            return;
        }

        parkedCars.Add(carId, car);
    }

    public IEnumerable<Car> ParkedCars => this.parkedCars.Select(x => x.Value);

    public bool HasCar(int carId)
    {
        return this.parkedCars.ContainsKey(carId);
    }

    public void UnparkCar(int id)
    {
        this.parkedCars.Remove(id);
    }
}