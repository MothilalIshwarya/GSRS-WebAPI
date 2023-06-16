using AutoMapper;
using GSRS.Api.Dtos;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.WebApi.Mappers.Profiles
{
    public class LicenseTypeProfile : Profile
    {
        public LicenseTypeProfile()
        {
            CreateMap<LicenseType, LicenseTypeDto>().ReverseMap();
            CreateMap<LicenseType, LicenseTypeDto>().ForMember(des=>des.ImportTypeName, s=>s.MapFrom(c=>c.ImportType.ImportTypeName));
            CreateMap<BaseDto, BaseModel>().ReverseMap();
            CreateMap<BaseModel, BaseDto>().ReverseMap();
        }
    }
}