using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSRS.Demo.BusinessService.Context;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.Repository.RepositoryBase;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Service.ContextContracts;
using GSRS.Service.ModelContracts;
using Microsoft.EntityFrameworkCore;

namespace GSRS.Demo.BusinessService.Repository
{
    public class ModContractRepository : GSRSRepository<ModContract>, IModContractRepository
    {
        #region Constructor
        private readonly IBaseContext context;

        public ModContractRepository(IContext _context)
            : base(_context)
        {
            context = _context;
        }
        #endregion
        protected virtual IQueryable<ModContract> Query
        {

            get { return context.SetQuery<ModContract>(); }
        }
        //getall override method
        public override Task<Dictionary<int, ModContract>> SearchUnrestrictedAsync(ISearchCondition<ModContract> searchCondition)
        {
            // Get base tenant agnostic query
            var entities = Query.AsNoTracking();

            if (searchCondition != null)
            {
                // Include search condition predicate
                entities = Query.Where(searchCondition.Predicate).Include(x => x.Agreement);
            }
            else
            {
                entities = Query.Include(x => x.Agreement);
            }
            // Execute query and convert results to a dictionary 
            var result = entities.ToDictionary(x => x.Id, x => x);

            return Task.FromResult(result);
        }

        //getbyid override method
        public override Task<ModContract> FetchAsync(int id, bool isTracked = true)
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
        private Task<ModContract> FetchEntityByIdAsync(int id)
        {
            // Query includes tenant check
            //var result = Query.Include(x => x.ModContract).FirstOrDefaultAsync(x => x.Id == id);
            //var result = Query.Include("ModContract.ModContract").Include("ModContract.LicServerGroup").Where(x => x.Id == id).ToList();
            var entities = Query.Include(x => x.Agreement);
            var result = entities.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
// #endregion