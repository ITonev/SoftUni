using System;

namespace Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            Substract (Sum(first, second),third);

        }

        private static void Substract(int v1, int v2)
        {
            Console.WriteLine(v1-v2);
        }

        private static int Sum(int first, int second)
        {
            return first + second;
        }
    }
}
