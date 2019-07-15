using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            double fuelNeeded = distance * (this.FuelConsumption + 1.4);

            if (this.FuelQuantity < fuelNeeded)
            {
                return $"{nameof(Bus)} needs refueling";
            }

            else
            {
                this.FuelQuantity -= fuelNeeded;
                return $"{nameof(Bus)} travelled {distance} km";
            }
        }

        public string DriveEmpty(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                return $"{nameof(Bus)} needs refueling";
            }

            else
            {
                this.FuelQuantity -= fuelNeeded;
                return $"{nameof(Bus)} travelled {distance} km";
            }
        }
    }
}
