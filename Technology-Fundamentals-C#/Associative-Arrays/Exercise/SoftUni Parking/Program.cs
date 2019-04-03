using System;
using System.Collections.Generic;

namespace SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var parking = new Dictionary<string, string>();

            for (int i = 0; i < num; i++)
            {
                var command = Console.ReadLine().Split();

                if (command[0]=="register")
                {
                    if (parking.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {command[2]}");
                    }

                    else
                    {
                        parking.Add(command[1], command[2]);
                        Console.WriteLine($"{command[1]} registered {command[2]} successfully");
                    }
                }

                else if (command[0]=="unregister")
                {
                    if (!parking.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"ERROR: user {command[1]} not found");
                    }

                    else
                    {
                        Console.WriteLine($"{command[1]} unregistered successfully");
                        parking.Remove(command[1]);
                    }
                }
            }

            foreach (var kvp in parking)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
