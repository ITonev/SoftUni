using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectsComparing
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public string Town { get; set; }

        public Person(string name, int year, string town)
        {
            this.Name = name;
            this.Year = year;
            this.Town = town;
        }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name)!=0)
            {
                return this.Name.CompareTo(other.Name);
            }

            if (this.Year.CompareTo(other.Year) != 0)
            {
                return this.Year.CompareTo(other.Year);
            }

            if (this.Town.CompareTo(other.Town) != 0)
            {
                return this.Town.CompareTo(other.Town);
            }

            return 0;
        }
    }
}
