using System;

namespace Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            int factorialSum = 0;
            int checkSum = number;

            while (checkSum!=0)
            {
                var currentNum = checkSum % 10;
                checkSum /= 10;

                var factorial = 1;

                for (int i = 1; i <= currentNum; i++)
                {
                    factorial *= i;
                }

                factorialSum += factorial;
            }

            if (number==factorialSum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
