using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                else if (command == "Paid")
                {
                    int currentCount = names.Count;
                    for (int i = 0; i < currentCount; i++)
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                }

                else
                {
                    names.Enqueue(command);

                }
            }

            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
