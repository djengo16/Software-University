using AutoMapper;
using PetStore.Models;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using PetStore.ViewModels.Product;
using PetStore.ViewModels.Product.InputModel;
using PetStore.ViewModels.Product.OutputModel;
using System;
using System.Collections.Generic;
using System.Text;


namespace PetStore.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<ListAllProductsServiceModel, ListAllProductsViewModel>();

            this.CreateMap<CreateProductInputModel, AddProductInputServiceModel>();

            this.CreateMap<Product, ProductDetailsServiceModel>()
                .ForMember(x => x.ProductType,y => y.MapFrom(s => s.ProductType.ToString()));

            this.CreateMap<ProductDetailsServiceModel, ProductDetailsViewModel>();

            this.CreateMap<SearchProductsByNameServiceModel, ListAllProductsViewModel>()
                .ForMember(x => x.ProductId,y => y.MapFrom(s => s.ProductId));
        }
    }
}
