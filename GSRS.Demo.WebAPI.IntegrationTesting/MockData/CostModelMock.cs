using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.Infrastructure.Dtos;

namespace GSRS.Demo.WebAPI.IntegrationTesting.MockData
{
    public static class CostModelMock
    {
        public static List<CostModel> GetAllCostModel()
        {
            return new List<CostModel>(){
                new CostModel(){
                    CostModelName= "fixed",
                    Description= "Price is fixed for unit",
                    Id= 1,
                    DateCreated= new DateTime(2020, 09, 03),
                    DateChanged= new DateTime(2020, 09, 03),
                    ChangedBy= "iswarya.mothilal"
                },
                new CostModel(){
                    CostModelName= "Variable",
                    Description= "Price is Variable for unit",
                    Id= 2,
                    DateCreated= new DateTime(2020, 09, 03),
                    DateChanged= new DateTime(2020, 09, 03),
                    ChangedBy= "iswarya.mothilal"
                }

            };
        }
        public static CostModel GetCostModel()
        {
            return new CostModel
            {
                CostModelName = "fixed",
                Description = "Price is fixed for unit",
                Id = 1,
                DateCreated = new DateTime(2020, 09, 03),
                DateChanged = new DateTime(2020, 09, 03),
                ChangedBy = "iswarya.mothilal"
            };
        }
        // public static CostModel createcostmodelDto(){
        //     return new CostModel{
        //          CostModelName= "Variable",
        //             Description= "Price is Variable for unit"
        //     };
        // }
        public static CostModelDto createcostmodelDto()
        {
            return new CostModelDto
            {
                CostModelName = "Variable",
                Description = "Price is Variable for unit",
                Id = 0,
                DateCreated = new DateTime(2020, 09, 03),
                DateChanged = new DateTime(2020, 09, 03),
                ChangedBy = "iswarya.mothilal"
            };
        }
        public static CostModelDto upadtecostmodelDto()
        {
            return new CostModelDto
            {
                CostModelName = "Variable",
                Description = "Price is Variable for unit",
                Id = 1,
                DateCreated = new DateTime(2020, 09, 03),
                DateChanged = new DateTime(2020, 09, 03),
                ChangedBy = "iswarya.mothilal"
            };
        }
         public static CostModelDto upadtecostmodelDtoInvalidId()
        {
            return new CostModelDto
            {
                CostModelName = "Variable",
                Description = "Price is Variable for unit",
                Id = 10,
                DateCreated = new DateTime(2020, 09, 03),
                DateChanged = new DateTime(2020, 09, 03),
                ChangedBy = "iswarya.mothilal"
            };
        }
        public static CostModel upadtecostmodel()
        {
            return new CostModel
            {
                CostModelName = "Variable",
                Description = "Price is Variable for unit",
                Id = 1,
                DateCreated = new DateTime(2020, 09, 03),
                DateChanged = new DateTime(2020, 09, 03),
                ChangedBy = "iswarya.mothilal"
            };
        }
        public static CostModel createcostmodel()
        {
            return new CostModel
            {
                CostModelName = "Variable",
                Description = "Price is Variable for unit",
                Id = 0,
                DateCreated = new DateTime(2020, 09, 03),
                DateChanged = new DateTime(2020, 09, 03),
                ChangedBy = "iswarya.mothilal"
            };
        }
        public static Dictionary<int,CostModel> ProductGroupDictionary(){
            return new Dictionary<int, CostModel>{};
        }
        public static List<CostModel> EmptyCostmodelList()
        {
            return new List<CostModel>
            {

            };
        }
        // public static CostModel sample()
        // {
        //     return new CostModel { };
        // }
        public static CostModelDto sampleDto()
        {
            return new CostModelDto {
                CostModelName = null,
                Description = null,
                Id = 0
             };
        }
       
    }
}