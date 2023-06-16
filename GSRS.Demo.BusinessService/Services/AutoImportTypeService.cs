using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.BusinessService.Services.ServiceBase;

namespace GSRS.Demo.BusinessService.Services
{
    public class AutoImportTypeService : GSRSService<AutoImportType> , IAutoImportTypeService
    {
        #region Constructor
        public AutoImportTypeService(IAutoImportTypeRepository _repository) 
            : base(_repository)
        { }
        #endregion
    }
}