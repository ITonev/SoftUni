using System;

namespace Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingIndex = int.Parse(Console.ReadLine());
            int endingIndex = int.Parse(Console.ReadLine());

            for (int i = startingIndex; i <= endingIndex; i++)
            {
                char currentSymbol = (char)i;
                Console.Write(currentSymbol+" ");
            }
        }
    }
}
