using System;
using System.Collections.Generic;

namespace Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            List<string> boughtGames = new List<string>();
            Dictionary<string, double> availableGames = new Dictionary<string, double>()
            {
                ["OutFall 4"] = 39.99,
                ["CS: OG"] = 15.99,
                ["Zplinter Zell"] = 19.99,
                ["Honored 2"] = 59.99,
                ["RoverWatch"] = 29.99,
                ["RoverWatch Origins Edition"] = 39.99,
            };

            double totalSpent = 0.0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Game Time")
                {
                    break;
                }

                if (!availableGames.ContainsKey(command))
                {
                    Console.WriteLine("Not Found");
                }

                else
                {
                    if (balance < availableGames[command])
                    {
                        Console.WriteLine("Too Expensive");
                    }

                    else
                    {
                        balance -= availableGames[command];
                        boughtGames.Add(command);
                        totalSpent += availableGames[command];
                        Console.WriteLine($"Bought {command}");
                    }
                }

                if (balance==0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
            }

            if (balance>0)
            {
                //Console.WriteLine(string.Join(Environment.NewLine, boughtGames));
                Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${balance:f2}");
            }
        }
    }
}
