using System;

namespace Vehicles
{
   public class Program
    {
       public static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split();
            var truckInfo = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            var commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                var tokens = Console.ReadLine().Split();

                var command = tokens[0];
                var vehicle = tokens[1];

                if (command=="Drive")
                {
                    double distance = double.Parse(tokens[2]);

                    if (vehicle=="Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }

                    else if (vehicle=="Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                }

                else if (command=="Refuel")
                {
                    double fuel = double.Parse(tokens[2]);

                    if (vehicle == "Car")
                    {
                        car.Refuel(fuel);
                    }

                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(fuel);
                    }

                }
            }

            Console.WriteLine($"{nameof(Car)}: {car.FuelQuantity:f2}");
            Console.WriteLine($"{nameof(Truck)}: {truck.FuelQuantity:f2}");
        }
    }
}
