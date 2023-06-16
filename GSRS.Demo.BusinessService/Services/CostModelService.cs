using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.BusinessService.Services.ServiceBase;

namespace GSRS.Demo.BusinessService.Services
{
    public class CostModelService : GSRSService<CostModel> , ICostModelService
    {
        #region Constructor
        public CostModelService(ICostModelRepository _repository) 
            : base(_repository)
        { }
        #endregion
    }
}