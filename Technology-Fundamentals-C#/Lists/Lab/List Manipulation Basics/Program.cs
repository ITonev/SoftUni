using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Manipulation_Basics
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

                string[] commandArray = command.Split();
                int currentIndex = int.Parse(commandArray[1]);

                switch (commandArray[0])
                {
                    case "Add":
                        integerList.Add(currentIndex);
                        break;
                    case "RemoveAt":
                        integerList.RemoveAt(currentIndex);
                        break;
                    case "Remove":
                        integerList.Remove(currentIndex);
                        break;
                    case "Insert":
                        int next = int.Parse(commandArray[2]);
                        integerList.Insert(next, currentIndex);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", integerList));
        }
    }
}
