using System;

namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            long[][] pascalArray = new long[size][];


            for (int row = 0; row < size; row++)
            {
                pascalArray[row] = new long[row + 1];

                pascalArray[row][0] = 1;
                pascalArray[row][pascalArray[row].Length - 1] = 1;

                for (int col = 1; col < pascalArray[row].Length - 1; col++)
                {
                    pascalArray[row][col] += pascalArray[row - 1][col] + pascalArray[row - 1][col - 1];
                }
            }

            foreach (var item in pascalArray)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
