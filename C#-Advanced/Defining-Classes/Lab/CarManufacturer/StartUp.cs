using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();
            List<Tire[]> tires = new List<Tire[]>();

            var tireInfo = Console.ReadLine();

            while (tireInfo != "No more tires")
            {
                var currentTyre = tireInfo
                    .Split();

                Tire[] currentSet = new Tire[4]
                {
                    new Tire(int.Parse(currentTyre[0]),double.Parse(currentTyre[1])),
                    new Tire(int.Parse(currentTyre[2]),double.Parse(currentTyre[3])),
                    new Tire(int.Parse(currentTyre[4]),double.Parse(currentTyre[5])),
                    new Tire(int.Parse(currentTyre[6]),double.Parse(currentTyre[7])),
                };

                tires.Add(currentSet);

                tireInfo = Console.ReadLine();
            }

            var engineInfo = Console.ReadLine();

            while (engineInfo != "Engines done")
            {
                var currentEngine = engineInfo.Split();
                Engine engine = new Engine(int.Parse(currentEngine[0]), double.Parse(currentEngine[1]));
                engines.Add(engine);

                engineInfo = Console.ReadLine();
            }

            var carInfo = Console.ReadLine();

            while (carInfo != "Show special")
            {
                var currentCar = carInfo.Split();
                string make = currentCar[0];
                string model = currentCar[1];
                int year = int.Parse(currentCar[2]);
                double fuelQuantity = double.Parse(currentCar[3]);
                double fuelConsumption = double.Parse(currentCar[4]);
                int engineIndex = int.Parse(currentCar[5]);
                int tiresIndex = int.Parse(currentCar[6]);


                Car car = new Car(
                    make,
                    model,
                    year,
                    fuelQuantity,
                    fuelConsumption,
                    engines.ElementAt(engineIndex),
                    tires.ElementAt(tiresIndex));

                cars.Add(car);

                carInfo = Console.ReadLine();
            }

            var filteredCarList = cars
                .Where(x => x.Year == 2017)
                .Where(x => x.Engine.HorsePower >= 330)
                .Where(x => x.Tires.Select(y => y.Pressure).Sum() >= 9)
                .Where(x => x.Tires.Select(y => y.Pressure).Sum() <= 10)
                .ToList();

            foreach (var car in filteredCarList)
            {
                car.Drive(20);

                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
