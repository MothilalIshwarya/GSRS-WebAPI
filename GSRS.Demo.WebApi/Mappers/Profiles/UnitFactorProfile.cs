using AutoMapper;
using GSRS.Api.Dtos;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.WebApi.Mappers.Profiles
{
    public class UnitFactorProfile : Profile
    {
        public UnitFactorProfile()
        {
            CreateMap<UnitFactor, UnitFactorDto>().ReverseMap();
            //CreateMap<UnitFactor, UnitFactorDto>().ForMember(des=>des.UnitDefinitionDescription, s=>s.MapFrom(c=>c.UnitDefinition.Description));
            CreateMap<UnitFactor, UnitFactorDto>().ForMember(des=>des.Description_UnitDefinition, s=>s.MapFrom(c=>c.UnitDefinition.Description));
            CreateMap<BaseDto, BaseModel>().ReverseMap();
            CreateMap<BaseModel, BaseDto>().ReverseMap();
        }
    }
}