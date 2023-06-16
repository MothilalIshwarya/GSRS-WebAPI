using GSRS.Api.BaseMapperContracts;
using GSRS.Api.Controllers;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Infrastructure.Helpers;
using GSRS.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace GSRS.Demo.WebApi.Controllers;
[Route("api/product")]
[ApiController]

public class ProductController : BaseAsyncController<Product, ProductDto>
{
    #region Member
    private readonly IProductService service;
    #endregion

    #region Constructor
    public ProductController(IProductService _service,
        IBaseModelToDtoMapper<Product, ProductDto> _dtoMapper,
        IBaseDtoToModelMapper<ProductDto, Product> _modelMapper)
        : base(_service, _dtoMapper, _modelMapper)
    {
        this.service = _service;
    }
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
            //  existing entity found for it to be deleted
            return NotFound();
        }

        // Delete the entity using the service method DeleteAsync
        // var results = await _service.DeleteAsync(model);
        var results = await _service.SoftDeleteAsync(model);

        // Return Api response with status
        return Ok(results);
    }

      [HttpPost]
    public async override Task<IActionResult> Post([FromBody] ProductDto entity)
    {
        var FeaturesKey = await _service.SearchAsync(new SearchCondition<Product>(s => s.FeaturesKey == entity.FeaturesKey && s.Id != entity.Id));
        if (FeaturesKey.Count > 0)
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
