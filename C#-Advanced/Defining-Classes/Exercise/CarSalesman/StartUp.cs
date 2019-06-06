using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = input[0];
                var power = int.Parse(input[1]);
                var displacement = "n/a";
                var efficiency = "n/a";

                if (input.Length == 3)
                {
                    if (char.IsLetter(input[2][0]))
                    {
                        efficiency = input[2];
                    }

                    else
                    {
                        displacement = input[2];
                    }
                }

                if (input.Length == 4)
                {
                    displacement = input[2];
                    efficiency = input[3];
                }

                Engine engine = new Engine(model, power, displacement, efficiency);

                engines.Add(engine);
            }

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var carModel = input[0];
                var engineModel = input[1];
                var weight = "n/a";
                var color = "n/a";

                if (input.Length == 3)
                {
                    if (char.IsLetter(input[2][0]))
                    {
                        color = input[2];
                    }

                    else
                    {
                        weight = input[2];
                    }
                }

                if (input.Length == 4)
                {
                    weight = input[2];
                    color = input[3];
                }

                var currentEngine = engines.FirstOrDefault(x => x.Model == engineModel);

                Car car = new Car(carModel, weight, color, currentEngine);

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

        }
    }
}
