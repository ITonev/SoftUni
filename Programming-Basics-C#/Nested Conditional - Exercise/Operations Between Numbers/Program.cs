using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double N1 = double.Parse(Console.ReadLine());
            double N2 = double.Parse(Console.ReadLine());
            string op = Console.ReadLine();
            string parity = "odd";


            if (op == "+")
            {
                if ((N1 + N2) % 2 == 0) parity = "even";
                Console.WriteLine($"{N1} {op} {N2} = {N1 + N2} - {parity}");

            }
            else if (op=="-")
            {
                if ((N1 - N2) % 2 == 0) parity = "even";
                Console.WriteLine($"{N1} {op} {N2} = {N1 - N2} - {parity}");
            }
            else if (op=="*")
            {
                if ((N1 * N2) % 2 == 0) parity = "even";
                Console.WriteLine($"{N1} {op} {N2} = {N1 * N2} - {parity}");
            }
            else if (op=="/")
            {
                if (N2 == 0) Console.WriteLine($"Cannot divide {N1} by zero");
                else Console.WriteLine($"{ N1} / { N2} = {(N1/N2):F2}");
            }
            else if (op=="%")
            {
                if (N2 == 0) Console.WriteLine($"Cannot divide {N1} by zero");
                else Console.WriteLine($"{ N1} % { N2} = {N1%N2}");
            }
            
        }
    }
}
