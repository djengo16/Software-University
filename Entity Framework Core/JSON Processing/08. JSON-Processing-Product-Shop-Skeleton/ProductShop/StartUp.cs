using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            const string ResultPath = "../../../Datasets/Results";


            string jsonCategories = File.ReadAllText("../../../Datasets/categories.json");
            string jsonProducts = File.ReadAllText("../../../Datasets/products.json");
            string jsonUsers = File.ReadAllText("../../../Datasets/users.json");
            string jsonCategoriesProducts = File.ReadAllText("../../../Datasets/categories-products.json");

            ProductShopContext db = new ProductShopContext();

            if (!Directory.Exists(ResultPath))
            {
                Directory.CreateDirectory(ResultPath);
            }

            string json = GetUsersWithProducts(db);

            File.WriteAllText(String.Concat(ResultPath, "/users-and-products.json"), json);



        }
        public static void ResetDataBase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("DB Deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("DB Created!");
        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            string outputMessage = $"Successfully imported {users.Length}";

            return outputMessage;
        }

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            string outputMessage = $"Successfully imported {products.Length}";

            return outputMessage;
        }

        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            Category[] categories = JsonConvert.DeserializeObject<Category[]>
                (inputJson)
                .Where(c => c.Name != null)
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            string outputMessage = $"Successfully imported {categories.Length}";

            return outputMessage;
        }

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            CategoryProduct[] categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>
                (inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            string outputMessage = $"Successfully imported {categoryProducts.Length}";

            return outputMessage;
        }

        //Export Part
        //Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = String.Concat(p.Seller.FirstName, " ", p.Seller.LastName)
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        //Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var products = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                    .Where(p => p.BuyerId != null)
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                    .ToArray()
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            return json;
        }

        //Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = Math.Round(c.CategoryProducts.Average(p => p.Product.Price), 2).ToString(),
                    totalRevenue = Math.Round(c.CategoryProducts.Sum(p => p.Product.Price), 2).ToString()
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return json;
        }

        //Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var targetUsers = context.Users
                .AsEnumerable()
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(x => x.ProductsSold.Count(c => c.Buyer != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Count(b => b.Buyer != null),
                        products = x.ProductsSold.Where(b => b.Buyer != null).Select(ps => new
                        {
                            name = ps.Name,
                            price = ps.Price
                        }).ToList()
                    }
                })
                .ToList();

            var usersResultObj = new
            {
                usersCount = targetUsers.Count,
                users = targetUsers,
            };

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(usersResultObj, settings);

            return json;
        }
    }
}