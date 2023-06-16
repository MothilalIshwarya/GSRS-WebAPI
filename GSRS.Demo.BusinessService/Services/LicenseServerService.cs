using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.BusinessService.Services.ServiceBase;

namespace GSRS.Demo.BusinessService.Services
{
    public class LicenseServerService : GSRSService<LicenseServer> , ILicenseServerService
    {
        #region Constructor
        public LicenseServerService(ILicenseServerRepository _repository) 
            : base(_repository)
        { }
        #endregion
    }
}