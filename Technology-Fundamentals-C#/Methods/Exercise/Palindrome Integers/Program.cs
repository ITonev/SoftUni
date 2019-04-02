using System;
using System.Linq;

namespace Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command=="END")
                {
                    break;
                }

                int number = int.Parse(command);
                bool palidrome = IsItPalidrome(number);
                if (palidrome) Console.WriteLine("true");
                else Console.WriteLine("false");
            }

        }

        private static bool IsItPalidrome(int number)
        {
            int currentNum = number;
            int reversed = 0;
            while (number > 0)
            {
                reversed = reversed * 10 + number % 10;
                number /= 10;
            }

            return reversed == currentNum;
        }
    }
}
