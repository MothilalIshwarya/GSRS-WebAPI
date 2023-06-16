using AutoMapper;
using GSRS.Api.BaseMapperContracts;
using GSRS.Api.Dtos;
using GSRS.Service.Models;

namespace GSRS.Api.BaseMappers
{
    public class BaseDtoToModelMapper<TSource, TDestination> : IBaseDtoToModelMapper<TSource, TDestination>
        where TSource : BaseDto where TDestination : BaseModel
    {
        private readonly IMapper _mapper;
        public BaseDtoToModelMapper(IMapper mapper){
            _mapper=mapper;
        }
        /// <summary>
        /// Enumerable BaseDto to Model mapper
        /// </summary>
        public IEnumerable<TDestination> Map(IEnumerable<TSource> sources)
        {
            return sources.Select(this.Map);
        }
        /// <summary>
        /// Maps dto to model
        /// </summary>
        public TDestination Map(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }

        
    }
}
