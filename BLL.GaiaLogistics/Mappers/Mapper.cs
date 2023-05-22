using AutoMapper;
using BLL.GaiaLogistics.Extensions;
using Domain.GaiaLogistics.Entities;
using Domain.GaiaLogistics.Enums;
using Domain.GaiaLogistics.Models;

namespace BLL.GaiaLogistics.Mappers
{
    public sealed class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Branch, BranchModel>()
                .ForMember(dest => dest.BranchType, opt => opt.MapFrom(src => src.BranchType.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.BranchType, opt => opt.MapFrom(src => src.BranchType.ToEnum<BranchTypeEnum>()));
            CreateMap<City, CityModel>().ReverseMap();
            CreateMap<Country, CountryModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Province, ProvinceModel>().ReverseMap();
            CreateMap<StockMovement, StockMovementModel>()
                .ForMember(dest => dest.CauseType, opt => opt.MapFrom(src => src.CauseType.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.CauseType, opt => opt.MapFrom(src => src.CauseType.ToEnum<CauseTypeEnum>()));
            CreateMap<StockMovementItem, StockMovementItemModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
        }   
    }
}
