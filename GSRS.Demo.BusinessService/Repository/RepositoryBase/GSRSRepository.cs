using GSRS.Service.Models;
using GSRS.Service.Repository;
using GSRS.Demo.BusinessService.Context;
using GSRS.Demo.BusinessService.RepositoryContracts.RepositoryBaseContract;

namespace GSRS.Demo.BusinessService.Repository.RepositoryBase
{
    /// <summary>
    /// Class Repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="Context.BaseRepositoryAsync{TEntity}" />
    /// <seealso cref="RepositoryContracts.RepositoryBaseContract.IGSRSRepository{TEntity}" />
    public class GSRSRepository<TEntity> : BaseRepositoryAsync<TEntity>, IGSRSRepository<TEntity> where TEntity : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GSRSRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="_context">The context.</param>
        public GSRSRepository(IContext _context) : base(_context)
        {
        }
    }
}
