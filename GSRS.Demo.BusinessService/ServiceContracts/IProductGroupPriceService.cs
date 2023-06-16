using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.ServiceContracts.ServiceBaseContract;

namespace GSRS.Demo.BusinessService.ServiceContracts
{
    public interface IProductGroupPriceService : IGSRSService<ProductGroupPrice>
    {
         Task<bool> CreateListAsync(List<ProductGroupPrice> entity);
    }
}
