using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //users

            this.CreateMap<ImportUserDTO,User>();

            this.CreateMap<User, ExportSoldProductDTO>()
                .ForMember(u => u.SoldProducts, m => m.MapFrom(p => p.ProductsSold));

            //product

            this.CreateMap<ImportProductDTO, Product>();

            this.CreateMap<Product, ProductDTO>();

            //categories

            this.CreateMap<Category, CategoriesByCountDTO>()
                .ForMember(x => x.Count, m => m.MapFrom(y =>
                y.CategoryProducts.Count))
                .ForMember(x => x.AveragePrice, m => m.MapFrom(y =>
                y.CategoryProducts.Average(cp => cp.Product.Price)))
                .ForMember(x => x.TotalRevenue, m => m.MapFrom(y =>
                y.CategoryProducts.Sum(cp => cp.Product.Price)));

            
        }
    }
}
