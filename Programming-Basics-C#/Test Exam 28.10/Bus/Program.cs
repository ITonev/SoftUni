using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialPassengers = int.Parse(Console.ReadLine());
            int busStops = int.Parse(Console.ReadLine());
            int totalPassengers = initialPassengers;
            for (int i = 1; i <=busStops; i++)
            {
                int passengersLeaving = int.Parse(Console.ReadLine());
                int passengersBoarding = int.Parse(Console.ReadLine());

                if (i%2==0) totalPassengers += passengersBoarding - passengersLeaving - 2;
                else totalPassengers += passengersBoarding - passengersLeaving + 2;
                
            }
            Console.WriteLine($"The final number of passengers is : {totalPassengers}");
        }
    }
}
