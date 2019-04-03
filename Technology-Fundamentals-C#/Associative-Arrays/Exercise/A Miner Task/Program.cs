using System;
using System.Collections.Generic;

namespace A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 1;
            var dic = new Dictionary<string, int>();
            string resource = string.Empty;
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "stop")
                {
                    break;
                }

                if (counter % 2 != 0)
                {
                    resource = command;
                    if (!dic.ContainsKey(resource))
                    {
                        dic.Add(resource, 0);
                    }
                }

                else
                {
                    dic[resource] += int.Parse(command);
                }

                counter++;
            }

            foreach (var kvp in dic)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
