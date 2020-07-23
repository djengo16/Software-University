using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore.Internal;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {

        public static MapperConfiguration config = new MapperConfiguration(cfg =>
        {

            cfg.AddProfile<ProductShopProfile>();
        });

        public static Mapper mapper = new Mapper(config);

        public static void Main(string[] args)
        {
            ProductShopContext productContext = new ProductShopContext();
            // var userXml = File.ReadAllText("../../../Datasets/categories-products.xml");


            Console.WriteLine(GetUsersWithProducts(productContext));


        }


        //Import
        public static void ResetDataBase(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("Database deleted.");

            context.Database.EnsureCreated();
            Console.WriteLine("Database create. ");

        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var attr = new XmlRootAttribute("Users");
            var serializer = new XmlSerializer(typeof(ImportUserDTO[]), attr);

            var deserializedUsers = (ImportUserDTO[])serializer.Deserialize(new StringReader(inputXml));

            var users = new List<User>();



            foreach (var userDTO in deserializedUsers)
            {
                var user = mapper.Map<User>(userDTO);

                users.Add(user);
            }

            context.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var attr = new XmlRootAttribute("Products");
            var serializer = new XmlSerializer(typeof(ImportProductDTO[]), attr);

            var deserializerProducts = (ImportProductDTO[])serializer.Deserialize(new StringReader(inputXml));

            var products = new List<Product>();



            foreach (var productDTO in deserializerProducts)
            {
                var product = new Product
                {
                    Name = productDTO.Name,
                    Price = productDTO.Price,
                    BuyerId = productDTO.BuyerId,
                    SellerId = productDTO.SellerId
                };

                products.Add(product);
            }

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var attr = new XmlRootAttribute("Categories");
            var serializer = new XmlSerializer(typeof(ImportCategoryDTO[]), attr);

            var deserializerCategories = (ImportCategoryDTO[])serializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();



            foreach (var categoryDTO in deserializerCategories)
            {
                var category = new Category
                {
                    Name = categoryDTO.Name
                };
                if (category.Name != null)
                {
                    categories.Add(category);
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";

        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var attr = new XmlRootAttribute("CategoryProducts");
            var serializer = new XmlSerializer(typeof(ImportCategoryProduct[]), attr);

            var deserializedCategoryProducts = (ImportCategoryProduct[])serializer.Deserialize(new StringReader(inputXml));

            var categoryProducts = new List<CategoryProduct>();

            foreach (var cpDTO in deserializedCategoryProducts)
            {
                if (context.Products.Any(x => x.Id == cpDTO.ProductId) &&
                    context.Categories.Any(c => c.Id == cpDTO.CategoryId))
                {
                    var categoryProduct = new CategoryProduct
                    {
                        CategoryId = cpDTO.CategoryId,
                        ProductId = cpDTO.ProductId
                    };
                    categoryProducts.Add(categoryProduct);
                }
            }
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();


            return $"Successfully imported {categoryProducts.Count}";
        }

        //Export
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportProductInRangeDTO
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerName = String.Concat(p.Buyer.FirstName, " ", p.Buyer.LastName)
                })
                .ToList();

            var attr = new XmlRootAttribute("Products");

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            StringBuilder sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(List<ExportProductInRangeDTO>), attr);

            serializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var attr = new XmlRootAttribute("Users");

            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .ProjectTo<ExportSoldProductDTO>(config)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            var serializer = new XmlSerializer(typeof(ExportSoldProductDTO[]), attr);

            serializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var attr = new XmlRootAttribute("Categories");

            var serializer = new XmlSerializer(typeof(CategoriesByCountDTO[]), attr);

            var categories = context.Categories
                .ProjectTo<CategoriesByCountDTO>(config)
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            serializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var attr = new XmlRootAttribute("Users");

            var serializer = new XmlSerializer(typeof(ExportUserCountDTO), attr);

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            var users = context.Users
                .ToArray()
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUserDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProduct = new ExportProductCountDTO
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new ExportProductDTO
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(x => x.SoldProduct.Count)
                .Take(10)
                .ToArray();

            var result = new ExportUserCountDTO
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                Users = users
            };


            serializer.Serialize(new StringWriter(sb), result, namespaces);


            return sb.ToString().TrimEnd();
        }
    }
}