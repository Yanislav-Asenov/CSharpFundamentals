using System;

public class GemFactory : IGemFactory
{
    public IGem CreateGem(string type, string clarity)
    {
        switch (type)
        {
            case "Amethyst":
                return new Amethyst(clarity);
            case "Emerald":
                return new Emerald(clarity);
            case "Ruby":
                return new Ruby(clarity);
            default:
                throw new ArgumentException("Invalid gem type.");
        }
    }
}