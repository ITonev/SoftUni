using System;

namespace Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            double distanceInMeters = double.Parse(Console.ReadLine());
            double inKm = distanceInMeters / 1000;
            Console.WriteLine($"{inKm:f2}");
        }
    }
}
