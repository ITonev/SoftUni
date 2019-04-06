using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());
            double remaining = 0;
            double ticketprice = 0;

            if (category == "Normal") ticketprice = 249.99;
            else if (category == "VIP") ticketprice = 499.99;

            if (people >= 1 && people <= 4) remaining = budget - (budget * 0.75);
            else if (people >=5 && people <=9) remaining = budget - (budget * 0.60);
            else if (people >=10 && people <=24) remaining = budget - (budget * 0.50);
            else if (people >=25 && people <=49) remaining = budget - (budget * 0.40);
            else if (people >=50) remaining = budget - (budget * 0.25);

            if (remaining>=ticketprice*people)
            {
                Console.WriteLine($"Yes! You have {(remaining - (people * ticketprice)):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {((people * ticketprice) - remaining):F2} leva.");
            }
        }
    }
}
