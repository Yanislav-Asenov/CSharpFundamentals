using System;
using System.Collections.Generic;

public class CoffeeMachine : ICoffeeMachine
{
    private int coins = 0;
    private ICollection<CoffeeType> coffeesSold;

    public CoffeeMachine()
    {
        this.coffeesSold = new List<CoffeeType>();
    }

    public IEnumerable<CoffeeType> CoffeesSold => this.coffeesSold;

    public void BuyCoffee(string size, string type)
    {
        if (Enum.TryParse(size, out CoffeePrice coffeeSize) && Enum.TryParse(type, out CoffeeType coffeeType))
        {
            int coffeePrice = (int)coffeeSize;

            if (coffeePrice <= this.coins)
            {
                this.coffeesSold.Add(coffeeType);
                this.coins = 0;
            }
        }
    }

    public void InsertCoin(string coin)
    {
        if (Enum.TryParse(coin, out Coin insertedCoin))
        {
            this.coins += (int)insertedCoin;
        }
    }
}