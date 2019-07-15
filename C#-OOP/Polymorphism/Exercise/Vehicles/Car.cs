using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += 0.9;
        }

        public override string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                return $"{nameof(Car)} needs refueling";
            }

            this.FuelQuantity -= fuelNeeded;
            return $"{nameof(Car)} travelled {distance} km";
        }

        public override void Refuel(double fuelQuantity)
        {
            this.FuelQuantity += fuelQuantity;
        }
    }
}
