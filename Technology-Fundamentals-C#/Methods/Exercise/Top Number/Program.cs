using System;
using System.Linq;

namespace Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 17; i < number; i++)
            {
                bool isItTopNumber = IsItTopNumber(i);
                if (isItTopNumber)
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool IsItTopNumber(int i)
        {

            int sumOfDigits = i.ToString().Sum(x=>x-'0');

            if (!(sumOfDigits % 8 == 0))
            {
                return false;
            }

            while (i>0)
            {
                int currentNum = i % 10;
                i /= 10;

                if (currentNum%2!=0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
