using System;

namespace Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());

            int numToWorkWith = number;
            int sumOfDigits = 0;
            while (numToWorkWith>0)
            {
                int lastNum = numToWorkWith % 10;
                numToWorkWith = numToWorkWith / 10;
                sumOfDigits += lastNum;
            }

            Console.WriteLine(sumOfDigits);
        }
    }
}
