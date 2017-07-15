using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    private Dictionary<int, Car> cars = new Dictionary<int, Car>();
    private Dictionary<int, Race> races = new Dictionary<int, Race>();
    private CarFactory carFactory;
    private RaceFactory raceFactory;
    private Garage garage;

    public CarManager()
    {
        this.carFactory = new CarFactory();
        this.raceFactory = new RaceFactory();
        this.garage = new Garage();
    }

    public void Register(
        int id, 
        string type, 
        string brand, 
        string model, 
        int yearOfProduction, 
        int horsepower, 
        int acceleration, 
        int suspension, 
        int durability)
    {
        var car = carFactory.CreateCar(type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        this.cars.Add(id, car);
    }

    public string Check(int id)
    {
        return this.cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        var race = raceFactory.CreateRace(type, length, route, prizePool);
        this.races.Add(id, race);
    }

    public void Participate(int carId, int raceId)
    {
        if (this.garage.HasCar(carId))
        {
            return;
        }

        var targetCar = this.cars[carId];
        var targetRace = this.races[raceId];

        targetRace.AddParicipant(carId, targetCar);
    }

    public string Start(int id)
    {
        var race = this.races[id];

        if (!race.CanStartRace())
        {
            return "Cannot start the race with zero participants.";
        }

        this.races.Remove(id);
        return race.StartRace();
    }

    public void Park(int id)
    {
        if (this.races.Select(r => r.Value).Any(x => x.Participants.ContainsKey(id)))
        {
            return;
        }

        var car = this.cars[id];
        this.garage.ParkCar(id, car);
    }

    public void Unpark(int id)
    {
        this.garage.UnparkCar(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var car in this.garage.ParkedCars)
        {
            car.Tune(tuneIndex, addOn);
        }
    }
}