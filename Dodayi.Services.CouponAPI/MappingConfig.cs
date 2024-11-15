using AutoMapper;
using Dodayi.Services.CouponAPI.Dto;
using Dodayi.Services.CouponAPI.Models;

namespace Dodayi.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CouponDto, Coupon>();
                cfg.CreateMap<Coupon, CouponDto>();
            });
            return config;
        }   
    }
}
