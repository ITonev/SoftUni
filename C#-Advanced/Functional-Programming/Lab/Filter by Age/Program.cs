using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_by_Age
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var man = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                var person = new Person
                {
                    Name = man[0],
                    Age = int.Parse(man[1])
                };

                people.Add(person);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, string> filter = Filter(people, format);

            foreach (var person in people.Where(p => condition == "older" ? p.Age >= age : p.Age < age).Select(filter))
            {
                Console.WriteLine(person);
            }
        }

        private static Func<Person, string> Filter(List<Person> people, string format)
        {
            switch (format)
            {
                case "name age": return p => $"{p.Name} - {p.Age}";
                case "name": return p => $"{p.Name}";
                case "age": return p => $"{p.Age}";
                default: return null;
            }
        }
    }
}
