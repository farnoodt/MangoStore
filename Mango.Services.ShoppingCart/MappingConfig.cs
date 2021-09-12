using AutoMapper;
using Mango.Services.ShoppingCart.Models;
using Mango.Services.ShoppingCart.Models.Dto;

namespace Mango.Services.ShoppingCart
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
                config.CreateMap<CartHeaderDto, CartHeader>().ReverseMap();
                config.CreateMap<CartHeaderDto, CartDetails>().ReverseMap();
                config.CreateMap<CartDto, Cart>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
