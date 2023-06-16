using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.RepositoryContracts.RepositoryBaseContract;

namespace GSRS.Demo.BusinessService.RepositoryContracts
{
    public interface IProductGroupPriceRepository : IGSRSRepository<ProductGroupPrice>
    {
               Task<bool> CreatListeAsync(List<ProductGroupPrice> entity);

    }
}
