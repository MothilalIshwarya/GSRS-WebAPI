using GSRS.Demo.BusinessService.RepositoryContracts.RepositoryBaseContract;
using GSRS.Demo.BusinessService.ServiceContracts.ServiceBaseContract;
using GSRS.Service.Models;
using GSRS.Service.Services;

namespace GSRS.Demo.BusinessService.Services.ServiceBase
{
    /// <summary>
    /// Class Service.
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="Service.Services.BaseAsyncService{TEntity}" />
    /// <seealso cref="ServiceContracts.ServiceBaseContract.IGSRSService{TEntity}" />
    public class GSRSService<TEntity> : BaseAsyncService<TEntity>, IGSRSService<TEntity> where TEntity : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Service{TEntity}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public GSRSService(IGSRSRepository<TEntity> repository) : base(repository)
        {
        }

     
    }
}
