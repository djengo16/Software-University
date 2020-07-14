using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Seeding
{
    public static class ProductSeeder : ISeeder
    {
        Random rnd = new Random();
        public ProductSeeder(SalesContext context)
        {
            this.Context = context;   
        }

        public SalesContext Context { get; set; }

        public void Seed(SalesContext db)
        {
            string[] productNames = new string[]
            {
                "T-shirt",
                "Tracksuit",
                "Denim Jeans",
                "Jeans",
                "Slim-fit pants",
                "Jacket",
                "Sport shoes",
                "Casual Shoes",
                "Sandals"
            };
            ICollection<Product> products = new List<Product>();

            for (int i = 0; i < 30; i++)
            {
                int nameIndex = rnd.Next(0, productNames.Length);
                string currentName = productNames[nameIndex];

                double quantity = rnd.Next(10, 200) * 1.12;

                decimal price = rnd.Next(10, 300) * 1.23m;

                Product product = new Product
                {
                    Name = currentName,
                    Quantity = quantity,
                    Price = price
                };
            }
            this.Context.AddRange(products);
            this.Context.SaveChanges();
        }
    }
}
