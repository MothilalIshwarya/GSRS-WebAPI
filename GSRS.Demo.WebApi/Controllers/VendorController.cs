using GSRS.Api.BaseMapperContracts;
using GSRS.Api.Controllers;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.Infrastructure.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GSRS.Demo.WebApi.Controllers;
[Route("api/Vendor")]
[ApiController]

public class VendorController : BaseAsyncController<Vendor,VendorDto>
{
    #region Member
        private readonly IVendorService service;
        #endregion

        #region Constructor
        public VendorController(IVendorService _service,
            IBaseModelToDtoMapper<Vendor, VendorDto> _dtoMapper,
            IBaseDtoToModelMapper<VendorDto, Vendor> _modelMapper)
            : base(_service, _dtoMapper, _modelMapper)
        {
            this.service = _service;
        }
        #endregion
}
