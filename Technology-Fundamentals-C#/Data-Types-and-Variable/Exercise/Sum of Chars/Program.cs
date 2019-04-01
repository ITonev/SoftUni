using System;

namespace Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalSum = 0;
            for (int i = 0; i < n; i++)
            {
                char currentLetter = char.Parse(Console.ReadLine());

                int currentNum = (int)currentLetter;
                totalSum += currentNum;
            }

            Console.WriteLine($"The sum equals: {totalSum}");
        }
    }
}
