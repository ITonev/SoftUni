using System;
using System.Collections.Generic;

namespace Auto_Repair_and_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> vehicles = new Queue<string>
                (Console.ReadLine()
                .Split());

            Stack<string> servicedVechicles = new Stack<string>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                else if (command.StartsWith("Service") && vehicles.Count > 0)
                {
                    var vehicleToServe = vehicles.Dequeue();
                    Console.WriteLine($"Vehicle {vehicleToServe} got served.");
                    servicedVechicles.Push(vehicleToServe);
                }

                else if (command.StartsWith("CarInfo"))
                {
                    var tokens = command.Split("-");
                    var car = tokens[1];

                    if (vehicles.Contains(car))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }

                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }

                else if (command.StartsWith("History"))
                {
                    Console.WriteLine(string.Join(", ", servicedVechicles));
                }
            }

            if (vehicles.Count > 0)
            {
                Console.Write("Vehicles for service: ");
                Console.WriteLine(string.Join(", ", vehicles));
            }

            Console.Write("Served vehicles: ");
            Console.WriteLine(string.Join(", ", servicedVechicles));
        }
    }
}
