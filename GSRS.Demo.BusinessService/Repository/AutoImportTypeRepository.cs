using GSRS.Demo.BusinessService.Context;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.Repository.RepositoryBase;
using GSRS.Demo.BusinessService.RepositoryContracts;

namespace GSRS.Demo.BusinessService.Repository
{
    public class AutoImportTypeRepository : GSRSRepository<AutoImportType>, IAutoImportTypeRepository
    {
        #region Constructor
        public AutoImportTypeRepository(IContext _context)
            : base(_context)
        { }
        #endregion
    }
}