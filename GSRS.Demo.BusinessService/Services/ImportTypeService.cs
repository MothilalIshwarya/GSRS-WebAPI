using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.BusinessService.Services.ServiceBase;

namespace GSRS.Demo.BusinessService.Services
{
    public class ImportTypeService : GSRSService<ImportType> , IImportTypeService
    {
        #region Constructor
        public ImportTypeService(IImportTypeRepository _repository) 
            : base(_repository)
        { }
        #endregion
    }
}