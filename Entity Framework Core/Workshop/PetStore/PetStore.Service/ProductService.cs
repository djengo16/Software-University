using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using PetStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Services
{
    public class ProductService : IProductService
    {
        private readonly PetStoreDbContext dbCon;

        public ProductService(PetStoreDbContext context)
        {
            this.dbCon = context;
        }

        public void AddProduct(AddProductInputServiceModel input)
        {
            var product = new Product
            {
                Name = input.Name,
                ProductType = input.ProductType,
                Price = input.Price
            };

            this.dbCon.Products.Add(product);
            this.dbCon.SaveChanges();
        }



        public ICollection<ListAllProductsServiceModel> ListAllProducts()
        {
            var products = this.dbCon.Products
                .Select(x => new ListAllProductsServiceModel
                {
                    Name = x.Name,
                    ProductType = x.ProductType.ToString(),
                    Price = x.Price
                })
                .OrderBy(x => x.Price)
                .ToList();

            return products;
        }

        public ICollection<ListAllProducByTypetServiceModel> ListProductsByType(string type)
        {
            ProductType productType;

            bool hasParsed = Enum.TryParse(type, true, out productType);

            if (!hasParsed)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }

            var productsServiceModels = this.dbCon.Products
                .Where(x => x.ProductType == productType)
                .Select(x => new ListAllProducByTypetServiceModel
                {
                    Name = x.Name,
                    Price = x.Price
                })
                .OrderBy(x => x.Price)
                .ToList();

            return productsServiceModels;
        }


        public ICollection<SearchProductsByNameServiceModel> SearchProductByName(string searchStr)
        {
            var product = this.dbCon
                .Products
                .Where(p => p.Name.ToLower().Contains(searchStr.ToLower()))
                .Select(x => new SearchProductsByNameServiceModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    ProductType = x.ProductType.ToString()
                })
                .ToList();
            

            return product;            
        }

        public bool RemoveById(string id)
        {
            var productToRemove = this.dbCon.Products
                .Find(id);

            if(productToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductId);
            }

            dbCon.Products.Remove(productToRemove);

            int rowsAffected = dbCon.SaveChanges();

            bool wasDeleted = rowsAffected == 1;

            return wasDeleted;
        }

        public bool RemoveByName(string name)
        {
            var productToRemove = this.dbCon.Products
                              .FirstOrDefault(x => x.Name == name);

            if (productToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductName);
            }

            dbCon.Products.Remove(productToRemove);

            int rowsAffected = dbCon.SaveChanges();

            bool wasDeleted = rowsAffected == 1;

            return wasDeleted;
        }

    }
}
