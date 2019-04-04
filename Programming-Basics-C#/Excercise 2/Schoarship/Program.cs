using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double average = double.Parse(Console.ReadLine());
            double minwage = double.Parse(Console.ReadLine());
            double social = minwage * 0.35;
            double success = average * 0.25;

            if (average >= 5.50)
            {
                if (success >= social || income > minwage)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(success)} BGN");

                }
                else
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(social)} BGN");

                }

            }
            else if (income < minwage && average > 4.50)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(social)} BGN");

            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");

            }

        }
    }
}
