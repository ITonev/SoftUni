using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Catalogue
{
    class Program
    {
        class Truck
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public string Weight { get; set; }
        }
        class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public string HorsePower { get; set; }
        }
        class Catalog
        {
            public List<Truck> Trucks { get; set; }
            public List<Car> Cars { get; set; }

            public Catalog()
            {
                this.Cars = new List<Car>();
                this.Trucks = new List<Truck>();
            }
        }

        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Catalog currentCatalog = new Catalog();

            while (command != "end")
            {
                var tokens = command.Split("/", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0].ToLower() == "car")
                {
                    Car newCar = new Car();
                    newCar.Brand = tokens[1];
                    newCar.Model = tokens[2];
                    newCar.HorsePower = tokens[3];
                    currentCatalog.Cars.Add(newCar);
                }

                else if (tokens[0].ToLower() == "truck")
                {
                    Truck newTruck = new Truck
                    {
                        Brand = tokens[1],
                        Model = tokens[2],
                        Weight = tokens[3]
                    };

                    currentCatalog.Trucks.Add(newTruck);
                    
                }


                command = Console.ReadLine();
            }

            var carsCatalog = currentCatalog.Cars.ToList();
            var trucksCatalog = currentCatalog.Trucks.ToList();

            Console.WriteLine("Cars:");
            foreach (var car in carsCatalog.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            Console.WriteLine("Trucks:");
            foreach (var truck in trucksCatalog.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }

        }
    }
}
