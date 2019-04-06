using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string imput = Console.ReadLine();

            int primeSum = 0;
            int nonPrimeSum = 0;            
            
            while (imput!="stop")
            {
                int number = int.Parse(imput);

                bool prime = true;

                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        prime = false; break;
                    }                    
                }

                if (number < 0) Console.WriteLine("Number is negative.");
                else if (prime == false || number==1) nonPrimeSum += number;
                else if (prime == true) primeSum += number;

                imput = Console.ReadLine();
                if (imput == "stop") break;
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");

        }
    }
}
