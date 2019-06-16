using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> salads;

        public string Name { get; set; }

        public Restaurant(string name)
        {
            this.Name = name;
            this.salads = new List<Salad>();
        }

        public void Add(Salad salad)
        {
            this.salads.Add(salad);
        }

        public bool Buy(string name)
        {
            var salad = this.salads.FirstOrDefault(x => x.Name == name);
            this.salads.Remove(salad);

            if (salad != null)
            {
                return true;
            }

            return false;
        }

        public string GetHealthiestSalad()
        {
            var healtiest = this.salads.OrderBy(x => x.Vegetables.Select(y => y.Calories).Sum()).FirstOrDefault();
            return healtiest.Name;
        }

        public string GenerateMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} have {this.salads.Count} salads:");
            sb.AppendLine(string.Join(Environment.NewLine, this.salads));

            return sb.ToString().Trim();
        }
    }
}
