using AutoMapper;
using GSRS.Api.Dtos;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.WebApi.Mappers.Profiles
{
    public class ModContractProfile : Profile
    {
        public ModContractProfile()
        {
            CreateMap<ModContract, ModContractDto>().ReverseMap();
            CreateMap<ModContract, ModContractDto>().ForMember(des => des.AgreementCode_Agreement, s => s.MapFrom(c => c.Agreement.AgreementCode));
            CreateMap<BaseDto, BaseModel>().ReverseMap();
            CreateMap<BaseModel, BaseDto>().ReverseMap();
        }
    }
}