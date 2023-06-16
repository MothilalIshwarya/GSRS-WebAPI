using GSRS.Demo.BusinessService.Context;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.Repository.RepositoryBase;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Service.ContextContracts;
using GSRS.Service.ModelContracts;
using Microsoft.EntityFrameworkCore;

namespace GSRS.Demo.BusinessService.Repository
{
    public class ProductRepository : GSRSRepository<Product>, IProductRepository
    {
        #region Constructor
        private readonly IBaseContext context;
        public ProductRepository(IContext _context)
            : base(_context)
        {
            context = _context;
         }
        #endregion
        protected virtual IQueryable<Product> Query
        {

            get { return context.SetQuery<Product>(); }
        }

        //getall override method
        public override Task<Dictionary<int, Product>> SearchUnrestrictedAsync(ISearchCondition<Product> searchCondition)
        {
            // Get base tenant agnostic query
            var entities = Query.AsNoTracking();

            if (searchCondition != null)
            {
                // Include search condition predicate
                entities = Query.Where(searchCondition.Predicate);
            }
            else{
                entities = Query.Include(x=>x.ProductGroup).Include(x=>x.LicType);
            }
            // Execute query and convert results to a dictionary 
            var result = entities.ToDictionary(x => x.Id, x => x);

            return Task.FromResult(result);
        }

        //getbyid override method
        public override Task<Product> FetchAsync(int id, bool isTracked = true)
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
        private Task<Product> FetchEntityByIdAsync(int id)
        {
            // Query includes tenant check
            //var result = Query.Include(x => x.ProductGroup).FirstOrDefaultAsync(x => x.Id == id);
            //var result = Query.Include("Product.ProductGroup").Include("Product.LicServerGroup").Where(x => x.Id == id).ToList();
            var entities = Query.Include(x=>x.ProductGroup).Include(x=>x.LicType);
            var result = entities.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
          public override async Task SoftDeleteAsync(Product entity)
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