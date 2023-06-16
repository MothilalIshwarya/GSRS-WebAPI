
using GSRS.Api.BaseMapperContracts;
using GSRS.Api.ControllerContracts;
using GSRS.Api.DtoContracts;
using GSRS.Api.Dtos;
using GSRS.Infrastructure.Helpers;
using GSRS.Service.ModelContracts;
using GSRS.Service.Models;
using GSRS.Service.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace GSRS.Api.Controllers
{
    public class BaseAsyncController<TEntity, TDto> : Controller, IBaseAsyncController<TEntity, TDto>
        where TEntity : BaseModel, IBaseModel where TDto : BaseDto, IBaseDto
    {
        protected readonly IBaseAsyncService<TEntity> _service;
        protected readonly IBaseModelToDtoMapper<TEntity, TDto> _dtoMapper;
        protected readonly IBaseDtoToModelMapper<TDto, TEntity> _modelMapper;
        public BaseAsyncController(IBaseAsyncService<TEntity> service
            , IBaseModelToDtoMapper<TEntity, TDto> dtoMapper
            , IBaseDtoToModelMapper<TDto, TEntity> modelMapper
            )
        {
            _service = service;
            _dtoMapper = dtoMapper;
            _modelMapper = modelMapper;
        }

        [HttpGet]
        public async virtual Task<IActionResult> Get()
        {
            // Use an empty or void search condition predicate to retrieve all entity rows
            var voidSearchCondition = default(SearchCondition<TEntity>);

            // Using base service method SearchAsync with empty predicate to get all results
            var entities = await _service.SearchAsync(voidSearchCondition);

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

        /// <summary>
        /// Scaffold Get by Id API to fetch an entity by given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>BaseDto JSON object</returns>
        [HttpGet("{id}")]
        public async virtual Task<IActionResult> Get(int id)
        {
            // Ensure Id param is valid
            Check.Emptyint("id", id);

            // Using base service method GetByIdAsync to fetch the entity
            var model = await _service.GetByIdAsync(id);

            if (model == null)
            {
                // Send NoContent response if no result found
                return NoContent();
            }

            // Tranform entity to dtos
            var result = _dtoMapper.Map(model);

            // Return Api response with data
            return Ok(result);
        }

        /// <summary>
        /// Scaffold Create API to add a new entity and update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Created entity Id (int)</returns>
        [HttpPost]
        public async virtual Task<IActionResult> Post([FromBody] TDto entity)
        {
            // Ensure entity param is valid
               //Check.CheckModelProperties(entity);

            // Transform Dtos to BaseModel entity
            var model = _modelMapper.Map(entity);
            int idvalue=0;
            if(entity.Id==0 || entity.Id==null || entity.Id==' '){
            // Using CreateAsync base service method to save the new entity
             idvalue = await _service.CreateAsync(model);
            }
            else{
                var existingItem = await _service.GetByIdAsync(model.Id, false);

             if (existingItem == null)
             {
                 // Send NotFound response if there is no existing entity found
                 return NotFound();
             }
                idvalue=  await _service.UpdateAsync(model);
            }
            // Return the newly created entity Id as response
            return Ok(idvalue);
        }

       
        /// <summary>
        /// Scaffold Delete API to delete an entity of given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async virtual Task<IActionResult> Delete(int id)
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
            var results = await _service.DeleteAsync(model);

            // Return Api response with status
            return Ok(results);
        }
    }
}