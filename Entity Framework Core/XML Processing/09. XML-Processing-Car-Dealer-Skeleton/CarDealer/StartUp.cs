using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.DTO.Importt;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        });




        public static Mapper mapper = new Mapper(config);
        public static void Main(string[] args)
        {
            var xmlFile = File.ReadAllText("../../../Datasets/parts.xml");
            var xmlSuppliersFile = File.ReadAllText("../../../Datasets/suppliers.xml");
            var xmlCarsFile = File.ReadAllText("../../../Datasets/cars.xml");
            var xmlCustomersFile = File.ReadAllText("../../../Datasets/customers.xml");
            var xmlSalesFile = File.ReadAllText("../../../Datasets/sales.xml");

            CarDealerContext context = new CarDealerContext();


            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        private static void ResetDb(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("DB Deleted!");

            context.Database.EnsureCreated();
            Console.WriteLine("DB Created!");
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var attr = new XmlRootAttribute("Suppliers");
            var serializer = new XmlSerializer(typeof(ImportSupplierDTO[]), attr);

            var deserializedSuppliers = (ImportSupplierDTO[])serializer.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();

            foreach (var supplierDTO in deserializedSuppliers)
            {
                var supplier = mapper.Map<Supplier>(supplierDTO);

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var attr = new XmlRootAttribute("Parts");
            var serializer = new XmlSerializer(typeof(ImportPartDTO[]), attr);

            var deserializedParts = (ImportPartDTO[])serializer.Deserialize(new StringReader(inputXml));

            int[] realSupplierIds = context.Suppliers.Select(s => s.Id).ToArray();

            var parts = deserializedParts
                 .Where(x => realSupplierIds.Contains(x.SupplierId))
                 .Select(x => new Part
                 {
                     Name = x.Name,
                     Price = x.Price,
                     Quantity = x.Quantity,
                     SupplierId = x.SupplierId
                 })
                 .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var attr = new XmlRootAttribute("Cars");
            var serializer = new XmlSerializer(typeof(ImportCarDTO[]), attr);

            var deserializedCars = (ImportCarDTO[])serializer.Deserialize(new StringReader(inputXml));

            int[] realPartIds = context.Parts.Select(p => p.Id).ToArray();

            var cars = new List<Car>();

            foreach (var carDTO in deserializedCars)
            {
                var car = new Car();

                car.Make = carDTO.Make;
                car.Model = carDTO.Model;
                car.TravelledDistance = carDTO.TraveledDistance;

                int[] partsIds = carDTO.Parts.Select(p => p.PartId).ToArray();

                foreach (var partId in partsIds.Distinct())
                {
                    if (realPartIds.Contains(partId))
                    {
                        PartCar partCar = new PartCar();
                        partCar.PartId = partId;
                        partCar.Car = car;

                        car.PartCars.Add(partCar);
                    }
                }
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";

        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var attr = new XmlRootAttribute("Customers");
            var serializer = new XmlSerializer(typeof(ImportCustomerDTO[]), attr);



            var deserializedCustomers = (ImportCustomerDTO[])serializer.Deserialize(new StringReader(inputXml));

            var customers = deserializedCustomers
                .Select(x => new Customer
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var attr = new XmlRootAttribute("Sales");
            var serializer = new XmlSerializer(typeof(ImportSaleDTO[]), attr);



            var deserializedCustomers = (ImportSaleDTO[])serializer.Deserialize(new StringReader(inputXml));

            var sales = deserializedCustomers
                .Where(x => context.Cars.Any(c => c.Id == x.CarId))
                .Select(x => new Sale
                {
                    CustomerId = x.CustomerId,
                    CarId = x.CarId,
                    Discount = x.Discount
                })
                .ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }


        //EXPORT
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            var attr = new XmlRootAttribute("cars");

            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => new CarWithDistanceDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .Take(10)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CarWithDistanceDTO[]), attr);


            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
                {
                new XmlQualifiedName("","")
            });

            serializer.Serialize(new StringWriter(sb), cars, namespaces);


            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new CarFromMakeBmwDTO
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

           

            var serializer = new XmlSerializer(typeof(CarFromMakeBmwDTO[]), new XmlRootAttribute("cars"));


            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            serializer.Serialize(new StringWriter(sb), cars, namespaces);


            return sb.ToString().TrimEnd();

        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .ProjectTo<LocalSupplierDTO>(config)
                .ToArray();

            var serializer = new XmlSerializer(typeof(LocalSupplierDTO[]), new XmlRootAttribute("suppliers"));


            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            serializer.Serialize(new StringWriter(sb), suppliers, namespaces);


            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var cars = context.Cars
                .Select(x => new CarWithPartsDTO
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(pc => new ExportPartDTO
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(pc => pc.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CarWithPartsDTO[]), new XmlRootAttribute("cars"));


            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var customers = context.Customers
                .Where(x => x.Sales.Any(s => s.Car != null))
                .ProjectTo<CustomerWithSalesDTO>(config)
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CustomerWithSalesDTO[]), new XmlRootAttribute("customers"));


            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            serializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var sales = context.Sales
                .Select(x => new SaleWithDiscountDTO
                {
                    Car = new CarDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(x => x.Part.Price),
                    PriceWithDiscount = x.Car.PartCars.Sum(x => x.Part.Price) -
                                             x.Car.PartCars.Sum(x => x.Part.Price) * x.Discount / 100
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(SaleWithDiscountDTO[]), new XmlRootAttribute("sales"));


            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            serializer.Serialize(new StringWriter(sb), sales, namespaces);



            return sb.ToString().TrimEnd();
        }


    }
}