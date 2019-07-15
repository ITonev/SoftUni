using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelConsumption = fuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }

                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            set
            {
                this.fuelConsumption = value;
            }
        }

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            set
            {
                this.tankCapacity = value;
            }

        }

        public abstract string Drive(double distance);

        public virtual void Refuel(double fuelQuantity)
        {
            if (fuelQuantity <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.TankCapacity < this.FuelQuantity + fuelQuantity)
            {
                Console.WriteLine($"Cannot fit {fuelQuantity} fuel in the tank");
            }

            else
            {
                this.FuelQuantity += fuelQuantity;
            }
        }
    }
}
