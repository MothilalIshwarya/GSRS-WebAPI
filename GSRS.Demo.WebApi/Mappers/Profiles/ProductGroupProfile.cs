using AutoMapper;
using GSRS.Api.Dtos;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.WebApi.Mappers.Profiles
{
    public class ProductGroupProfile : Profile
    {
        public ProductGroupProfile()
        {
            CreateMap<ProductGroup, ProductGroupDto>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupDto>().ForMember(des=>des.Description_Agreement, s=>s.MapFrom(c=>c.Agreement.Description)).ForMember(des=>des.Description_UnitFactor, s=>s.MapFrom(c=>c.UnitFactor.Description)).ForMember(des=>des.Description_CostModel, s=>s.MapFrom(c=>c.CostModel.CostModelName));
            CreateMap<BaseDto, BaseModel>().ReverseMap();
            CreateMap<BaseModel, BaseDto>().ReverseMap();
        }
    }
}