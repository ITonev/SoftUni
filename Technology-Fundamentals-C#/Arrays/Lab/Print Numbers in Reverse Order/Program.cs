using System;

namespace Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            int[] arraysOfNumbers = new int[number];

            for (int i = 0; i < number; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                arraysOfNumbers[i] = currentNumber;
            }

            Array.Reverse(arraysOfNumbers);
            Console.WriteLine(string.Join(" ", arraysOfNumbers));
        }
    }
}
