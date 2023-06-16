using AutoMapper;
using GSRS.Api.Dtos;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.WebApi.Mappers.Profiles
{
    public class VendorProfile : Profile
    {
        public VendorProfile()
        {
            CreateMap<Vendor, VendorDto>().ReverseMap();
            CreateMap<BaseDto, BaseModel>().ReverseMap();
            CreateMap<BaseModel, BaseDto>().ReverseMap();
        }
    }
}