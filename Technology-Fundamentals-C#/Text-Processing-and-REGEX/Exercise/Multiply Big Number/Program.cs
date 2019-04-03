using System;
using System.Text;

namespace Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine().TrimStart('0');
            byte multiplyer = byte.Parse(Console.ReadLine());

            Console.WriteLine((bigNumber.Equals("0") || multiplyer == 0) ? "0" : Multiply(bigNumber, multiplyer));

        }

        private static string Multiply(string bigNumber, byte multiplyer)
        {
            StringBuilder result = new StringBuilder(bigNumber.Length + (bigNumber.Length / 2));
            int carry = 0;

            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                int digit = ((bigNumber[i] - '0') * multiplyer) + carry;
                result.Insert(0, digit % 10);

                carry = digit / 10;
            }

            if (carry > 0)
            {
                result.Insert(0, carry);
            }

            return result.ToString();
        }
    }
}
