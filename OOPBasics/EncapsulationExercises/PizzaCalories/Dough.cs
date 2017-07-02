using System;

namespace PizzaCalories
{
    public class Dough
    {
        private const double BaseModifier = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                string valueToLower = value.ToLower();
                if (valueToLower != "crispy" && valueToLower != "chewy" && valueToLower != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = $"{char.ToUpper(valueToLower[0])}{valueToLower.Substring(1, valueToLower.Length - 1)}";
            }
        }

        public string FlourType
        {
            get { return flourType; }
            set
            {
                string valueToLower = value.ToLower();
                if (valueToLower != "white" && valueToLower != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = $"{char.ToUpper(valueToLower[0])}{valueToLower.Substring(1, valueToLower.Length - 1)}";
            }
        }

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private double FlourTypeModifier
        {
            get
            {
                double flourTypeModifier = 0;
                switch (this.FlourType)
                {
                    case "White":
                        flourTypeModifier = 1.5;
                        break;
                    case "Wholegrain":
                        flourTypeModifier = 1.0;
                        break;
                }

                return flourTypeModifier;
            }
        }

        private double BakingTechniqueModifier
        {
            get
            {
                double bakingTechniqueModifier = 0;
                switch (this.BakingTechnique)
                {
                    case "Crispy":
                        bakingTechniqueModifier = 0.9;
                        break;
                    case "Chewy":
                        bakingTechniqueModifier = 1.1;
                        break;
                    case "Homemade":
                        bakingTechniqueModifier = 1.0;
                        break;
                }
                return bakingTechniqueModifier;
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
                return (this.Weight * BaseModifier) * this.FlourTypeModifier * this.BakingTechniqueModifier;
            }
        }
    }

}
