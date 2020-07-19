using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.DTO.CarDTO;
using CarDealer.DTO.CustomerDTO;
using CarDealer.DTO.SupplierDTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //customer
            this.CreateMap<Customer, OrderedCustomerDTO>()
                .ForMember(x => x.BirthDate, y =>
                y.MapFrom(s => s.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));

            this.CreateMap<Customer, TotalSalesByCustomerDTO>()
                .ForMember(x => x.FullName, y => 
                y.MapFrom(s => s.Name))
                .ForMember(x => x.SalesCount, y =>
                y.MapFrom(s => s.Sales.Count))
                .ForMember(x => x.SpentMoney, y => 
                y.MapFrom(s => s.Sales.Sum(c => c.Car.PartCars.Sum(k => k.Part.Price)))); 

            //supplier
            this.CreateMap<Supplier, LocalSupplierDTO>();




        }
    }
}
