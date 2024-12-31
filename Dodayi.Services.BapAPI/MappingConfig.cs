using AutoMapper;
using Dodayi.Services.BapAPI.Dto;
using Dodayi.Services.BapAPI.Models;

namespace Dodayi.Services.BapAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArbisKeywordDto, ArbisKeyword>();
                cfg.CreateMap<ArbisKeyword, ArbisKeywordDto>();

                cfg.CreateMap<DetailDto, Detail>();
                cfg.CreateMap<Detail, DetailDto>();
            });
            return config;
        }
    }
}
