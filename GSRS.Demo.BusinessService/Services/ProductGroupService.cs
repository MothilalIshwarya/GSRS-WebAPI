using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.BusinessService.Services.ServiceBase;

namespace GSRS.Demo.BusinessService.Services
{
    public class ProductGroupService : GSRSService<ProductGroup> , IProductGroupService
    {
        #region Constructor
        public ProductGroupService(IProductGroupRepository _repository) 
            : base(_repository)
        { }
        #endregion
    }
}