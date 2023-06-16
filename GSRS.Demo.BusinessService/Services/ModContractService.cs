using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.BusinessService.Services.ServiceBase;

namespace GSRS.Demo.BusinessService.Services
{
    public class ModContractService : GSRSService<ModContract> , IModContractService
    {
        #region Constructor
        public ModContractService(IModContractRepository _repository) 
            : base(_repository)
        { }
        
        #endregion
    }
}