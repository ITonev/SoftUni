using System;

namespace TronRacers
{
    public class Program
    {
        static int firstPlayerRowPosition;
        static int firstPlayerColPosition;
        static int secondPlayerRowPosition;
        static int secondPlayerColPosition;
        static bool isAlive = true;

        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                var currentCol = Console.ReadLine().ToCharArray();

                for (int col = 0; col < currentCol.Length; col++)
                {
                    matrix[row, col] = currentCol[col];
                    if (currentCol[col] == 'f')
                    {
                        firstPlayerRowPosition = row;
                        firstPlayerColPosition = col;
                    }
                    else if (currentCol[col] == 's')
                    {
                        secondPlayerRowPosition = row;
                        secondPlayerColPosition = col;
                    }
                }
            }

            while (isAlive != false)
            {
                var input = Console.ReadLine().Split();

                var firstPlayerCommand = input[0];
                var secondPlayerCommand = input[1];

                FirstPlayerMovement(matrix, firstPlayerCommand);

                if (isAlive != false)
                {
                    SecondPlayerMovement(matrix, secondPlayerCommand);
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void SecondPlayerMovement(char[,] matrix, string command)
        {
            switch (command)
            {
                case "up":
                    if (secondPlayerRowPosition - 1 < 0)
                    {
                        secondPlayerRowPosition = matrix.GetLength(0) - 1;
                    }
                    else
                    {
                        secondPlayerRowPosition--;
                    }

                    if (matrix[secondPlayerRowPosition, secondPlayerColPosition] == 'f')
                    {
                        matrix[secondPlayerRowPosition, secondPlayerColPosition] = 'x';
                        isAlive = false;
                    }
                    else
                    {
                        matrix[secondPlayerRowPosition, secondPlayerColPosition] = 's';
                    }
                    break;

                case "down":
                    if (secondPlayerRowPosition + 1 > matrix.GetLength(0) - 1)
                    {
                        secondPlayerRowPosition = 0;
                    }
                    else
                    {
                        secondPlayerRowPosition++;
                    }

                    if (matrix[secondPlayerRowPosition, secondPlayerColPosition] == 'f')
                    {
                        matrix[secondPlayerRowPosition, secondPlayerColPosition] = 'x';
                        isAlive = false;
                    }
                    else
                    {
                        matrix[secondPlayerRowPosition, secondPlayerColPosition] = 's';
                    }

                    break;

                case "left":
                    if (secondPlayerColPosition - 1 < 0)
                    {
                        secondPlayerColPosition = matrix.GetLength(1) - 1;
                    }
                    else
                    {
                        secondPlayerColPosition--;
                    }

                    if (matrix[secondPlayerRowPosition, secondPlayerColPosition] == 'f')
                    {
                        matrix[secondPlayerRowPosition, secondPlayerColPosition] = 'x';
                        isAlive = false;
                    }
                    else
                    {
                        matrix[secondPlayerRowPosition, secondPlayerColPosition] = 's';
                    }

                    break;

                case "right":
                    if (secondPlayerColPosition + 1 > matrix.GetLength(1) - 1)
                    {
                        secondPlayerColPosition = 0;
                    }
                    else
                    {
                        secondPlayerColPosition++;
                    }

                    if (matrix[secondPlayerRowPosition, secondPlayerColPosition] == 'f')
                    {
                        matrix[secondPlayerRowPosition, secondPlayerColPosition] = 'x';
                        isAlive = false;
                    }
                    else
                    {
                        matrix[secondPlayerRowPosition, secondPlayerColPosition] = 's';
                    }

                    break;
            }

        }

        private static void FirstPlayerMovement(char[,] matrix, string command)
        {
            switch (command)
            {
                case "up":
                    if (firstPlayerRowPosition - 1 < 0)
                    {
                        firstPlayerRowPosition = matrix.GetLength(0) - 1;
                    }
                    else
                    {
                        firstPlayerRowPosition--;
                    }

                    if (matrix[firstPlayerRowPosition, firstPlayerColPosition] == 's')
                    {
                        matrix[firstPlayerRowPosition, firstPlayerColPosition] = 'x';
                        isAlive = false;
                    }
                    else
                    {
                        matrix[firstPlayerRowPosition, firstPlayerColPosition] = 'f';
                    }
                    break;

                case "down":
                    if (firstPlayerRowPosition + 1 > matrix.GetLength(0) - 1)
                    {
                        firstPlayerRowPosition = 0;
                    }
                    else
                    {
                        firstPlayerRowPosition++;
                    }

                    if (matrix[firstPlayerRowPosition, firstPlayerColPosition] == 's')
                    {
                        matrix[firstPlayerRowPosition, firstPlayerColPosition] = 'x';
                        isAlive = false;
                    }
                    else
                    {
                        matrix[firstPlayerRowPosition, firstPlayerColPosition] = 'f';
                    }

                    break;

                case "left":
                    if (firstPlayerColPosition - 1 < 0)
                    {
                        firstPlayerColPosition = matrix.GetLength(1) - 1;
                    }
                    else
                    {
                        firstPlayerColPosition--;
                    }

                    if (matrix[firstPlayerRowPosition, firstPlayerColPosition] == 's')
                    {
                        matrix[firstPlayerRowPosition, firstPlayerColPosition] = 'x';
                        isAlive = false;
                    }
                    else
                    {
                        matrix[firstPlayerRowPosition, firstPlayerColPosition] = 'f';
                    }

                    break;

                case "right":
                    if (firstPlayerColPosition + 1 > matrix.GetLength(1) - 1)
                    {
                        firstPlayerColPosition = 0;
                    }
                    else
                    {
                        firstPlayerColPosition++;
                    }

                    if (matrix[firstPlayerRowPosition, firstPlayerColPosition] == 's')
                    {
                        matrix[firstPlayerRowPosition, firstPlayerColPosition] = 'x';
                        isAlive = false;
                    }
                    else
                    {
                        matrix[firstPlayerRowPosition, firstPlayerColPosition] = 'f';
                    }

                    break;
            }
        }
    }
}
