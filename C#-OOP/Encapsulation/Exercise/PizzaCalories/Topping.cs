using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double baseCaloriesPerGram = 2;

        private string type;
        private int weight;

        private Dictionary<string, double> typesModifiers;

        public Topping(string type, int weight)
        {
            this.typesModifiers = new Dictionary<string, double>();
            this.TypesDictionaryFillling();

            this.Type = type;
            this.Weight = weight;


        }

        public double Calories => this.CaloriesCalculator();

        public string Type
        {
            get => this.type;

            private set
            {
                if (!this.typesModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public int Weight
        {
            get => this.weight;

            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        private double CaloriesCalculator()
        {
            return baseCaloriesPerGram * (this.Weight * this.typesModifiers[this.Type]);
        }

        private void TypesDictionaryFillling()
        {
            this.typesModifiers.Add("meat", 1.2);
            this.typesModifiers.Add("veggies", 0.8);
            this.typesModifiers.Add("cheese", 1.1);
            this.typesModifiers.Add("sauce", 0.9);
        }

    }
}
