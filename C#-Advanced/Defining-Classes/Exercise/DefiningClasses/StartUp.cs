using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                var currrentPerson = Console.ReadLine().Split();
                Person person = new Person(currrentPerson[0], int.Parse(currrentPerson[1]));

                family.AddMember(person);
            }

            var oldest = family.GetOldestMember();

            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
