using System;
using System.Collections.Generic;
using System.Linq;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> newList = new List<int>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", collection));
                }

                else
                {
                    Func<List<int>, List<int>> funk = Commands(collection, command);
                    collection = funk(collection);
                }
            }
        }

        private static Func<List<int>, List<int>> Commands(List<int> collection, string command)
        {
            switch (command)
            {
                case "add": return x => x.Select(y => y + 1).ToList();
                case "multiply": return x => x.Select(y => y * 2).ToList();
                case "subtract": return x => x.Select(y => y - 1).ToList();
                default: return null;
            }
        }
    }
}
