using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services.Interfaces
{
    public interface IProductService
    {
        void AddProduct(AddProductInputServiceModel input);

        ICollection<ListAllProducByTypetServiceModel> ListProductsByType(string type);

        ICollection<ListAllProductsServiceModel> ListAllProducts();

        bool RemoveById(string id);

        bool RemoveByName(string name);

    }
}
