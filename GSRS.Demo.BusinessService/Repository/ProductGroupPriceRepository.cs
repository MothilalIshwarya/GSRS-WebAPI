using GSRS.Demo.BusinessService.Context;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.Repository.RepositoryBase;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Service.Context;
using GSRS.Service.ContextContracts;
using GSRS.Service.ModelContracts;
using Microsoft.EntityFrameworkCore;

namespace GSRS.Demo.BusinessService.Repository
{
    public class ProductGroupPriceRepository : GSRSRepository<ProductGroupPrice>, IProductGroupPriceRepository
    {
        #region Constructor
        private readonly IBaseContext context;
        public ProductGroupPriceRepository(IContext _context)
            : base(_context)
        {
            context = _context;
        }
        #endregion
        protected virtual IQueryable<ProductGroupPrice> Query
        {

            get { return context.SetQuery<ProductGroupPrice>(); }
        }

        //getall override method
        public override Task<Dictionary<int, ProductGroupPrice>> SearchUnrestrictedAsync(ISearchCondition<ProductGroupPrice> searchCondition)
        {
            // Get base tenant agnostic query
            var entities = Query.AsNoTracking();

            if (searchCondition != null)
            {
                // Include search condition predicate
                entities = Query.Where(searchCondition.Predicate);
            }
            else
            {
                entities = Query.Include(x => x.ProductGroup).Include(x => x.LicServerGroup);
            }
            // Execute query and convert results to a dictionary 
            var result = entities.ToDictionary(x => x.Id, x => x);

            return Task.FromResult(result);
        }

        //getbyid override method
        public override Task<ProductGroupPrice> FetchAsync(int id, bool isTracked = true)
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
        private Task<ProductGroupPrice> FetchEntityByIdAsync(int id)
        {

            var entities = Query.Include(x => x.ProductGroup).Include(x => x.LicServerGroup);
            var result = entities.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<bool> CreatListeAsync(List<ProductGroupPrice> entity)
        {
            foreach (var items in entity)  {
            var result = (IEnumerable<dynamic>)GetProductGroupPricesByProductGroupId(items.ProductGroupId);
                foreach(var item in result){
                    if(items.ProductGroupId==item.ProductGroupId){
                        items.LicServerGroupId=item.LicServerGroupId;
                    }

                }
                if(items.LicServerGroupId==0){
                    throw new Exception("some inputs are wrong");
                }
            }

            

                 Console.WriteLine(entity);
                 DbSet.AddRange(entity);
                // // Commit context changes
                  await Context.SaveChangesAsync();
                return true;
            }

            public object GetProductGroupPricesByProductGroupId(int productGroupId)
            {
                var query = from lt in context.SetQuery<LicenseType>()
                            join ls in context.SetQuery<LicenseServer>() on lt.Id equals ls.LicTypeId
                            join p in context.SetQuery<Product>() on lt.Id equals p.LicTypeId
                            join pg in context.SetQuery<ProductGroup>() on p.ProductGroupId equals pg.Id
                            join cm in context.SetQuery<CostModel>() on pg.CostModelId equals cm.Id
                            where pg.Enabled == 1  && pg.Id==productGroupId
                            orderby p.Id
                            select new
                            {
                                LicServerGroupId = ls.LicServerGroupId,
                                ProductGroupId = pg.Id,
                                ProductId = p.Id,
                                ProductDisplayName = p.DisplayName,
                                ProductGroupName = pg.ProductGroupName,
                                CostModelId = pg.CostModelId,
                                CostModelName = cm.CostModelName,
                                AgreementId = pg.AgreementId

                            };
                return query.ToList();

            }




        }
    }