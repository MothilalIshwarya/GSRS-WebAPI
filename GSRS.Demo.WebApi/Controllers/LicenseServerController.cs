using GSRS.Api.BaseMapperContracts;
using GSRS.Api.Controllers;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.Infrastructure.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GSRS.Demo.WebApi.Controllers;
[Route("api/LicenseServer")]
[ApiController]

public class LicenseServerController : BaseAsyncController<LicenseServer,LicenseServerDto>
{
    #region Member
        private readonly ILicenseServerService service;
        #endregion

        #region Constructor
        public LicenseServerController(ILicenseServerService _service,
            IBaseModelToDtoMapper<LicenseServer, LicenseServerDto> _dtoMapper,
            IBaseDtoToModelMapper<LicenseServerDto, LicenseServer> _modelMapper)
            : base(_service, _dtoMapper, _modelMapper)
        {
            this.service = _service;
        }
        #endregion
}
