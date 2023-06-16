using GSRS.Api.BaseMapperContracts;
using GSRS.Api.Controllers;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.Infrastructure.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GSRS.Demo.WebApi.Controllers;
[Route("api/AutoImportType")]
[ApiController]

public class AutoImportTypeController : BaseAsyncController<AutoImportType,AutoImportTypeDto>
{
    #region Member
        private readonly IAutoImportTypeService service;
        #endregion

        #region Constructor
        public AutoImportTypeController(IAutoImportTypeService _service,
            IBaseModelToDtoMapper<AutoImportType, AutoImportTypeDto> _dtoMapper,
            IBaseDtoToModelMapper<AutoImportTypeDto, AutoImportType> _modelMapper)
            : base(_service, _dtoMapper, _modelMapper)
        {
            this.service = _service;
        }
        #endregion
}
