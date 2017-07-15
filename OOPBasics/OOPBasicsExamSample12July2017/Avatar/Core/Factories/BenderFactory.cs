using System;

public class BenderFactory
{
    public Bender CreateBender(string type, string name, int power, decimal secondaryParameter)
    {
        switch (type)
        {
            case "Air":
                return new AirBender(name, power, secondaryParameter);
            case "Water":
                return new WaterBender(name, power, secondaryParameter);
            case "Fire":
                return new FireBender(name, power, secondaryParameter);
            case "Earth":
                return new EarthBender(name, power, secondaryParameter);
            default:
                throw new ArgumentException("Invalid bender type.");
        }
    }
}