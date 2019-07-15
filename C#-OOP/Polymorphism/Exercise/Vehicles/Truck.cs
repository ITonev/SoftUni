using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
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

            this.FuelQuantity -= fuelNeeded;
            return $"{nameof(Truck)} travelled {distance} km";
        }

        public override void Refuel(double fuelQuantity)
        {
            this.FuelQuantity += (fuelQuantity*0.95);
        }
    }
}
