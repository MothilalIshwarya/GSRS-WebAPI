using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.BusinessService.Services.ServiceBase;

namespace GSRS.Demo.BusinessService.Services
{
    public class LicenseServerGroupService : GSRSService<LicenseServerGroup> , ILicenseServerGroupService
    {
        #region Constructor
        public LicenseServerGroupService(ILicenseServerGroupRepository _repository) 
            : base(_repository)
        { }
        #endregion
    }
}