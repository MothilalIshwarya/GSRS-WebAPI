using GSRS.Demo.BusinessService.Context;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.Repository.RepositoryBase;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Service.ContextContracts;
using GSRS.Service.ModelContracts;
using Microsoft.EntityFrameworkCore;

namespace GSRS.Demo.BusinessService.Repository
{
    public class ProductGroupRepository : GSRSRepository<ProductGroup>, IProductGroupRepository
    {
        #region Constructor
        private readonly IBaseContext context;
        public ProductGroupRepository(IContext _context)
            : base(_context)
        { 
            context = _context;
        }
        #endregion
        protected virtual IQueryable<ProductGroup> Query
        {

            get { return context.SetQuery<ProductGroup>(); }
        }

        //getall override method
        public override Task<Dictionary<int, ProductGroup>> SearchUnrestrictedAsync(ISearchCondition<ProductGroup> searchCondition)
        {
            var entities = Query.AsNoTracking();

            if (searchCondition != null)
            {
                // Include search condition predicate
                entities = Query.Where(searchCondition.Predicate).Include(x=>x.Agreement).Include(x=>x.CostModel).Include(x=>x.UnitFactor);
            }
            else{
                entities = Query.Include(x=>x.Agreement).Include(x=>x.UnitFactor).Include(x=>x.CostModel);
            }
            // Execute query and convert results to a dictionary 
            var result = entities.ToDictionary(x => x.Id, x => x);

            return Task.FromResult(result);
        }

        public override Task<ProductGroup> FetchAsync(int id, bool isTracked = true)
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
        private Task<ProductGroup> FetchEntityByIdAsync(int id)
        {
            var entities = Query.Include(x=>x.Agreement).Include(x=>x.UnitFactor).Include(x=>x.CostModel);
            var result = entities.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        //soft delete : set enable as false/true
         public override async Task SoftDeleteAsync(ProductGroup entity)
        {
            // Fetch the existing entity
            var deletedTEntity = Query.FirstOrDefault(x => x.Id == entity.Id);
            if (deletedTEntity != null)
            {
                // Set status to false
                deletedTEntity.Enabled = (deletedTEntity.Enabled == 0) ? 1 : 0;                
                // Mark entity as modified
                Context.SetModified(deletedTEntity);
                // Commit context changes
                await Context.SaveChangesAsync();
            }
        }
    }
}