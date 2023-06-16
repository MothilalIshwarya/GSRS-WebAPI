using GSRS.Api.BaseMapperContracts;
using GSRS.Api.Controllers;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Infrastructure.Helpers;
using GSRS.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace GSRS.Demo.WebApi.Controllers;
[Route("api/Agreement")]
[ApiController]

public class AgreementController : BaseAsyncController<Agreement,AgreementDto>
{
    #region Member
        private readonly IAgreementService service;
        #endregion

        #region Constructor
        public AgreementController(IAgreementService _service,
            IBaseModelToDtoMapper<Agreement, AgreementDto> _dtoMapper,
            IBaseDtoToModelMapper<AgreementDto, Agreement> _modelMapper)
            : base(_service, _dtoMapper, _modelMapper)
        {
            this.service = _service;
        }
         [HttpGet("VendorId/{id}")]
        public async virtual Task<IActionResult> GetAgreementByVendorId(int id)
        {
            Check.Emptyint("id", id);

            // Using base service method SearchAsync with empty predicate to get all results
            var entities = await _service.SearchAsync(new SearchCondition<Agreement>(s=>s.VendorId==id));

            if (entities == null || !entities.Any())
            {
               
                // Send NoContent response if no results found
                return NoContent();
            }
            // Transform entity to dtos
            var results = _dtoMapper.Map(entities.Values);
            // Return Api response with data
            return Ok(results);
        }

        #endregion
}
