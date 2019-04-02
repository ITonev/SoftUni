using System;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            var wagons = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToList();
            Console.WriteLine(wagons[23]);
            int capacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "end")
            {
                var tokens = command.Split();
                if (tokens[0]=="Add")
                {
                    wagons.Add(int.Parse(tokens[1]));
                }

                else
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + int.Parse(tokens[0]) <= capacity)
                        {
                            wagons[i] += int.Parse(tokens[0]);
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
