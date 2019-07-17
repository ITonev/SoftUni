using System;

namespace Vehicles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split();
            var truckInfo = Console.ReadLine().Split();
            var busInfo = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));



            var commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                var tokens = Console.ReadLine().Split();

                var command = tokens[0];
                var vehicle = tokens[1];

                if (command.StartsWith("Drive"))
                {
                    double distance = double.Parse(tokens[2]);

                    switch (vehicle)
                    {
                        case "Car":
                            Console.WriteLine(car.Drive(distance));
                            break;

                        case "Truck":
                            Console.WriteLine(truck.Drive(distance));
                            break;

                        case "Bus":
                            var someBus = bus as Bus;

                            Console.WriteLine(command == "Drive" ? someBus.Drive(distance) : someBus.DriveEmpty(distance));
                            break;
                    }
                }

                else if (command == "Refuel")
                {
                    try
                    {
                        double fuel = double.Parse(tokens[2]);

                        switch (vehicle)
                        {
                            case "Car":
                                car.Refuel(fuel);
                                break;

                            case "Truck":
                                truck.Refuel(fuel);
                                break;

                            case "Bus":
                                bus.Refuel(fuel);
                                break;
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine($"{nameof(Car)}: {car.FuelQuantity:f2}");
            Console.WriteLine($"{nameof(Truck)}: {truck.FuelQuantity:f2}");
            Console.WriteLine($"{nameof(Bus)}: {bus.FuelQuantity:f2}");
        }
    }
}
