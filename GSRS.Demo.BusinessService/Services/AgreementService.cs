using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.BusinessService.Services.ServiceBase;

namespace GSRS.Demo.BusinessService.Services
{
    public class AgreementService : GSRSService<Agreement> , IAgreementService
    {
        #region Constructor
        public AgreementService(IAgreementRepository _repository) 
            : base(_repository)
        { }
        #endregion
    }
}