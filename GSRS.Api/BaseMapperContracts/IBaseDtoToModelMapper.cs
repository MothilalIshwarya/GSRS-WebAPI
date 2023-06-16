using GSRS.Api.Dtos;
using GSRS.Service.Models;

namespace GSRS.Api.BaseMapperContracts
{

    /// <summary>
    /// Interface for base dto to model mapper
    /// </summary>
    public interface IBaseDtoToModelMapper<TSource, TDestination>
        where TSource : BaseDto where TDestination : BaseModel
    {
        /// <summary>
        /// Maps Dtos to Models
        /// </summary>
        IEnumerable<TDestination> Map(IEnumerable<TSource> sources);
        
        /// <summary>
        /// Maps Dto to Model
        /// </summary>
        TDestination Map(TSource source);
    }
}
