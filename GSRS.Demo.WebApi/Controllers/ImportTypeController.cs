using GSRS.Api.BaseMapperContracts;
using GSRS.Api.Controllers;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Infrastructure.Helpers;
using GSRS.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace GSRS.Demo.WebApi.Controllers;
[Route("api/importtype")]
[ApiController]

public class ImportTypeController : BaseAsyncController<ImportType, ImportTypeDto>
{
    #region Member
    private readonly IImportTypeService service;
    #endregion

    #region Constructor
    public ImportTypeController(IImportTypeService _service,
        IBaseModelToDtoMapper<ImportType, ImportTypeDto> _dtoMapper,
        IBaseDtoToModelMapper<ImportTypeDto, ImportType> _modelMapper)
        : base(_service, _dtoMapper, _modelMapper)
    {
        this.service = _service;
    }
     [HttpPost]
    public async override Task<IActionResult> Post([FromBody] ImportTypeDto entity)
    {
        var ImportTypeName = await _service.SearchAsync(new SearchCondition<ImportType>(s => s.ImportTypeName == entity.ImportTypeName && s.Id != entity.Id));

        if (ImportTypeName.Count > 0)
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
