using System;

namespace PizzaCalories
{
    public class Topping
    {
        private const double BaseModifier = 2;

        private string type;
        private double weight;

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public string Type
        {
            get { return this.type; }
            private set
            {
                string valueToLower = value.ToLower();
                if (valueToLower != "meat" && valueToLower != "veggies" &&
                    valueToLower != "cheese" && valueToLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = $"{char.ToUpper(valueToLower[0])}{valueToLower.Substring(1, valueToLower.Length - 1)}";
            }
        }

        private double TypeModifier
        {
            get
            {
                double typeModifier = 0;
                switch (this.Type)
                {
                    case "Meat":
                        typeModifier = 1.2;
                        break;
                    case "Veggies":
                        typeModifier = 0.8;
                        break;
                    case "Cheese":
                        typeModifier = 1.1;
                        break;
                    case "Sauce":
                        typeModifier = 0.9;
                        break;
                }

                return typeModifier;
            }
        }

        public double CaloriesPerGram
        {
            get
            {
                return this.Calories / this.Weight;
            }
        }

        public double Calories
        {
            get
            {
                return (this.Weight * BaseModifier) * this.TypeModifier;
            }
        }

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
    }
}
