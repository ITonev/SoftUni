using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string imput = Convert.ToString(number);

           
            int lastNumberToPrint = 0;   //to be added to 33

            for (int i = 0; i < imput.Length; i++)
            {
                int lastNumber = number % 10;
                number /= 10;
                lastNumberToPrint = lastNumber + 33;

                for (int j = 0; j < lastNumber; j++)
                {
                    Console.Write((char)lastNumberToPrint);
                }   
                
                if (lastNumber == 0) Console.WriteLine("ZERO");
                else Console.WriteLine();
            }
        }
    }
}
