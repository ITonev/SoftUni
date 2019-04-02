using System;

namespace Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            
            if (dataType == "int")
            {
                PrintNewResult(int.Parse(Console.ReadLine()));
            }
            else if (dataType == "real")
            {
                PrintNewResult(double.Parse(Console.ReadLine()));
            }
            else if (dataType == "string")
            {
                PrintNewResult(Console.ReadLine());
            }

        }

        private static void PrintNewResult(string v)
        {
            Console.WriteLine($"${v}$");
        }

        private static void PrintNewResult(double v)
        {
            Console.WriteLine($"{(v*1.5):f2}");
        }

        private static void PrintNewResult(int v)
        {
            Console.WriteLine(v*2);
        }
    }
}
