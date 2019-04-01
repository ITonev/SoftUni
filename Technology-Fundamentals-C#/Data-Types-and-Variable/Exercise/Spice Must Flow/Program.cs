using System;

namespace Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            int totalSpice = 0;
            int daysCount = 0;

            while (startingYield>=100)
            {
                totalSpice += startingYield;
                totalSpice -= 26; //for workers//
                daysCount++;
                startingYield -= 10;
            }

            if (totalSpice<26) totalSpice = 0;
            else totalSpice -= 26;

            Console.WriteLine($"{daysCount}\n{totalSpice}");
        }
    }
}
