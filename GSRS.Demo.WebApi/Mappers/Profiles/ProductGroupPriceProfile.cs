using AutoMapper;
using GSRS.Api.Dtos;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.WebApi.Mappers.Profiles
{
    public class ProductGroupPriceProfile : Profile
    {
        public ProductGroupPriceProfile()
        {
            CreateMap<ProductGroupPrice, ProductGroupPriceDto>().ReverseMap();
            CreateMap<ProductGroupPrice, ProductGroupPriceDto>().ForMember(des=>des.ProductGroupName, s=>s.MapFrom(c=>c.ProductGroup.ProductGroupName)).ForMember(des=>des.ServerGroupName, s=>s.MapFrom(c=>c.LicServerGroup.ServerGroupName));
            CreateMap<BaseDto, BaseModel>().ReverseMap();
            CreateMap<BaseModel, BaseDto>().ReverseMap();
        }
    }
}