using System;

namespace Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {

            PrintChars(firstChar: char.Parse(Console.ReadLine()), secondChar: char.Parse(Console.ReadLine()));

        }

        private static void PrintChars(char firstChar, char secondChar)
        {

            if (firstChar > secondChar)
            {
                for (int i = secondChar + 1; i < firstChar; i++)
                {
                    Console.Write((char)i + " ");
                }
            }

            else
            {
                for (int i = firstChar + 1; i < secondChar; i++)
                {
                    Console.Write((char)i + " ");
                }
            }



        }
    }
}
