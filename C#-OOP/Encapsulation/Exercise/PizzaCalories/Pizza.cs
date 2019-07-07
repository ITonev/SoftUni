using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.toppings = new List<Topping>();

            this.Name = name;
            this.Dough = dough;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get => this.dough;

            private set
            {
                this.dough = value;
            }
        }

        public int ToppingsCount => this.toppings.Count;

        public double Calories => this.PizzaCalories();

        public void AddTopping(Topping currentTopping)
        {
            var type = currentTopping.Type.ToLower();
            var weight = currentTopping.Weight;
            Topping topping = new Topping(type, weight);

            if (toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        private double PizzaCalories()
        {
            var toppingsCalories = this.toppings.Select(x => x.Calories).Sum();
            var doughCalories = this.Dough.Calories;
            return doughCalories + toppingsCalories;
        }
    }
}
