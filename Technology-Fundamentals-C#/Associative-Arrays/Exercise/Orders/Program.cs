using System;
using System.Collections.Generic;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var productsPrice = new Dictionary<string, double>();
            var productsQuantity = new Dictionary<string, int>();

            while (true)
            {
                var command = Console.ReadLine();
                if (command=="buy")
                {
                    break;
                }

                var tokens = command.Split();
                var product = tokens[0];
                var price = double.Parse(tokens[1]);
                var quantity = int.Parse(tokens[2]);

                if (!productsPrice.ContainsKey(product))
                {
                    productsPrice.Add(product, 0);
                }

                productsPrice[product] = price;

                if (!productsQuantity.ContainsKey(product))
                {
                    productsQuantity.Add(product, 0);
                }

                productsQuantity[product] += quantity;
            }

            foreach (var kvp in productsPrice)
            {
                var product = kvp.Key;
                Console.WriteLine($"{product} -> {(productsPrice[product]*productsQuantity[product]):f2}");
            }

        }
    }
}
