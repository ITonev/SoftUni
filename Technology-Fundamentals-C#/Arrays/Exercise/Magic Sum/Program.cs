using System;
using System.Linq;

namespace Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arrayOfNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                for (int k = i + 1; k < arrayOfNumbers.Length; k++)
                {
                    if (arrayOfNumbers[i] + arrayOfNumbers[k] == number)
                    {
                        Console.WriteLine(arrayOfNumbers[i] + " " + arrayOfNumbers[k]);
                    }
                }
            }

        }
    }
}
