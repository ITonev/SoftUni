using System;
using System.Collections.Generic;
using System.Linq;

namespace Opinion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var currentPerson = Console.ReadLine().Split();

                var name = currentPerson[0];
                var age = int.Parse(currentPerson[1]);

                people.Add(new Person(name, age));
            }

            foreach (var person in people.Where(x=>x.Age>30).OrderBy(y=>y.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
