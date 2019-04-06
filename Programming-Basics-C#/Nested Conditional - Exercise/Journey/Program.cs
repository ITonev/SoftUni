using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double cost = 0;

            if (budget<=100)
            {
                Console.WriteLine("Somewhere in Bulgaria");
                if (season == "summer")
                {
                    cost = budget * 0.30;
                    Console.WriteLine($"Camp - {cost:F2}");
                }
                else if (season == "winter")
                {
                    cost = budget * 0.70;
                    Console.WriteLine($"Hotel - {cost:F2}");
                }
            }
            else if (budget>100 && budget<=1000)
            {
                Console.WriteLine("Somewhere in Balkans");
                if (season == "summer")
                {
                    cost = budget * 0.40;
                    Console.WriteLine($"Camp - {cost:F2}");
                }
                else if (season == "winter")
                {
                    cost = budget * 0.80;
                    Console.WriteLine($"Hotel - {cost:F2}");
                }
            }
            else if (budget>1000)
            {
                Console.WriteLine("Somewhere in Europe");
                    cost = budget * 0.90;
                    Console.WriteLine($"Hotel - {cost:F2}");
            }
        }
    }
}
