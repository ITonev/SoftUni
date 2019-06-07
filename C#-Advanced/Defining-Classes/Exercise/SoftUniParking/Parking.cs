﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public int Count = 0;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }

        public string AddCar(Car car)
        {
            if (this.cars.Contains(car))
            {
                return $"Car with that registration number, already exists!";
            }

            else if (this.capacity<=this.cars.Count)
            {
                return "Parking is full!";
            }

            this.cars.Add(car);

            Count++;

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!this.cars.Any(x=>x.RegistrationNumber==registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            this.cars.Remove(this.cars.First(x=>x.RegistrationNumber==registrationNumber));

            Count--;

            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return this.cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNumber in registrationNumbers)
            {
                this.cars.RemoveAll(x => x.RegistrationNumber == regNumber);

                Count--;
            }
        }
    }
}
