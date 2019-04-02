using System;
using System.Linq;

namespace Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToList();

            var bombs = Console.ReadLine().Split();
            int specialNum = int.Parse(bombs[0]);
            int power = int.Parse(bombs[1]);
            int originalCount = numbers.Count;

            for (int i = 0; i < numbers.Count; i++)
            {
                int bombingFrom = i - power;
                int bombingTo = i + power;

                if (numbers[i] == specialNum)
                {
                    if (bombingTo >= numbers.Count)
                    {
                        bombingTo = numbers.Count;
                    }
                    if (bombingFrom < 0)
                    {
                        bombingFrom = 0;
                    }

                    numbers.RemoveRange(bombingFrom, bombingTo-bombingFrom+1);
                    i = 0;
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
