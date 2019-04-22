using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiply_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int lastDigit1 = number % 10;
            int number1 = 0;
            int number2 = 0;           
            
            for (int i = 1; i <= lastDigit1; i++)
            {
                number1 = number;
                number1 = number / 10;
                int lastDigit2 = number1 % 10;

                for (int j = 1; j <= lastDigit2; j++)
                {
                    number2 = number1;
                    number2 = number1 / 10;
                    int lastDigit3 = number2 % 10;
                    for (int k = 1; k <= lastDigit3; k++)

                    {                       
                        Console.WriteLine($"{i} * {j} * {k} = {k*j*i};");
                    }
                }
            }

        }
    }
}
