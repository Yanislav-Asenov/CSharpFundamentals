using System;
using System.Collections;

public class RandomList : ArrayList
{
    private Random randomGenerator;

    public RandomList()
    {
        this.randomGenerator = new Random();
    }

    public string RandomString()
    {
        int randomIndex = randomGenerator.Next(0, this.Count);
        string itemToReturn = this[randomIndex].ToString();
        this.RemoveAt(randomIndex);
        return itemToReturn;
    }
}

