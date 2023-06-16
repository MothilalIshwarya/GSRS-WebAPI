using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSRS.Service.ModelContracts;
using GSRS.Service.Models;
using GSRS.Service.RepositoryContracts;
using Moq;
using GSRS.Service.ServiceContracts;
using GSRS.Demo.BusinessService.Services;

namespace GSRS.Demo.WebAPI.IntegrationTesting.Service
{
    public class CostModelServiceTest
    {
        private Mock<IBaseRepositoryAsync<BaseModel>> _dal=new Mock<IBaseRepositoryAsync<BaseModel>>();
        private CostModelService _costModelService;
        public CostModelServiceTest(){
           

        }
    }
}