using GSRS.Demo.BusinessService.Context;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.Repository.RepositoryBase;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Service.ContextContracts;
using GSRS.Service.ModelContracts;
using Microsoft.EntityFrameworkCore;

namespace GSRS.Demo.BusinessService.Repository
{
    public class LicenseServerRepository : GSRSRepository<LicenseServer>, ILicenseServerRepository
    {
        #region Constructor
        private readonly IBaseContext context;
        public LicenseServerRepository(IContext _context)
            : base(_context)
        { 
            context = _context;
        }
        #endregion
        protected virtual IQueryable<LicenseServer> Query
        {

            get { return context.SetQuery<LicenseServer>(); }
        }

        //getall override method
        public override Task<Dictionary<int, LicenseServer>> SearchUnrestrictedAsync(ISearchCondition<LicenseServer> searchCondition)
        {
            // Get base tenant agnostic query
            var entities = Query.AsNoTracking();

            if (searchCondition != null)
            {
                // Include search condition predicate
                entities = Query.Where(searchCondition.Predicate);
            }
            else{
                entities = Query.Include(x=>x.LicServerGroup).Include(x=>x.LicType).Include(x=>x.AutoImportType);
            }
            // Execute query and convert results to a dictionary 
            var result = entities.ToDictionary(x => x.Id, x => x);

            return Task.FromResult(result);
        }

        //getbyid override method
        public override Task<LicenseServer> FetchAsync(int id, bool isTracked = true)
        {
            // For already existing entity validations
            if (!isTracked)
            {
                // Get the untracked entity from context
                var result = Query.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                return result;
            }
            // Fetch the existing entity by Id
            return FetchEntityByIdAsync(id);
        }
        private Task<LicenseServer> FetchEntityByIdAsync(int id)
        {
            // Query includes tenant check
            //var result = Query.Include(x => x.ProductGroup).FirstOrDefaultAsync(x => x.Id == id);
            //var result = Query.Include("LicenseServer.ProductGroup").Include("LicenseServer.LicServerGroup").Where(x => x.Id == id).ToList();
            var entities = Query.Include(x=>x.LicServerGroup).Include(x=>x.LicType).Include(x=>x.AutoImportType);
            var result = entities.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}