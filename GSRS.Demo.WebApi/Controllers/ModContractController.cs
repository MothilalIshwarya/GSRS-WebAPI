using GSRS.Api.BaseMapperContracts;
using GSRS.Api.Controllers;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Infrastructure.Helpers;
using GSRS.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace GSRS.Demo.WebApi.Controllers;
[Route("api/ModContract")]
[ApiController]

public class ModContractController : BaseAsyncController<ModContract, ModContractDto>
{
    #region Member
    private readonly IModContractService service;
    #endregion

    #region Constructor
    public ModContractController(IModContractService _service,
        IBaseModelToDtoMapper<ModContract, ModContractDto> _dtoMapper,
        IBaseDtoToModelMapper<ModContractDto, ModContract> _modelMapper)
        : base(_service, _dtoMapper, _modelMapper)
    {
        this.service = _service;
    }
    [HttpPost]
    public async override Task<IActionResult> Post([FromBody] ModContractDto entity)
    {
        //Ensuring startdate and enddate is valid
        Check.DateValidations(entity.DateStart, entity.DateEnd);
        //mapping dto to model
        var model = _modelMapper.Map(entity);
        //Creating the entity using the service method createasync
        int idvalue = 0;
        if (entity.Id == 0)
        {
            idvalue = await _service.CreateAsync(model);
            return Ok(idvalue);
        }
        //Updating the entity using the service method updateasync
        else
        {
            //Ensure entity is already exist using service method GetByIdAsync
            var existingItem = await _service.GetByIdAsync(model.Id, false);
            if (existingItem == null)
            {
                return NotFound();
            }
            else
            {
                idvalue = await _service.UpdateAsync(model);
                return Ok(idvalue);
            }
        }

    }

    #endregion
}
