using GSRS.Api.BaseMapperContracts;
using GSRS.Api.Controllers;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.Infrastructure.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GSRS.Demo.WebApi.Controllers;
[Route("api/licenseservergroup")]
[ApiController]

public class LicenseServerGroupController : BaseAsyncController<LicenseServerGroup,LicenseServerGroupDto>
{
    #region Member
        private readonly ILicenseServerGroupService service;
        #endregion

        #region Constructor
        public LicenseServerGroupController(ILicenseServerGroupService _service,
            IBaseModelToDtoMapper<LicenseServerGroup, LicenseServerGroupDto> _dtoMapper,
            IBaseDtoToModelMapper<LicenseServerGroupDto, LicenseServerGroup> _modelMapper)
            : base(_service, _dtoMapper, _modelMapper)
        {
            this.service = _service;
        }
        #endregion
}
