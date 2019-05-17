using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int passedCarsCount = 0;

            bool carWasHit = false;            

            var command = Console.ReadLine();

            while (command != "END")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                }

                else
                {
                    int greenLightDuration = greenLight;

                    while (cars.Count>0 && greenLightDuration>0)
                    {
                        var carLenght = cars.Peek().Length;

                        if (carLenght <= greenLightDuration)
                        {
                            cars.Dequeue();
                            greenLightDuration -= carLenght;
                            passedCarsCount++;
                        }

                        else if (carLenght > greenLightDuration && greenLightDuration > 0)
                        {                           
                            int freeWindowDuration = freeWindow;

                            if (carLenght > greenLightDuration + freeWindowDuration)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{cars.Peek()} was hit at {cars.Peek()[greenLightDuration + freeWindowDuration]}.");

                                carWasHit = true;
                            }

                            else
                            {
                                cars.Dequeue();
                                passedCarsCount++;
                            }

                            greenLightDuration = 0;
                        }

                    }
                }

                if (carWasHit)
                {
                    break;
                }
                command = Console.ReadLine();
            }

            if (!carWasHit)
            {
                Console.WriteLine($"Everyone is safe.");
                Console.WriteLine($"{passedCarsCount} total cars passed the crossroads.");
            }
        }
    }
}
