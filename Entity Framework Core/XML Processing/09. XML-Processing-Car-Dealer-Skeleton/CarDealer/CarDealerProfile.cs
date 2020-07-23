using AutoMapper;
using CarDealer.DTO.Export;
using CarDealer.DTO.Importt;
using CarDealer.Models;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //supplier

            this.CreateMap<ImportSupplierDTO, Supplier>();

            this.CreateMap<ImportPartDTO, Part>();

            this.CreateMap<Supplier, LocalSupplierDTO>();

            //Customer
            this.CreateMap<ImportCustomerDTO,Customer>();

            this.CreateMap<Customer, CustomerWithSalesDTO>()
               .ForMember(x => x.FullName, y =>
               y.MapFrom(s => s.Name))
               .ForMember(x => x.BoughtCars, y =>
               y.MapFrom(s => s.Sales.Count))
               .ForMember(x => x.SpentMoney, y =>
               y.MapFrom(s => s.Sales.Sum(c => c.Car.PartCars.Sum(k => k.Part.Price))));

            //Cars

            this.CreateMap<Car, CarFromMakeBmwDTO>();

            //parts

            this.CreateMap<Part, ExportPartDTO>();
            
        }
    }
}
