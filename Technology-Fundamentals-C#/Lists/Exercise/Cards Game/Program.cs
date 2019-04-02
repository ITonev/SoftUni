using System;
using System.Linq;

namespace Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerOne = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToList();

            var playerTwo = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToList();

            for (int i = 0; i < playerOne.Count; i++)
            {
                if (playerOne.Count == 0 || playerTwo.Count == 0)
                {
                    break;
                }
                else if (playerOne[i] > playerTwo[i])
                {
                    playerOne.Add(playerOne[i]);
                    playerOne.Add(playerTwo[i]);
                    playerOne.RemoveAt(i);
                    playerTwo.RemoveAt(i);
                }

                else if (playerOne[i] < playerTwo[i])
                {
                    playerTwo.Add(playerTwo[i]);
                    playerTwo.Add(playerOne[i]);
                    playerTwo.RemoveAt(i);
                    playerOne.RemoveAt(i);
                }

                else if (playerOne[i] == playerTwo[i])
                {
                    playerTwo.RemoveAt(i);
                    playerOne.RemoveAt(i);
                }

                i = -1;
            }

            if (playerOne.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {playerOne.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {playerTwo.Sum()}");
            }
        }
    }
}
