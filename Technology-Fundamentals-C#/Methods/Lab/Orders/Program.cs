using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            TotalCost(product, quantity);

        }

        private static void TotalCost(string product, int quantity)
        {
            double totalPrice = 0.00;
            switch (product)
            {
                case "coffee": totalPrice = quantity * 1.50; break;
                case "water": totalPrice = quantity * 1.00; break;
                case "coke": totalPrice = quantity * 1.40; break;
                case "snacks": totalPrice = quantity * 2.00; break;
            }
            Console.WriteLine(totalPrice);
        }
    }
}
