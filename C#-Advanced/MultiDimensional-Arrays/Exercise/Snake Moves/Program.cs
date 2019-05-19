using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var word = Console.ReadLine().ToCharArray();

            Queue<char> snake = new Queue<char>(word);
           
                char[,] matrix = new char[size[0], size[1]];
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var currentChar = snake.Dequeue();
                    matrix[row, col] = currentChar;
                    snake.Enqueue(currentChar);
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]}");
                }

                Console.WriteLine();
            }
        }
    }
}
