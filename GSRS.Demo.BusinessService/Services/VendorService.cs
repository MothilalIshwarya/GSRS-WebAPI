using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.BusinessService.Services.ServiceBase;

namespace GSRS.Demo.BusinessService.Services
{
    public class VendorService : GSRSService<Vendor> , IVendorService
    {
        #region Constructor
        public VendorService(IVendorRepository _repository) 
            : base(_repository)
        { }
        #endregion
    }
}