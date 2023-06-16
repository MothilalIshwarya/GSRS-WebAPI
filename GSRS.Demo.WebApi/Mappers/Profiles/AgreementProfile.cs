using AutoMapper;
using GSRS.Api.Dtos;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.WebApi.Mappers.Profiles
{
    public class AgreementProfile : Profile
    {
        public AgreementProfile()
        {
            CreateMap<Agreement, AgreementDto>().ReverseMap();
            CreateMap<Agreement, AgreementDto>().ForMember(des=>des.VendorName, s=>s.MapFrom(c=>c.Vendor.VendorName));
            CreateMap<BaseDto, BaseModel>().ReverseMap();
            CreateMap<BaseModel, BaseDto>().ReverseMap();
        }
    }
}
