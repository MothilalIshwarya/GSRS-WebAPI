using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.BusinessService.Services.ServiceBase;

namespace GSRS.Demo.BusinessService.Services
{
    public class LicenseTypeService : GSRSService<LicenseType> , ILicenseTypeService
    {
        #region Constructor
        public LicenseTypeService(ILicenseTypeRepository _repository) 
            : base(_repository)
        { }
        #endregion
    }
}