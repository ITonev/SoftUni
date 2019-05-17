using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>
                (Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            Queue<int> locks = new Queue<int>
                (Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            int intelligenceValue = int.Parse(Console.ReadLine());

            int currentBarrelSize = gunBarrelSize;

            while (locks.Count > 0)
            {
                if (bullets.Count > 0)
                {
                    var bulletSize = bullets.Pop();

                    intelligenceValue -= bulletPrice;

                    currentBarrelSize--;

                    var currentLock = locks.Peek();

                    if (bulletSize <= currentLock)
                    {
                        locks.Dequeue();
                        Console.WriteLine("Bang!");
                    }

                    else
                    {
                        Console.WriteLine("Ping!");
                    }
                }

                else
                {
                    break;
                }

                if (currentBarrelSize == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    currentBarrelSize = gunBarrelSize;
                }
            }

            if (bullets.Count >= 0 && locks.Count==0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue}");
            }

            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
