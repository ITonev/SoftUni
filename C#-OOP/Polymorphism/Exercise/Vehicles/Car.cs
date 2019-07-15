using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
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

            else
            {
                this.FuelQuantity -= fuelNeeded;
                return $"{nameof(Car)} travelled {distance} km";
            }
        }
    }
}
