using System;

namespace Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                if (true)
                {

                }

                int isInt;
                bool isBool;
                double isDouble;
                char isChar;

                if (int.TryParse(input, out isInt))
                {
                    Console.WriteLine($"{input} is integer type");

                }
                else if (double.TryParse(input, out isDouble))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (bool.TryParse(input, out isBool))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else if (char.TryParse(input, out isChar))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }
            }
        }
    }
}
