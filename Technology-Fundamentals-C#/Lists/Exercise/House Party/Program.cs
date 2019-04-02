using System;
using System.Collections.Generic;

namespace House_Party
{
    class Program
    {
        static void Main(string[] args)
        {

            int command = int.Parse(Console.ReadLine());

            List<string> names = new List<string>();

            for (int i = 0; i < command; i++)
            {
                var message = Console.ReadLine().Split();
                string currentName = message[0];
                bool isNameExists = IsNameExists(names, currentName);

                if (message.Length==3)
                {
                    if (isNameExists)
                    {
                        Console.WriteLine($"{currentName} is already in the list!");
                        continue;
                    }
                    names.Add(currentName);
                }

                else
                {
                    if (!isNameExists)
                    {
                        Console.WriteLine($"{currentName} is not in the list!");
                        continue;
                    }
                    names.Remove(currentName);
                }
            }

            Console.WriteLine(string.Join(" \n", names));
        }

        private static bool IsNameExists(List<string> names, string name)
        {
            return names.Contains(name);
        }
    }
}
