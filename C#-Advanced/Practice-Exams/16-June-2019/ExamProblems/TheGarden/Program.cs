using System;
using System.Linq;

namespace TheGarden
{
    class Program
    {
        public static int carrots;
        public static int potatoes;
        public static int lettuces;
        public static int harmedVegetables;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string[][] garden = new string[rows][];


            for (int row = 0; row < rows; row++)
            {
                garden[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            var input = Console.ReadLine();

            while (input != "End of Harvest")
            {
                var tokens = input.Split();
                var command = tokens[0];
                var row = int.Parse(tokens[1]);
                var col = int.Parse(tokens[2]);

                if (BoundaryCheck(garden, row, col))
                {
                    if (command == "Harvest" && CheckIfEmpty(garden, row, col))
                    {
                        var vegetable = garden[row][col];
                        garden[row][col] = string.Empty;

                        switch (vegetable)
                        {
                            case "L":
                                lettuces++;
                                break;
                            case "C":
                                carrots++;
                                break;
                            case "P":
                                potatoes++;
                                break;
                        }
                    }

                    if (command == "Mole")
                    {
                        var direction = tokens[3];

                        Harm(garden, row, col, direction);
                    }
                }

                input = Console.ReadLine();
            }

            for (int row = 0; row < garden.Length; row++)
            {
                Console.WriteLine(string.Join(" ", garden[row]));
            }

            Console.WriteLine($"Carrots: {carrots}");
            Console.WriteLine($"Potatoes: {potatoes}");
            Console.WriteLine($"Lettuce: {lettuces}");
            Console.WriteLine($"Harmed vegetables: {harmedVegetables}");
        }

        private static void Harm(string[][] garden, int row, int col, string direction)
        {

            switch (direction)
            {
                case "up":

                    while (row >= 0)
                    {
                        if (CheckIfEmpty(garden, row, col) && BoundaryCheck(garden, row, col))
                        {
                            garden[row][col] = " ";
                            harmedVegetables++;

                        }

                        row = row - 2;
                    }

                    break;

                case "down":

                    while (row < garden.Length)
                    {
                        if (CheckIfEmpty(garden, row, col) && BoundaryCheck(garden, row, col))
                        {
                            garden[row][col] = " ";
                            harmedVegetables++;
                        }

                        row = row + 2;
                    }

                    break;

                case "left":

                    while (col >= 0)
                    {
                        if (CheckIfEmpty(garden, row, col) && BoundaryCheck(garden, row, col))
                        {
                            garden[row][col] = " ";
                            harmedVegetables++;
                        }

                        col = col - 2;
                    }

                    break;

                case "right":

                    while (col < garden[row].Length)
                    {
                        if (CheckIfEmpty(garden, row, col) && BoundaryCheck(garden, row, col))
                        {
                            garden[row][col] = " ";
                            harmedVegetables++;
                        }

                        col = col + 2;
                    }

                    break;
            }
        }

        private static bool CheckIfEmpty(string[][] garden, int row, int col)
        {
            if (garden[row][col] != string.Empty)
            {
                return true;
            }

            return false;
        }

        private static bool BoundaryCheck(string[][] garden, int row, int col)
        {
            if (row < garden.Length
                && row >= 0
                && col < garden[row].Length
                && col >= 0)
            {
                return true;
            }

            return false;
        }
    }
}