using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += 1.6;
        }

        public override string Drive(double distance)
        {
            double fuelNeeded = distance * FuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                return $"{nameof(Truck)} needs refueling";
            }

            else
            {
                this.FuelQuantity -= fuelNeeded;
                return $"{nameof(Truck)} travelled {distance} km";
            }
        }

        public override void Refuel(double fuelQuantity)
        {
            if (fuelQuantity <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.TankCapacity < this.FuelQuantity + (fuelQuantity * 0.95))
            {
                Console.WriteLine($"Cannot fit {fuelQuantity} fuel in the tank");
            }

            else
            {
                this.FuelQuantity += (fuelQuantity * 0.95);
            }
        }
    }
}
