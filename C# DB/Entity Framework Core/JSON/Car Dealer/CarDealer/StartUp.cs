using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new CarDealerContext())
            {
                var suppliers = File.ReadAllText(@".\..\..\..\Datasets\suppliers.json");

                var customers = File.ReadAllText(@".\..\..\..\Datasets\customers.json");

                var cars = File.ReadAllText(@".\..\..\..\Datasets\cars.json");

                var parts = File.ReadAllText(@".\..\..\..\Datasets\parts.json");

                var sales = File.ReadAllText(@".\..\..\..\Datasets\sales.json");

                //Console.WriteLine(ImportSuppliers(db, suppliers));
                //Console.WriteLine(ImportParts(db, parts));
                //Console.WriteLine(ImportCars(db, cars));
                //Console.WriteLine(ImportCustomers(db, customers));
                //Console.WriteLine(ImportSales(db, sales));

                

            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var converted = JsonConvert
                    .DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(converted);
            context.SaveChanges();

            return $"Successfully imported {converted.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert
                .DeserializeObject<Part[]>(inputJson)
                .Where(p=> context.Suppliers.Any(x=>x.Id==p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<ImortCarDto[]>(inputJson);

            foreach (var carDto in json)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                context.Cars.Add(car);

                foreach (var partId in carDto.PartsId)
                {
                    PartCar partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    if (car.PartCars.FirstOrDefault(p => p.PartId == partId) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();

            return $"Successfully imported {json.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<Customer[]>(inputJson);
            context.Customers.AddRange(json);
            int count = context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<Sale[]>(inputJson);
            context.Sales.AddRange(json);
            int count = context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            return "";
        }
    }
}