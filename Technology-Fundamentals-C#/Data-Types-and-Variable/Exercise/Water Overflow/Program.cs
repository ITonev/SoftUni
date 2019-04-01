using System;

namespace Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalWaterQuantity = 0;
            for (int i = 0; i < n; i++)
            {
                int waterQuantities = int.Parse(Console.ReadLine());
                totalWaterQuantity += waterQuantities;
                if (totalWaterQuantity>255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    totalWaterQuantity -= waterQuantities;
                }
                
            }
            Console.WriteLine(totalWaterQuantity);
        }
    }
}
