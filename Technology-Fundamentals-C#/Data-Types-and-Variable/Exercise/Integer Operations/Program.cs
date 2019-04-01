using System;
using System.Numerics;

namespace Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger firstdigit = BigInteger.Parse(Console.ReadLine()); 
            BigInteger seconddigit = BigInteger.Parse(Console.ReadLine()); 
            BigInteger thirddigit = BigInteger.Parse(Console.ReadLine()); 
            BigInteger forthdigit = BigInteger.Parse(Console.ReadLine());

            BigInteger result = ((firstdigit + seconddigit) / thirddigit) * forthdigit;

            Console.WriteLine(result);
        }
    }
}
