using AutoMapper;
using BLL.GaiaLogistics.Extensions;
using Domain.GaiaLogistics.Entities;
using Domain.GaiaLogistics.Enums;
using UI.GaiaLogistics.ViewModels;

namespace UI.GaiaLogistics.Mappers
{
    public sealed class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<BranchListResponseViewModel, Branch>()
                .ReverseMap();
            CreateMap<BranchResponseViewModel, Branch>()
                .ForMember(dest => dest.BranchType, opt => opt.MapFrom(src => src.BranchType.ToEnum<BranchTypeEnum>()))
                .ReverseMap()
                .ForMember(dest => dest.BranchType, opt => opt.MapFrom(src => src.BranchType.ToString()));
            CreateMap<BranchCreateRequestViewModel, Branch>()
                .ForMember(dest => dest.BranchType, opt => opt.MapFrom(src => src.BranchType.ToEnum<BranchTypeEnum>()))
                .ReverseMap()
                .ForMember(dest => dest.BranchType, opt => opt.MapFrom(src => src.BranchType.ToString()));
            CreateMap<BranchUpdateRequestViewModel, Branch>()
                .ReverseMap();
            CreateMap<ProductListResponseViewModel, Product>()
                .ReverseMap();
            CreateMap<ProductResponseViewModel, Product>()
                .ReverseMap();
            CreateMap<ProductCreateRequestViewModel, Product>()
                .ReverseMap();
            CreateMap<ProductUpdateRequestViewModel, Product>()
                .ReverseMap();
            CreateMap<UserListResponseViewModel, User>()
                .ReverseMap();
            CreateMap<UserResponseViewModel, User>()
                .ReverseMap();
            CreateMap<UserCreateRequestViewModel, User>()
                .ReverseMap();
            CreateMap<UserUpdateRequestViewModel, User>()
                .ReverseMap();
            CreateMap<StockMovementItemRequestViewModel, StockMovementItem>()
                .ReverseMap();
            CreateMap<StockMovementPagedResponseViewModel, StockMovement>()
                .ForMember(dest => dest.CauseType, opt => opt.MapFrom(src => src.CauseType.ToEnum<CauseTypeEnum>()))
                .ReverseMap()
                .ForMember(dest => dest.CauseType, opt => opt.MapFrom(src => src.CauseType.ToString()));
            CreateMap<StockMovementItemPagedResponseViewModel, StockMovementItem>()
                .ReverseMap();
            CreateMap<UserPagedResponseViewModel, User>()
                .ReverseMap();
            CreateMap<BranchPagedResponseViewModel, Branch>()
                .ForMember(dest => dest.BranchType, opt => opt.MapFrom(src => src.BranchType.ToEnum<BranchTypeEnum>()))
                .ReverseMap()
                .ForMember(dest => dest.BranchType, opt => opt.MapFrom(src => src.BranchType.ToString()));
            CreateMap<ProductPagedResponseViewModel, Product>()
                .ReverseMap();
        }
    }
}
