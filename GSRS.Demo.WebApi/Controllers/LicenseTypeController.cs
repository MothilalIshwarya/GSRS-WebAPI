using GSRS.Api.BaseMapperContracts;
using GSRS.Api.Controllers;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.Infrastructure.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GSRS.Demo.WebApi.Controllers;
[Route("api/licensetype")]
[ApiController]

public class LicenseTypeController : BaseAsyncController<LicenseType,LicenseTypeDto>
{
    #region Member
        private readonly ILicenseTypeService service;
        #endregion

        #region Constructor
        public LicenseTypeController(ILicenseTypeService _service,
            IBaseModelToDtoMapper<LicenseType, LicenseTypeDto> _dtoMapper,
            IBaseDtoToModelMapper<LicenseTypeDto, LicenseType> _modelMapper)
            : base(_service, _dtoMapper, _modelMapper)
        {
            this.service = _service;
        }
        #endregion
}
