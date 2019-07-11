using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : Identification, IPersonalInfo
    {
        public Citizen(string name, int age, string id, string birthDate)
            :base(id)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthDate;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Birthdate { get; set; }
    }
}
