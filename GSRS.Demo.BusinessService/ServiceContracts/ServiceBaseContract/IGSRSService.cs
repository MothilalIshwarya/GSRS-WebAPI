using GSRS.Service.Models;
using GSRS.Service.ServiceContracts;

namespace GSRS.Demo.BusinessService.ServiceContracts.ServiceBaseContract
{
    public interface IGSRSService<TEntity> : IBaseAsyncService<TEntity> where TEntity : BaseModel
    {
    }
}
