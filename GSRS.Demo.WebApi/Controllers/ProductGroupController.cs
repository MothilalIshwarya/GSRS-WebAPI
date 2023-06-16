using GSRS.Api.BaseMapperContracts;
using GSRS.Api.Controllers;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.Infrastructure.Dtos;
using Microsoft.AspNetCore.Mvc;
using GSRS.Service.Models;
using GSRS.Service.ModelContracts;
using GSRS.Infrastructure.Helpers;

namespace GSRS.Demo.WebApi.Controllers;
[Route("api/productgroup")]
[ApiController]

public class ProductGroupController : BaseAsyncController<ProductGroup, ProductGroupDto>
{
    #region Member
    private readonly IProductGroupService service;
    #endregion

    #region Constructor
    public ProductGroupController(IProductGroupService _service,
        IBaseModelToDtoMapper<ProductGroup, ProductGroupDto> _dtoMapper,
        IBaseDtoToModelMapper<ProductGroupDto, ProductGroup> _modelMapper)
        : base(_service, _dtoMapper, _modelMapper)
    {
        this.service = _service;
    }
    #endregion

    [HttpDelete("Delete/{id}")]
    public async override Task<IActionResult> Delete(int id)
    {
        // Ensure Id param is valid
        Check.Emptyint("id", id);

        // Fetch existing entity using base service method GetByIdAsync
        var model = await _service.GetByIdAsync(id, false);

        if (model == null)
        {
            // Send NotFound response if there is no 
            return NotFound();
        }

        // Delete the entity using the service method SoftDeleteAsync
        var results = await _service.SoftDeleteAsync(model);

        // Return Api response with status
        return Ok(results);
    }
    [HttpPost]
    public async override Task<IActionResult> Post([FromBody] ProductGroupDto entity)
    {
        //Ensure ProductGroupCode is valid
        var ProductGroupCode = await _service.SearchAsync(new SearchCondition<ProductGroup>(s => s.ProductGroupCode == entity.ProductGroupCode && s.Id != entity.Id));
        if (ProductGroupCode.Count > 0)
        {

            return BadRequest(ErrorMesssageVariable.message);
        }
        var model = _modelMapper.Map(entity);
        int idvalue = 0;
        //Creating the entity using the service method createasync
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
    [HttpGet("AgreementId/{id}")]
    public async virtual Task<IActionResult> GetProductGroupByAgreementId(int id)
    {
        // Ensure Id param is valid

        Check.Emptyint("id", id);

        // Using base service method SearchAsync with empty predicate to get all results
        var entities = await _service.SearchAsync(new SearchCondition<ProductGroup>(s => s.AgreementId == id && s.Enabled == 1));

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

}
