using AutoMapper;
using Dodayi.Services.ProductAPI.Dto;
using Dodayi.Services.ProductAPI.Models;

namespace Dodayi.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<ProductDto, Product>();
                //cfg.CreateMap<Product, ProductDto>();

                cfg.CreateMap<ProductDto, Product>().ReverseMap();
            });
            return config;
        }   
    }
}
