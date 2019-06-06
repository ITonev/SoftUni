using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var currentCar = Console.ReadLine().Split();

                var model = currentCar[0];
                var fuelAmount = double.Parse(currentCar[1]);
                var fuelConsumption = double.Parse(currentCar[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumption));
            }

            var command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                var model = command[1];
                var distance = double.Parse(command[2]);

                var currentCar = cars.Find(x => x.Model == model);
                currentCar.Drive(distance);
                
                command = Console.ReadLine().Split();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
