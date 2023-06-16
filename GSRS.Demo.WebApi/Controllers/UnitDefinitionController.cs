using GSRS.Api.BaseMapperContracts;
using GSRS.Api.Controllers;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Infrastructure.Helpers;
using GSRS.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace GSRS.Demo.WebApi.Controllers;
[Route("api/unitdefinition")]
[ApiController]

public class UnitDefinitionController : BaseAsyncController<UnitDefinition, UnitDefinitionDto>
{
    #region Member
    private readonly IUnitDefinitionService service;
    #endregion

    #region Constructor
    public UnitDefinitionController(IUnitDefinitionService _service,
        IBaseModelToDtoMapper<UnitDefinition, UnitDefinitionDto> _dtoMapper,
        IBaseDtoToModelMapper<UnitDefinitionDto, UnitDefinition> _modelMapper)
        : base(_service, _dtoMapper, _modelMapper)
    {
        this.service = _service;
    }
    [HttpPost]
    public async override Task<IActionResult> Post([FromBody] UnitDefinitionDto entity)
    {
         var UnitDefinitionCode = await _service.SearchAsync(new SearchCondition<UnitDefinition>(s => s.UnitDefinitionCode == entity.UnitDefinitionCode && s.Id != entity.Id));
        if (UnitDefinitionCode.Count > 0)
        {

            return BadRequest(ErrorMesssageVariable.message);
        }
        var model = _modelMapper.Map(entity);
        int idvalue = 0;
        if (entity.Id == 0)
        {
            idvalue = await _service.CreateAsync(model);
        }
        else
        {
            var existingItem = await _service.GetByIdAsync(model.Id, false);

            if (existingItem == null)
            {
                return NotFound();
            }

            idvalue = await _service.UpdateAsync(model);
        }
        return Ok(idvalue);
    }
        #endregion
}
