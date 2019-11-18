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
                //var suppliers = File.ReadAllText(@".\..\..\..\Datasets\suppliers.json");
                //var customers = File.ReadAllText(@".\..\..\..\Datasets\customers.json");
                //var cars = File.ReadAllText(@".\..\..\..\Datasets\cars.json");
                //var parts = File.ReadAllText(@".\..\..\..\Datasets\parts.json");
                //var sales = File.ReadAllText(@".\..\..\..\Datasets\sales.json");

                //Console.WriteLine(ImportSuppliers(db, suppliers));
                //Console.WriteLine(ImportParts(db, parts));
                //Console.WriteLine(ImportCars(db, cars));
                //Console.WriteLine(ImportCustomers(db, customers));
                //Console.WriteLine(ImportSales(db, sales));

                Console.WriteLine(GetSalesWithAppliedDiscount(db));
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
                .Where(p => context.Suppliers.Any(x => x.Id == p.SupplierId))
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
            var customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                });

            var jsonExport = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return jsonExport;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                });

            var jsonExport = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return jsonExport;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var jsonExport = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return jsonExport;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },

                    parts = c.PartCars.Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = $"{p.Part.Price:F2}"
                    })
                    .ToList()
                })
                .ToList();

            var jsonExport = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return jsonExport;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(a => a.Car.PartCars.Sum(e => e.Part.Price))
                })
                .OrderByDescending(c=>c.spentMoney)
                .ThenByDescending(c=>c.boughtCars);

            var jsonExport = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return jsonExport;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },

                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    price = $"{s.Car.PartCars.Sum(c => c.Part.Price)}",
                    priceWithDiscount = $"{s.Car.PartCars.Sum(c => c.Part.Price) * (1 - s.Discount/100):F2}"
                })
                .Take(10);

            var jsonExport = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return jsonExport;
        }
    }
}