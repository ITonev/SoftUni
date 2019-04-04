using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double average = double.Parse(Console.ReadLine());
            double minwage = double.Parse(Console.ReadLine());
            double social = 0;
            double success = 0;

            if (income>minwage || average<5.50)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            if (income<=minwage && average>4.50)
            {
                social = minwage * 0.35;
            }
            if (average>=5.50)
            {
                success = average * 25;
            }
            if (social>success)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(social)} BGN");
            }
            else
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(success)} BGN");
            }

        }
    }
}
