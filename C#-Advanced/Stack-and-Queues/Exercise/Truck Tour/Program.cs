using System;
using System.Linq;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int truckFuel = 0;
            int startIndex = 0;

            for (int i = 0; i < n; i++)
            {
                var fuelPump = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var fuel = fuelPump[0];
                var distance = fuelPump[1];

                truckFuel += fuel - distance;

                if (truckFuel<0)
                {
                    truckFuel = 0;
                    startIndex = i + 1;
                }
            }

            Console.WriteLine(startIndex);
        }
    }
}
