using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.BusinessService.Services.ServiceBase;

namespace GSRS.Demo.BusinessService.Services
{
    public class UnitDefinitionService : GSRSService<UnitDefinition> , IUnitDefinitionService
    {
        #region Constructor
        public UnitDefinitionService(IUnitDefinitionRepository _repository) 
            : base(_repository)
        { }
        #endregion
    }
}