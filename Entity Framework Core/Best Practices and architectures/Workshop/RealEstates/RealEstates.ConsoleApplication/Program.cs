using RealEstates.Data;
using RealEstates.Services;
using System;
using System.Text;
using System.Text.Unicode;

namespace RealEstates.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new RealEstateDbContext();
            Console.OutputEncoding = Encoding.UTF8;




            IDistrictsService districtService = new DistrictsService(db);
            var districts = districtService.GetTopDistrictsByAveragePrice(100);

            foreach (var district in districts)
            {
                Console.WriteLine("<<<<<<<<~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~>>>>>>>>");
                Console.WriteLine($"Name: {district.Name} || AVG Price: " +
                    $"{district.AveragePrice} || \n (Min price => {district.MinPrice} - Max price =>{district.MaxPrice}) " +
                    $"|| {district.PropertiesCount} - Properties");

            }


            //IPropertiesService propertiesService = new PropertiesService(db);

            //int minPrice;
            //int maxPrice;

            //Console.Write("Insert Min price: ");
            //minPrice = int.Parse(Console.ReadLine());

            //Console.Write("Insert Max price: ");
            //maxPrice = int.Parse(Console.ReadLine());

            //var properties = propertiesService.SearchByPrice(minPrice, maxPrice);

            //foreach (var property in properties)
            //{
            //    Console.WriteLine("<<<<<<<<~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~$~>>>>>>>>");
            //    Console.WriteLine($"{property.District}," +
            //        $" fl. {property.Floor}, {property.Size} m²," +
            //        $" {property.Year}, {property.Price}€, " +
            //        $"{property.PropertyType}, {property.BuildingType}");
            //}

        }
    }
}
