using System.Collections.Generic;
using GSRS.Api.BaseMapperContracts;
using GSRS.Api.Controllers;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GSRS.Demo.WebApi.Controllers;
[Route("api/productgroupprice")]
[ApiController]

public class ProductGroupPriceController : BaseAsyncController<ProductGroupPrice, ProductGroupPriceDto>
{
    #region Member
    private readonly IProductGroupPriceService service;
    #endregion

    #region Constructor
    public ProductGroupPriceController(IProductGroupPriceService _service,
        IBaseModelToDtoMapper<ProductGroupPrice, ProductGroupPriceDto> _dtoMapper,
        IBaseDtoToModelMapper<ProductGroupPriceDto, ProductGroupPrice> _modelMapper)
        : base(_service, _dtoMapper, _modelMapper)
    {
        this.service = _service;
    }
    [HttpPost("Post")]
    public async Task<IActionResult> Post([FromBody] List<ProductGroupPriceDto> entity)
    {
        //Ensuring startdate and enddate is valid
        for (int i = 0; i < entity.Count; i++)
        {
            Check.DateValidations(entity[i].DateStart, entity[i].DateEnd);
        }
        //mapping dto to model
        var model = _modelMapper.Map(entity).ToList();
        //Creating the entity using the service method createListasync
        bool result = await service.CreateListAsync(model);
        return Ok(result);


    }
    #endregion
}
