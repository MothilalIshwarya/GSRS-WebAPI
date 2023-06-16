using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.BusinessService.Services.ServiceBase;

namespace GSRS.Demo.BusinessService.Services
{
    public class ProductGroupPriceService : GSRSService<ProductGroupPrice> , IProductGroupPriceService
    {
        #region Constructor
        private readonly IProductGroupPriceRepository Dal;

        public ProductGroupPriceService(IProductGroupPriceRepository _repository) 
            : base(_repository)
            
        { 
            Dal=_repository;
            // _repository=Dal;
        }
        public async Task<bool> CreateListAsync(List<ProductGroupPrice> entity)
        {
            // Populate audit fields
            SetCreateAuditField(entity);
            await Dal.CreatListeAsync(entity);
            return true;
            // return result;
        }
         protected virtual void SetCreateAuditField(List<ProductGroupPrice> entity)
        {
           for(int i=0;i<entity.Count;i++){
            entity[i].DateCreated = DateTime.UtcNow;
            //entity.ChangedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            entity[i].ChangedBy = Environment.UserName;
           }
        }
        #endregion
    }
}