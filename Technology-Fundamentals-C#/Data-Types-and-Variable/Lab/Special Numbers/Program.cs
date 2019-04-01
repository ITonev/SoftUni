using System;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());


            for (int i = 1; i <= number; i++)
            {
                int lastDigit = i;
                int currentItemSum = 0;
                while (lastDigit>0)
                {
                    currentItemSum += lastDigit % 10;
                    lastDigit = lastDigit / 10;
                }
                if (currentItemSum==5 || currentItemSum==7 || currentItemSum==11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }

            }
        }
    }
}
