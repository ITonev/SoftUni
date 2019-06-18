using System;
using System.Collections.Generic;

namespace ObjectsComparing
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command=="END")
                {
                    break;
                }

                var tokens = command.Split();

                var person = new Person(tokens[0], int.Parse(tokens[1]), tokens[2]);

                people.Add(person);
            }

            var index = int.Parse(Console.ReadLine());

            var peopleMatches = 1;
            var differentPeople = 0;

            var personToCompare = people[index-1];

            foreach (var person in people)
            {
                if (person==personToCompare)
                {
                    continue;
                }
                
                if (person.CompareTo(personToCompare)==0)
                {
                    peopleMatches++;
                }
                else
                {
                    differentPeople++;
                }
            }

            if (peopleMatches>1)
            {
            Console.WriteLine($"{peopleMatches} {differentPeople} {people.Count}");
            }

            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
