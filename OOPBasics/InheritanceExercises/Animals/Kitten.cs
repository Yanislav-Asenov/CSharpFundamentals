﻿public class Kitten : Cat
{
    public Kitten(string name, string age)
        : base(name, age, "Female")
    {

    }

    public override string ProduceSound()
    {
        return "Miau";
    }
}

