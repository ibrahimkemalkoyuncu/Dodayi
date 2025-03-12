using AutoMapper;
using Dodayi.Services.CouponAPI.Dto;
using Dodayi.Services.CouponAPI.Models;

namespace Dodayi.Services.CouponAPI
{
    /// <summary>
    /// AutoMapper yapılandırması için kullanılan sınıf
    /// Model ve DTO sınıfları arasındaki dönüşümleri yapılandırır
    /// </summary>
    public class MappingConfig
    {
        /// <summary>
        /// AutoMapper haritalama konfigürasyonunu oluşturur ve döndürür
        /// </summary>
        /// <returns>Yapılandırılmış MapperConfiguration nesnesi</returns>
        public static MapperConfiguration RegisterMaps()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                // CouponDto -> Coupon dönüşümü için haritalama
                cfg.CreateMap<CouponDto, Coupon>();
                // Coupon -> CouponDto dönüşümü için haritalama
                cfg.CreateMap<Coupon, CouponDto>();
            });
            return config;
        }   
    }
}
