using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.BusinessService.Services.ServiceBase;

namespace GSRS.Demo.BusinessService.Services
{
    public class ProductService : GSRSService<Product> , IProductService
    {
        #region Constructor
        public ProductService(IProductRepository _repository) 
            : base(_repository)
        { }
        #endregion
    }
}