using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var allPeople = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            var allProducts = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();

            List<Product> products = new List<Product>();

            try
            {
                for (int i = 0; i < allPeople.Length; i++)
                {
                    var tokens = allPeople[i]
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);

                    people.Add(new Person(tokens[0], decimal.Parse(tokens[1])));
                }

                for (int i = 0; i < allProducts.Length; i++)
                {
                    var tokens = allProducts[i]
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);

                    products.Add(new Product(tokens[0], decimal.Parse(tokens[1])));
                }

                while (true)
                {
                    var command = Console.ReadLine();

                    if (command == "END")
                    {
                        break;
                    }

                    var tokens = command.Split();

                    var currentPerson = people.FirstOrDefault(x => x.Name == tokens[0]);

                    var currentProduct = products.FirstOrDefault(x => x.Name == tokens[1]);

                    if (currentPerson != null && currentProduct != null)
                    {
                        if (currentPerson.Money >= currentProduct.Cost)
                        {
                            currentPerson.Products.Add(currentProduct);
                            currentPerson.Money -= currentProduct.Cost;
                            Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                        }

                        else
                        {
                            Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
                        }
                    }

                }

                foreach (var person in people)
                {
                    if (person.Products.Capacity > 0)
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products.Select(x => x.Name))}");
                    }

                    else
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
