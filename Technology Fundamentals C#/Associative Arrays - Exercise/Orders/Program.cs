using System;
using System.Linq;
using System.Collections.Generic;
namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();

            string order = string.Empty;

            while ((order=Console.ReadLine()) != "buy")
            {
                string[] product = order.Split().ToArray();

                string productName = product[0];
                double productPrice = double.Parse(product[1]);
                double productQuantity = double.Parse(product[2]);

                if (products.ContainsKey(productName))
                {
                    products[productName][0] = productPrice;
                    products[productName][1] += productQuantity;
                }
                else
                {
                    products.Add(productName, new List<double>());
                    products[productName].Add(productPrice);
                    products[productName].Add(productQuantity);
                }
            }
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key} -> {item.Value[0] * item.Value[1]:F2}");
            }
        }
    }
}
