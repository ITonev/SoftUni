using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integerList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] tokens = command.Split();


                if (tokens[0] == "Contains")
                {
                    int currentCheckUp = int.Parse(tokens[1]);
                    if (integerList.Contains(currentCheckUp))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }

                else if (tokens[0] == "Add") integerList.Add(int.Parse(tokens[1]));
                else if (tokens[0] == "RemoveAt") integerList.RemoveAt(int.Parse(tokens[1]));
                else if (tokens[0] == "Remove") integerList.Remove(int.Parse(tokens[1]));
                else if (tokens[0] == "Insert") integerList.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));

                else if (tokens[0] == "PrintEven")
                {
                    Console.WriteLine(string.Join(" ", integerList.Where(x => x % 2 == 0)));
                }

                else if (tokens[0] == "PrintOdd")
                {
                    Console.WriteLine(string.Join(" ", integerList.Where(x => x % 2 != 0)));
                }

                else if (tokens[0] == "GetSum")
                {
                    Console.WriteLine(integerList.Sum());
                }

                else if (tokens[0] == "Filter")
                {
                    string condition = tokens[1];
                    int number = int.Parse(tokens[2]);

                    switch (condition)
                    {
                        case "<":
                            Console.WriteLine(string.Join(" ", integerList.Where(x => x < number)));
                            break;

                        case ">":
                            Console.WriteLine(string.Join(" ", integerList.Where(x => x > number)));
                            break;

                        case "<=":
                            Console.WriteLine(string.Join(" ", integerList.Where(x => x <= number)));
                            break;

                        case ">=":
                            Console.WriteLine(string.Join(" ", integerList.Where(x => x >= number)));
                            break;
                    }
                }
            }

            
        }
    }
}
