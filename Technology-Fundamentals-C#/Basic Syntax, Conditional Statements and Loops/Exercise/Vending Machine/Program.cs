using System;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal totalMoney = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Start")
                {
                    break;
                }

                double coinsInserted = double.Parse(input);

                if (coinsInserted != 0.1 && coinsInserted != 0.2 && coinsInserted != 0.5 && coinsInserted != 1 && coinsInserted != 2)
                {
                    Console.WriteLine($"Cannot accept {coinsInserted}");
                }

                else
                {
                    totalMoney += (decimal)coinsInserted;
                }
            }

            while (true)
            {
                decimal productPrice = 0;
                string product = Console.ReadLine();
                if (product == "End")
                {
                    break;
                }

                switch (product)
                {
                    case "Nuts": productPrice = 2.0m; break;
                    case "Water": productPrice = 0.70m; break;
                    case "Crisps": productPrice = 1.50m; break;
                    case "Soda": productPrice = 0.80m; break;
                    case "Coke": productPrice = 1.0m; break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }

                if (totalMoney - productPrice < 0)
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                else
                {
                    if (product == "Nuts" || product == "Water" || product == "Crisps" || product == "Soda" || product == "Coke")
                    {
                        totalMoney -= productPrice;
                        Console.WriteLine($"Purchased {product.ToLower()}");
                    }
                }
            }

            Console.WriteLine($"Change: {totalMoney:f2}");

        }
    }
}
