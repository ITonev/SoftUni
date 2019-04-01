using System;

namespace Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int oddNumbersCount = int.Parse(Console.ReadLine());
            int numbersSum = 0;
            int numberToPrint = 1;

            for (int i = 1; i <= oddNumbersCount; i++)
            {
                Console.WriteLine(numberToPrint);
                numbersSum += numberToPrint;
                numberToPrint += 2;
            }

            Console.WriteLine($"Sum: {numbersSum}");
        }
    }
}
