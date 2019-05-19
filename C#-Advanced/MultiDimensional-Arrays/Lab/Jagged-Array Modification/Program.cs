using System;
using System.Linq;

namespace Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[][] jaggedArrray = new int[size][];

            for (int row = 0; row < size; row++)
            {
                jaggedArrray[row] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }

            string input = string.Empty; ;

            while ((input = Console.ReadLine())!= "END")
            {
                var tokens = input.Split();

                var command = tokens[0];
                var row = int.Parse(tokens[1]);
                var col = int.Parse(tokens[2]);
                var value = int.Parse(tokens[3]);

                if (row<0
                    || col<0
                    || row>=size
                    || col>=jaggedArrray[row].Length)
                {
                    Console.WriteLine($"Invalid coordinates");
                    continue;
                }

                if (command=="Add")
                {
                    jaggedArrray[row][col] += value;
                }

                else if (command=="Subtract")
                {
                    jaggedArrray[row][col] -= value;

                }
            }

            foreach (var item in jaggedArrray)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
