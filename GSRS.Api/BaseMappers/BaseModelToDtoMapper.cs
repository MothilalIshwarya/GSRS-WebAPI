using AutoMapper;
using GSRS.Api.BaseMapperContracts;
using GSRS.Api.Dtos;
using GSRS.Service.Models;

namespace GSRS.Api.BaseMappers
{
    public class BaseModelToDtoMapper<TSource, TDestination> : IBaseModelToDtoMapper<TSource, TDestination>
        where TSource : BaseModel where TDestination : BaseDto
    {
        private readonly IMapper _mapper;
        public BaseModelToDtoMapper(IMapper mapper){
            _mapper=mapper;
        }
        /// <summary>
        /// Enumerable BaseModel to DTO mapper
        /// </summary>
        public IEnumerable<TDestination> Map(IEnumerable<TSource> sources)
        {
            return sources.Select(this.Map);
        }

        /// <summary>
        /// Maps model to dto
        /// </summary>
        public TDestination Map(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}
