using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> products = 
                new Dictionary<string, Dictionary<string, double>>();

            string input = string.Empty;
            while ((input = Console.ReadLine())!= "Revision")
            {
                string[] data = input.Split(", ").ToArray();
                string shop = data[0];
                string product = data[1];
                double price = double.Parse(data[2]);

                if (!products.ContainsKey(shop))
                {
                    products.Add(shop, new Dictionary<string, double>());
                }
                products[shop].Add(product, price);
            }
            products = products.OrderBy(x => x.Key).ToDictionary(x=>x.Key,x=>x.Value);
            foreach (var current in products)
            {
                Console.WriteLine($"{current.Key}->");
                foreach (var product in current.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
