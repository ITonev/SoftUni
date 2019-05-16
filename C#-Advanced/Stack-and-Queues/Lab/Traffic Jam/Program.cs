using System;
using System.Collections.Generic;

namespace Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int counter = 0;

            while (true)
            {
                var command = Console.ReadLine();

                if (command=="end")
                {
                    break;
                }

                else if (command=="green")
                {
                    var carsToPass = cars.Count < numberOfCars ? cars.Count : numberOfCars;

                    for (int i = 0; i < carsToPass; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        counter++;
                    }
                }

                else
                {
                    cars.Enqueue(command);
                }
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
