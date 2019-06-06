using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> People { get; set; }

        public Family()
        {
            this.People = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            int highestAge = int.MinValue;

            foreach (var person in this.People)
            {
                if (person.Age>highestAge)
                {
                    highestAge = person.Age;
                }
            }

            return this.People.Find(x=>x.Age==highestAge);
        }
    }
}
