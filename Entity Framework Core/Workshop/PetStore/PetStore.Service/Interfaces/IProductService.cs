using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services.Interfaces
{
    public interface IProductService
    {
        void Create(AddProductInputServiceModel input);

        ICollection<ListAllProductsByTypetServiceModel> ListProductsByType(string type);

        ICollection<SearchProductsByNameServiceModel> SearchProductByName(string searchString);
        ICollection<ListAllProductsServiceModel> ListAllProducts();

        bool RemoveById(string id);

        bool RemoveByName(string name);

        void EditProduct(string id, EditProductInputServiceModel product);

        ProductDetailsServiceModel GetById(string id);

    }
}
