using AutoMapper;
using OnlineShopapi.Dtos.Requests;
using OnlineShopapi.Dtos.Responses;
using OnlineShopapi.Models;

namespace OnlineShopapi.Mapper
{
    public class OnlineShopApimapperProfile:Profile
    {
        public OnlineShopApimapperProfile()
        {
            //mapping request
            CreateMap<AddCatogoryDto,ProductCatogory>();
            CreateMap<AddCustomerDto,Customer>();
            CreateMap<AddProductDto,Product>().ForMember(p=>p.QuantityStock, opt=>opt.MapFrom(opt1=>opt1.Quantity));
            CreateMap<UpdateCustomerDto,Customer>();
            CreateMap<UpdateProductDto,Product>().ForMember(p=>p.QuantityStock, opt=>opt.MapFrom(opt1=>opt1.Quantity));
            //mapping response
            CreateMap<Customer,CustomerResponseDto>().ForMember(cResDto=> cResDto.FullName, opt=>opt.MapFrom(c=>String.Concat(c.FirstName," ",c.LastName )));
            CreateMap<Product, ProductResponseDto>();


        }
        
    }
}