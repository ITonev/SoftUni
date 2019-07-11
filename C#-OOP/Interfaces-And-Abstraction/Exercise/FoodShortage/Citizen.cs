using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : Identification, IBuyer
    {
        public Citizen(string name, int age, string id, string birthDate)
            :base(id)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthDate;
            this.Food = 0;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Birthdate { get; set; }

        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
