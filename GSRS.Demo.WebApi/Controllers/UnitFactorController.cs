using GSRS.Api.BaseMapperContracts;
using GSRS.Api.Controllers;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Infrastructure.Helpers;
using GSRS.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace GSRS.Demo.WebApi.Controllers;
[Route("api/unitfactor")]
[ApiController]

public class UnitFactorController : BaseAsyncController<UnitFactor, UnitFactorDto>
{
    #region Member
    private readonly IUnitFactorService service;
    #endregion

    #region Constructor
    public UnitFactorController(IUnitFactorService _service,
        IBaseModelToDtoMapper<UnitFactor, UnitFactorDto> _dtoMapper,
        IBaseDtoToModelMapper<UnitFactorDto, UnitFactor> _modelMapper)
        : base(_service, _dtoMapper, _modelMapper)
    {
        this.service = _service;
    }
     [HttpPost]
    public async override Task<IActionResult> Post([FromBody] UnitFactorDto entity)
    {
         var UnitFactorCode = await _service.SearchAsync(new SearchCondition<UnitFactor>(s => s.UnitFactorCode == entity.UnitFactorCode && s.Id != entity.Id));
        if (UnitFactorCode.Count > 0)
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
