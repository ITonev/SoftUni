using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();
            Car secondCar = new Car(make, model, year);
            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            var tires = new Tire[4]
            {
                new Tire(2012, 2.5),
                new Tire(2015, 2.9),
                new Tire(2018, 2.2),
                new Tire(2019, 3.2),
            };

            var engine = new Engine(201, 2000);

            Car fourthCar = new Car("Honda", "Civic", 2008, 47, 11, engine, tires);

        }
    }
}
