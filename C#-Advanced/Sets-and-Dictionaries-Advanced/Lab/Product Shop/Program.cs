using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    class ProductList
    {
        public string Product { get; set; }
        public double Price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<ProductList>> products = new Dictionary<string, List<ProductList>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Revision")
                {
                    break;
                }

                var tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var shop = tokens[0];
                var product = tokens[1];
                var price = double.Parse(tokens[2]);

                ProductList newProduct = new ProductList
                {
                    Product = product,
                    Price = price
                };

                if (!products.ContainsKey(shop))
                {
                    products[shop] = new List<ProductList>();
                }

                products[shop].Add(newProduct);
            }

            foreach (var kvp in products.OrderBy(x => x.Key))
            {
                var currentShop = kvp.Key;
                var productsList = kvp.Value;

                Console.WriteLine($"{currentShop}->");

                foreach (var kvpProduct in productsList)
                {
                    Console.WriteLine($"Product: {kvpProduct.Product}, Price: {kvpProduct.Price}");
                }
            }
        }
    }
}