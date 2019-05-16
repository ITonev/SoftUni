using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            Queue<int> queue = new Queue<int>
                (Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                var currentOrder = queue.Peek();

                if (foodQuantity >= currentOrder)
                {
                    foodQuantity -= queue.Dequeue();
                }

                else if (foodQuantity < currentOrder)
                {
                    break;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }

            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
