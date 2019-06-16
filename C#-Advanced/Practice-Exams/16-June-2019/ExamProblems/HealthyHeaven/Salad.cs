using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        public List<Vegetable> Vegetables { get; set; }
        

        public string Name { get; set; }

        public int Count => this.Vegetables.Count;

        public Salad(string name)
        {
            this.Name = name;
            this.Vegetables = new List<Vegetable>();
        }

        public int GetTotalCalories()
        {
            return this.Vegetables.Select(x => x.Calories).Sum();
        }

        public int GetProductCount()
        {
            return this.Count;
        }

        public void Add(Vegetable vegetable)
        {
            this.Vegetables.Add(vegetable);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"* Salad {this.Name} is {this.Vegetables.Select(x=>x.Calories).Sum()} calories and have {this.Vegetables.Count} products:");
            sb.AppendLine(string.Join(Environment.NewLine, this.Vegetables));
            return sb.ToString().Trim();
        }

    }
}
