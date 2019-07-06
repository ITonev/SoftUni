using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double defaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public virtual double FuelConsumption => defaultFuelConsumption;

        public virtual void Drive(double kilometers)
        {
            var fuelNeeded = this.FuelConsumption * kilometers;

            if (this.Fuel - fuelNeeded >= 0)
            {
                this.Fuel -= fuelNeeded;
            }

        }
    }
}
