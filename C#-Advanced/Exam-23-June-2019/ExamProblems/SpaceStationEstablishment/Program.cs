using System;

namespace SpaceStationEstablishment
{
    class Program
    {
        static int spaceshipRow;
        static int spaceshipCol;
        static int starPower;
        static bool intoTheVold = false;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] galaxy = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                var cols = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols.Length; col++)
                {
                    galaxy[row, col] = cols[col];

                    if (galaxy[row, col] == 'S')
                    {
                        spaceshipRow = row;
                        spaceshipCol = col;
                    }
                }
            }


            while (starPower < 50)
            {

                var command = Console.ReadLine();

                Movement(galaxy, command);

                if (intoTheVold)
                {
                    Console.WriteLine("Bad news, the spaceship went to the void.");
                    Console.WriteLine($"Star power collected: {starPower}");
                    break;
                }
            }

            if (starPower >= 50)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                Console.WriteLine($"Star power collected: {starPower}");
            }

            for (int row = 0; row < galaxy.GetLength(0); row++)
            {
                for (int col = 0; col < galaxy.GetLength(0); col++)
                {
                    Console.Write(galaxy[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void Movement(char[,] galaxy, string command)
        {
            switch (command)
            {
                case "up":
                    galaxy[spaceshipRow, spaceshipCol] = '-';
                    if (BoundriesCheck(galaxy, spaceshipRow - 1, spaceshipCol))
                    {
                        spaceshipRow--;

                        if (char.IsDigit(galaxy[spaceshipRow, spaceshipCol]))
                        {
                            var currentStarPower = galaxy[spaceshipRow, spaceshipCol] - '0';
                            starPower += currentStarPower;
                            galaxy[spaceshipRow, spaceshipCol] = 'S';

                        }

                        else if (char.IsLetter(galaxy[spaceshipRow, spaceshipCol]))
                        {
                            galaxy[spaceshipRow, spaceshipCol] = '-';
                            FindNextBlackHole(galaxy);
                        }
                    }
                    else
                    {

                        intoTheVold = true;
                    }

                    break;

                case "down":
                    galaxy[spaceshipRow, spaceshipCol] = '-';
                    if (BoundriesCheck(galaxy, spaceshipRow + 1, spaceshipCol))
                    {
                        spaceshipRow++;

                        if (char.IsDigit(galaxy[spaceshipRow, spaceshipCol]))
                        {
                            var currentStarPower = galaxy[spaceshipRow, spaceshipCol] - '0';
                            starPower += currentStarPower;
                            galaxy[spaceshipRow, spaceshipCol] = 'S';

                        }

                        else if (char.IsLetter(galaxy[spaceshipRow, spaceshipCol]))
                        {
                            galaxy[spaceshipRow, spaceshipCol] = '-';
                            FindNextBlackHole(galaxy);
                        }
                    }
                    else
                    {
                        intoTheVold = true;
                    }
                    break;

                case "right":
                    galaxy[spaceshipRow, spaceshipCol] = '-';
                    if (BoundriesCheck(galaxy, spaceshipRow, spaceshipCol + 1))
                    {
                        spaceshipCol++;

                        if (char.IsDigit(galaxy[spaceshipRow, spaceshipCol]))
                        {
                            var currentStarPower = galaxy[spaceshipRow, spaceshipCol] - '0';
                            starPower += currentStarPower;
                            galaxy[spaceshipRow, spaceshipCol] = 'S';

                        }

                        else if (char.IsLetter(galaxy[spaceshipRow, spaceshipCol]))
                        {
                            galaxy[spaceshipRow, spaceshipCol] = '-';
                            FindNextBlackHole(galaxy);
                        }
                    }
                    else
                    {
                        intoTheVold = true;
                    }
                    break;

                case "left":
                    galaxy[spaceshipRow, spaceshipCol] = '-';
                    if (BoundriesCheck(galaxy, spaceshipRow, spaceshipCol - 1))
                    {
                        spaceshipCol--;

                        if (char.IsDigit(galaxy[spaceshipRow, spaceshipCol]))
                        {
                            var currentStarPower = galaxy[spaceshipRow, spaceshipCol] - '0';
                            starPower += currentStarPower;
                            galaxy[spaceshipRow, spaceshipCol] = 'S';

                        }

                        else if (char.IsLetter(galaxy[spaceshipRow, spaceshipCol]))
                        {
                            galaxy[spaceshipRow, spaceshipCol] = '-';
                            FindNextBlackHole(galaxy);
                        }
                    }
                    else
                    {
                        intoTheVold = true;
                    }
                    break;
            }
        }

        private static void FindNextBlackHole(char[,] galaxy)
        {
            for (int row = 0; row < galaxy.GetLength(0); row++)
            {
                for (int col = 0; col < galaxy.GetLength(0); col++)
                {
                    var current = galaxy[row, col];
                    if (char.IsLetter(galaxy[row, col]))
                    {
                        spaceshipRow = row;
                        spaceshipCol = col;

                        galaxy[spaceshipRow, spaceshipCol] = 'S';

                        break;
                    }
                }
            }
        }

        private static bool BoundriesCheck(char[,] galaxy, int row, int col)
        {
            if (row < 0
                || row >= galaxy.GetLength(0)
                || col < 0
                || col >= galaxy.GetLength(0))
            {
                return false;
            }

            return true;
        }
    }
}
