using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double studio = 0;
            double apartment = 0;

            if (month=="May" || month=="October")
            {
                if (nights > 7 && nights <= 14) studio = (nights * 50) * 0.95;
                else if (nights > 14) studio = (nights * 50) * 0.70;
                else
                  studio = nights * 50;
                  apartment = nights * 65;
            }
            else if (month == "June" || month == "September")
            {
                if (nights > 14) studio = (nights * 75.20) * 0.80;
                else
                    studio = nights * 75.20;
                    apartment = nights * 68.70;
            }
            else if (month == "July" || month == "August")
            {
                studio = nights * 76;
                apartment = nights * 77;
            }
            if (nights > 14) Console.WriteLine($"Apartment: {(apartment * 0.90):F2} lv.");
            else Console.WriteLine($"Apartment: {apartment:F2} lv."); 

            Console.WriteLine($"Studio: {studio:F2} lv.");
        }
    }
}
