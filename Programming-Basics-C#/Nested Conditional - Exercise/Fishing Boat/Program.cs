using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fisherman = int.Parse(Console.ReadLine());
            double boatrent = 0;

            if (season == "Spring") boatrent = 3000;
            else if (season == "Summer" || season=="Autumn") boatrent = 4200;
            else if (season == "Winter") boatrent = 2600;

            if (fisherman <= 6) boatrent = boatrent * 0.9;
            else if (fisherman > 7 && fisherman<=11) boatrent = boatrent * 0.85;
            else boatrent = boatrent * 0.75;

            if (fisherman % 2 == 0 && season!="Autumn") boatrent = boatrent * 0.95;

            if (budget<boatrent)
            {
                Console.WriteLine($"Not enough money! You need {(boatrent-budget):F2} leva.");
            }
            else
            {
                Console.WriteLine($"Yes! You have {(budget-boatrent):F2} leva left.");
            }
        }
    }
}
