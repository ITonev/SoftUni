using System;
using System.Collections.Generic;
using System.Linq;

namespace Order_by_Age
{

    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Person> persons = new List<Person>();

            while (command!="End")
            {
                var tokens = command.Split();
                Person person = new Person
                {
                    Name = tokens[0],
                    ID = tokens[1],
                    Age = int.Parse(tokens[2])
                };

                persons.Add(person);

                command = Console.ReadLine();
            }

            foreach (var person in persons.OrderBy(x=>x.Age))
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }
}
