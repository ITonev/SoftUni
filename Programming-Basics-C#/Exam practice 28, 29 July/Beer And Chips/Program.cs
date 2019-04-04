using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer_And_Chips
{
    class Program
    {
        static void Main(string[] args)
        {

            string Fan = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int beerBottles = int.Parse(Console.ReadLine());
            int chipsBags = int.Parse(Console.ReadLine());

            double beerPrice = 1.20;
            

            double totalBeerPrice = beerPrice * beerBottles;
            double chipsPrice = (totalBeerPrice * 0.45);
            double totalChipsPrice = Math.Ceiling(chipsPrice * chipsBags);

            double moneyLeft = budget - totalBeerPrice - totalChipsPrice;

            if (moneyLeft>=0)
            {
                Console.WriteLine($"{Fan} bought a snack and has {moneyLeft:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"{Fan} needs {(totalChipsPrice+totalBeerPrice-budget):F2} more leva!");
            }


        }
    }
}
