using AutoMapper;
using GSRS.Api.Dtos;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.WebApi.Mappers.Profiles
{
    public class LicenseServerProfile : Profile
    {
        public LicenseServerProfile()
        {
            CreateMap<LicenseServer, LicenseServerDto>().ReverseMap();
            CreateMap<LicenseServer, LicenseServerDto>().ForMember(des=>des.ServerGroupName, s=>s.MapFrom(c=>c.LicServerGroup.ServerGroupName)).ForMember(des=>des.LicTypeName , s=>s.MapFrom(c=>c.LicType.LicTypeName)).ForMember(des=>des.Description , s=>s.MapFrom(c=>c.AutoImportType.Description));
            CreateMap<BaseDto, BaseModel>().ReverseMap();
            CreateMap<BaseModel, BaseDto>().ReverseMap();
        }
    }
}