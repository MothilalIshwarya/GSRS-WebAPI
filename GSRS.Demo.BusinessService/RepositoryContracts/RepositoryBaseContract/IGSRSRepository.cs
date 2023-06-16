using GSRS.Service.Models;
using GSRS.Service.RepositoryContracts;

namespace GSRS.Demo.BusinessService.RepositoryContracts.RepositoryBaseContract
{
    public interface IGSRSRepository<TEntity> : IBaseRepositoryAsync<TEntity> where TEntity : BaseModel
    {
    }
}
