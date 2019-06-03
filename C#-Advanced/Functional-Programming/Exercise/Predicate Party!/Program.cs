using System;
using System.Linq;

namespace Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine().Split().ToList();


            var command = Console.ReadLine();

            while (command != "Party!")
            {
                var tokens = command.Split();
                var secondCommand = tokens[1];

                Func<string, bool> filter;

                switch (tokens[0])
                {
                    case "Remove" when secondCommand == "StartsWith":
                        filter = x => !x.StartsWith(tokens[2]);
                        break;

                    case "Remove" when secondCommand == "EndsWith":
                        filter = x => !x.EndsWith(tokens[2]);
                        break;

                    case "Remove" when secondCommand == "Lenght":
                        filter = x => x.Length != int.Parse(tokens[2]);
                        break;

                    case "Double" when secondCommand == "StartsWith":
                        filter = x => x.StartsWith(tokens[2]);
                        break;

                    case "Double" when secondCommand == "EndsWith":
                        filter = x => x.EndsWith(tokens[2]);
                        break;

                    default: //"Double" when secondCommand == "Lenght":
                        filter = x => x.Length == int.Parse(tokens[2]);
                        break;

                }

                if (tokens[0] == "Remove")
                {
                    people = people.Where(filter).ToList();
                }

                else if (tokens[0] == "Double")
                {
                    var tempList = people.Where(filter).ToList();

                    foreach (var guest in tempList)
                    {
                        var guestIndex = people.IndexOf(guest);
                        people.Insert(guestIndex, guest);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(people.Any()
                ? $"{string.Join(", ", people)} are going to the party!"
                : "Nobody is going to the party!");
        }
    }
}

