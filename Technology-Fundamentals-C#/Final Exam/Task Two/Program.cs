using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> stores = new Dictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var tokens = input.Split("->");
                var command = tokens[0];
                var store = tokens[1];

                if (command == "Add")
                {
                    var product = tokens[2].Split(",").ToList();

                    if (!stores.ContainsKey(store))
                    {
                        stores[store] = new List<string>();
                    }

                    foreach (var item in product)
                    {
                        stores[store].Add(item);
                    }

                }

                else if (command == "Remove")
                {
                    if (stores.ContainsKey(store))
                    {
                        stores.Remove(store);
                    }
                }
            }

            Console.WriteLine("Stores list:");

            foreach (var kvp in stores.OrderByDescending(x=>x.Value.Count()).ThenByDescending(x=>x.Key))
            {
                var store = kvp.Key;
                var products = kvp.Value;

                Console.WriteLine(store);

                foreach (var product in products)
                {
                    Console.WriteLine($"<<{product}>>");
                }
            }
        }
    }
}
