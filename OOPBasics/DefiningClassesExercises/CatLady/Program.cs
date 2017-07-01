using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Dictionary<string, Cat> catsByName = new Dictionary<string, Cat>();

        string inputLine = Console.ReadLine();
        while (inputLine != "End")
        {
            string[] inputLineArgs = inputLine.Split();
            string catType = inputLineArgs[0];
            string catName = inputLineArgs[1];

            switch (catType)
            {
                case "Siamese":
                    int earSize = int.Parse(inputLineArgs[2]);
                    catsByName.Add(catName, new Siamese(catName, earSize));
                    break;
                case "Cymric":
                    double furLength = double.Parse(inputLineArgs[2]);
                    catsByName.Add(catName, new Cymric(catName, furLength));
                    break;
                case "StreetExtraordinaire":
                    int decibels = int.Parse(inputLineArgs[2]);
                    catsByName.Add(catName, new StreetExtraordinaire(catName, decibels));
                    break;
            }
            inputLine = Console.ReadLine();
        }

        string targetCat = Console.ReadLine();
        Console.WriteLine(catsByName[targetCat]);
    }
}

public class Cat
{
    public string Name { get; set; }

    public Cat(string name)
    {
        this.Name = name;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} {this.Name}";
    }
}

public class Siamese : Cat
{
    public int EarSize { get; set; }

    public Siamese(string name, int earSize)
        : base(name)
    {
        this.EarSize = earSize;
    }

    public override string ToString()
    {
        return $"{base.ToString()} {this.EarSize}";
    }
}

public class Cymric : Cat
{
    public double FlurLength { get; set; }

    public Cymric(string name, double flurLength)
        : base(name)
    {
        this.FlurLength = flurLength;
    }

    public override string ToString()
    {
        return $"{base.ToString()} {this.FlurLength:F2}";
    }
}

public class StreetExtraordinaire : Cat
{
    public int Decibels { get; set; }

    public StreetExtraordinaire(string name, int decibels)
        : base(name)
    {
        this.Decibels = decibels;
    }

    public override string ToString()
    {
        return $"{base.ToString()} {this.Decibels}";
    }
}