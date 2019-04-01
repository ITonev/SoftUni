using System;

namespace Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());


            for (int i = 97; i < 97+number; i++)
            {
                var iSymbol = (char)i;

                for (int j = 97; j < 97+number; j++)
                {
                    var jSymbol = (char)j;
                    
                    for (int k = 97; k < 97+number; k++)
                    {
                        var kSymbol = (char)k;

                        Console.WriteLine($"{iSymbol}{jSymbol}{kSymbol}");
                    }
                }
            }
        }
    }
}
