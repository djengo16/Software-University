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
using System.Linq.Expressions;
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

        public void Create(AddProductInputServiceModel input)
        {
            try
            {
                var product = new Product
                {
                    Name = input.Name,
                    ProductType = (ProductType)input.ProductType,
                    Price = input.Price

                };
                this.dbCon.Products.Add(product);
                this.dbCon.SaveChanges();
            }
            catch (Exception)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidProductType);
            }

        }



        public ICollection<ListAllProductsServiceModel> ListAllProducts()
        {
            var products = this.dbCon.Products
                .Select(x => new ListAllProductsServiceModel
                {
                    ProductId = x.Id,
                    Name = x.Name,
                    ProductType = x.ProductType.ToString(),
                    Price = x.Price
                })
                .OrderBy(x => x.Price)
                .ToList();

            return products;
        }

        public ICollection<ListAllProductsByTypetServiceModel> ListProductsByType(string type)
        {
            ProductType productType;

            bool hasParsed = Enum.TryParse(type, true, out productType);

            if (!hasParsed)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }

            var productsServiceModels = this.dbCon.Products
                .Where(x => x.ProductType == productType)
                .Select(x => new ListAllProductsByTypetServiceModel
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

        //public ICollection<ListAllProductsByNameServiceModel> SearchByName(string searchStr, bool caseSensitive)
        //{
        //    ICollection<ListAllProductsByNameServiceModel> products;

        //    if (caseSensitive)
        //    {
        //        products = this.dbContext
        //            .Products
        //            .Where(p => p.Name.Contains(searchStr))
        //            .ProjectTo
        //                <ListAllProductsByNameServiceModel>(this.mapper.ConfigurationProvider)
        //            .ToList();
        //    }
        //    else
        //    {
        //        products = this.dbContext
        //            .Products
        //            .Where(p => p.Name.ToLower().Contains(searchStr.ToLower()))
        //            .ProjectTo
        //                <ListAllProductsByNameServiceModel>(this.mapper.ConfigurationProvider)
        //            .ToList();
        //    }

        //    return products;
        //}

        public bool RemoveById(string id)
        {
            var productToRemove = this.dbCon.Products
                .Find(id);

            if (productToRemove == null)
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
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }

            dbCon.Products.Remove(productToRemove);

            int rowsAffected = dbCon.SaveChanges();

            bool wasDeleted = rowsAffected == 1;

            return wasDeleted;
        }

        public void EditProduct(string id, EditProductInputServiceModel input)
        {
            Product productToUpdate = dbCon.Products.Find(id);

            if (productToUpdate == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductId);
            }

            try
            {

                productToUpdate.Name = input.Name;
                productToUpdate.ProductType =
                    (ProductType)Enum.Parse(typeof(ProductType), input.ProductType, true);
                productToUpdate.Price = input.Price;

                this.dbCon.SaveChanges();
            }
            catch (Exception)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidProductType);
            }

        }

        public ProductDetailsServiceModel GetById(string id)
        {
            Product product = this.dbCon.Products.FirstOrDefault(x => x.Id == id);

            if(product == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductId);
            }

            ProductDetailsServiceModel serviceModels =
                new ProductDetailsServiceModel
                {
                    Name = product.Name,
                    Price = product.Price,
                    ProductType = product.ProductType.ToString()
                };

            return serviceModels;
        }
    }
}
