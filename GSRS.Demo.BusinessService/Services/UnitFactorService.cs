using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.BusinessService.Services.ServiceBase;

namespace GSRS.Demo.BusinessService.Services
{
    public class UnitFactorService : GSRSService<UnitFactor> , IUnitFactorService
    {
        #region Constructor
        public UnitFactorService(IUnitFactorRepository _repository) 
            : base(_repository)
        { }
        #endregion
    }
}