using System;
using System.Linq;

namespace List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "End")
            {
                var tokens = command.Split();
                string operation = tokens[0];

                if (operation == "Add")
                {
                    numbers.Add(int.Parse(tokens[1]));
                }

                else if (operation == "Insert")
                {
                    if (int.Parse(tokens[2]) >= numbers.Count || int.Parse(tokens[2]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
                    }
                }

                else if (operation == "Remove")
                {
                    if (int.Parse(tokens[1]) >= numbers.Count || int.Parse(tokens[1])<0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(int.Parse(tokens[1]));
                    }
                }

                else if (tokens[1] == "left")
                {
                    int shiftCount = int.Parse(tokens[2]);
                    for (int i = 0; i < shiftCount; i++)
                    {
                        int firstNum = numbers[0];
                        for (int j = 0; j < numbers.Count - 1; j++)
                        {
                            numbers[j] = numbers[j + 1];
                        }
                        numbers[numbers.Count - 1] = firstNum;
                    }
                }

                else if (tokens[1] == "right")
                {
                    int shiftCount = int.Parse(tokens[2]);
                    for (int i = 0; i < shiftCount; i++)
                    {
                        int lastNum = numbers[numbers.Count - 1];
                        for (int k = numbers.Count - 1; k > 0; k--)
                        {
                            numbers[k] = numbers[k - 1];
                        }
                        numbers[0] = lastNum;
                    }

                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
