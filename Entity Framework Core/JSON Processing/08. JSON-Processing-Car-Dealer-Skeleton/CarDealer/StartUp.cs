using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO.CarDTO;
using CarDealer.DTO.CustomerDTO;
using CarDealer.DTO.SupplierDTO;
using CarDealer.Models;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        const string ResultPath = "../../../Datasets/Results";
        public static readonly IMapper mapper;
        public static void Main(string[] args)
        {
           // string json = File.ReadAllText("../../../Datasets/sales.json");

            CarDealerContext db = new CarDealerContext();
            // ResetDataBase(db);

            InitializeMapper();

            if (!Directory.Exists(ResultPath))
            {
                Directory.CreateDirectory(ResultPath);
            }

            string json = GetSalesWithAppliedDiscount(db);

            File.WriteAllText(String.Concat(ResultPath, "/sales-discounts.json"), json);


        }
        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }
            );
        }

        //IMPORT
        private static void ResetDataBase(CarDealerContext carDealerContext)
        {
            carDealerContext.Database.EnsureDeleted();
            Console.WriteLine("Database deleted!");

            carDealerContext.Database.EnsureCreated();
            Console.WriteLine("Database created!");
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            Supplier[] suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            int[] suppliersId = context.Suppliers.Select(s => s.Id).ToArray();

            Part[] parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => suppliersId.Contains(p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";

        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            ImportCarDTO[] importedCars = JsonConvert.DeserializeObject<ImportCarDTO[]>(inputJson);

            List<Car> cars = new List<Car>();
            List<PartCar> partCars = new List<PartCar>();

            foreach (var importedCar in importedCars)
            {
                var car = new Car
                {
                    Make = importedCar.Make,
                    Model = importedCar.Model,
                    TravelledDistance = importedCar.TravelledDistance
                };

                foreach (var part in importedCar.PartsId.Distinct())
                {
                    var partCar = new PartCar
                    {
                        PartId = part,
                        Car = car
                    };
                    partCars.Add(partCar);
                }
                cars.Add(car);
            }
            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);

            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            Customer[] customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            Sale[] sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        //EXPORT

        // Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ProjectTo<OrderedCustomerDTO>()
                .ToList();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        //Export Cars from Make Toyota

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        //Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .ProjectTo<LocalSupplierDTO>()
                .ToList();

            string json = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);

            return json;
        }

        //Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
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
                        Price = p.Part.Price.ToString("f2")
                    })
                    .ToArray()
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        //Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any(s => s.Car != null))
                .ProjectTo<TotalSalesByCustomerDTO>()
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.SalesCount)
                .ToList();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        //
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount,
                    price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("f2"),
                    priceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) * (1M - s.Discount / 100M)).ToString("f2")
                })
                .ToList();

            string json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }
    }
}