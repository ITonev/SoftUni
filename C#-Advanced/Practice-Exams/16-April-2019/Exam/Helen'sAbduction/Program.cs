using System;

namespace Helen_sAbduction
{
    public class Program
    {
        static int parisRow;
        static int parisCol;
        static int energy;

        static void Main()
        {
            energy = int.Parse(Console.ReadLine());

            int rowNumbers = int.Parse(Console.ReadLine());

            char[][] field = new char[rowNumbers][];

            FieldFill(field);

            while (energy > 0)
            {
                string[] input = Console.ReadLine().Split();

                string direction = input[0];
                int spawnRow = int.Parse(input[1]);
                int spawnCol = int.Parse(input[2]);

                field[spawnRow][spawnCol] = 'S';

                ParisMovement(field, direction);

                if (field[parisRow][parisCol] == 'H')
                {
                    field[parisRow][parisCol] = '-';
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                    break;
                }

                if (energy <= 0)
                {
                    field[parisRow][parisCol] = 'X';
                    Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                    break;
                }

                field[parisRow][parisCol] = 'P';
            }

            for (int row = 0; row < field.Length; row++)
            {
                Console.WriteLine(string.Join("", field[row]));
            }
        }

        private static void ParisMovement(char[][] field, string direction)
        {
            switch (direction)
            {
                case "up":
                    if (FieldBoundaryCheck(field, parisRow - 1, parisCol))
                    {
                        field[parisRow][parisCol] = '-';
                        parisRow--;

                        if (field[parisRow][parisCol] == 'S')
                        {
                            energy -= 2;
                        }
                        
                        energy--;
                    }

                    break;

                case "down":
                    if (FieldBoundaryCheck(field, parisRow + 1, parisCol))
                    {
                        field[parisRow][parisCol] = '-';
                        parisRow++;

                        if (field[parisRow][parisCol] == 'S')
                        {
                            energy -= 2;
                        }

                        energy--;
                    }

                    break;

                case "left":
                    if (FieldBoundaryCheck(field, parisRow, parisCol - 1))
                    {
                        field[parisRow][parisCol] = '-';
                        parisCol--;

                        if (field[parisRow][parisCol] == 'S')
                        {
                            energy -= 2;
                        }

                        energy--;
                    }

                    break;

                case "right":
                    if (FieldBoundaryCheck(field, parisRow, parisCol + 1))
                    {
                        field[parisRow][parisCol] = '-';
                        parisCol++;

                        if (field[parisRow][parisCol] == 'S')
                        {
                            energy -= 2;
                        }

                        energy--;
                    }

                    break;
            }
        }

        private static bool FieldBoundaryCheck(char[][] field, int row, int col)
        {
            if (row < 0
                || row >= field.Length
                || col < 0
                || col >= field.Length)
            {
                energy--;
                return false;
            }

            return true;
        }

        private static void FieldFill(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                char[] cols = Console.ReadLine().ToCharArray();

                field[row] = new char[cols.Length];

                for (int col = 0; col < cols.Length; col++)
                {
                    field[row][col] = cols[col];

                    if (field[row][col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }
                }
            }
        }
    }
}
