using GSRS.Api.BaseMapperContracts;
using GSRS.Api.Controllers;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Infrastructure.Helpers;
using GSRS.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace GSRS.Demo.WebApi.Controllers;
[Route("api/costmodel")]
[ApiController]

public class CostModelController : BaseAsyncController<CostModel, CostModelDto>
{
    #region Member
    private readonly ICostModelService service;
    #endregion

    #region Constructor
    public CostModelController(ICostModelService _service,
        IBaseModelToDtoMapper<CostModel, CostModelDto> _dtoMapper,
        IBaseDtoToModelMapper<CostModelDto, CostModel> _modelMapper)
        : base(_service, _dtoMapper, _modelMapper)
    {
        this.service = _service;
    }
    [HttpPost]
    public async override Task<IActionResult> Post([FromBody] CostModelDto entity)
    {
        //Ensure CostmodelName is valid
        var CostModelName = await _service.SearchAsync(new SearchCondition<CostModel>(s => s.CostModelName == entity.CostModelName && s.Id != entity.Id));
        if (CostModelName.Count > 0)
        {

            return BadRequest(ErrorMesssageVariable.message);
        }
        //Mapping Dto to model
        var model = _modelMapper.Map(entity);
        int idvalue = 0;
        //creating Costmodel
        if (entity.Id == 0)
        {
            idvalue = await _service.CreateAsync(model);
            return Ok(idvalue);
        }
        //updating costmodel
        else
        {
            var existingItem = await _service.GetByIdAsync(model.Id, false);

            if (existingItem == null)
            {
                return NotFound();
            }
            else{

            idvalue = await _service.UpdateAsync(model);
            return Ok(idvalue);
            }
        }
        
    }
    #endregion
}
