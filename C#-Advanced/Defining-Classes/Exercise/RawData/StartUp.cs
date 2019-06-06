using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();


            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                Engine engine = new Engine(int.Parse(input[1]), int.Parse(input[2]));

                Cargo cargo = new Cargo(int.Parse(input[3]), input[4]);

                Tire[] tires = new Tire[4]
                {
                new Tire(double.Parse(input[5]), int.Parse(input[6])),
                new Tire(double.Parse(input[7]), int.Parse(input[8])),
                new Tire(double.Parse(input[9]), int.Parse(input[10])),
                new Tire(double.Parse(input[11]), int.Parse(input[12])),
                };

                Car car = new Car(input[0], engine, cargo, tires);

                cars.Add(car);
            }

            var command = Console.ReadLine();

            var filteredCarList = command == "fragile" ?
                  cars.Where(x => x.Cargo.Type == command && x.Tires.Any(y => y.Pressure < 1))
                : cars.Where(x => x.Cargo.Type == command && x.Engine.Power > 250);

            foreach (var car in filteredCarList)
            {
                Console.WriteLine(car.Model);
            }

        }
    }
}
