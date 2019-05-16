using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var countToEnqueue = command[0];
            var countsToDequeue = command[1];
            var numberToSearch = command[2];

            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> numbers = new Queue<int>(input);

            for (int i = 0; i < countsToDequeue; i++)
            {
                numbers.Dequeue();
            }

            if (numbers.Contains(numberToSearch))
            {
                Console.WriteLine($"true");
            }

            else if (numbers.Count > 0)
            {
                Console.WriteLine(numbers.Min());
            }

            else
            {
                Console.WriteLine($"0");
            }
        }
    }
}
