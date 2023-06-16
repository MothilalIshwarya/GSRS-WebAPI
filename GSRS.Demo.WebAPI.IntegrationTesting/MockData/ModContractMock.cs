using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.Infrastructure.Dtos;

namespace GSRS.Demo.WebAPI.IntegrationTesting.MockData
{
    public static class ModContractMock
    {
        public static List<ModContract> GetAllModContract()
        {
            return new List<ModContract>(){
                new ModContract(){
                    AgreementId= 1,
                    DateStart= new DateTime(2020, 09, 03),
                    DateEnd= new DateTime(2020, 09, 03),
                    ContractValue= 177.9,
                    Comment= "string",
                    Id= 1,
                    DateCreated= new DateTime(2020, 09, 03),
                    DateChanged=  new DateTime(2020, 09, 03),
                    ChangedBy= "iswarya.mothilal"

                },
                  new ModContract(){
                    AgreementId= 1,
                    DateStart= new DateTime(2020, 09, 03),
                    DateEnd= new DateTime(2020, 09, 03),
                    ContractValue= 177.9,
                    Comment= "string",
                    Id= 2,
                    DateCreated= new DateTime(2020, 09, 03),
                    DateChanged=  new DateTime(2020, 09, 03),
                    ChangedBy= "iswarya.mothilal"

                },
            };
        }
        public static ModContract GetModContract()
        {
            return new ModContract
            {
                AgreementId = 1,
                DateStart = new DateTime(2020, 09, 03),
                DateEnd = new DateTime(2020, 09, 03),
                ContractValue = 177.9,
                Comment = "string",
                Id = 1,
                DateCreated = new DateTime(2020, 09, 03),
                DateChanged = new DateTime(2020, 10, 03),
                ChangedBy = "iswarya.mothilal"
            };
        }
        public static ModContractDto createModContractDto()
        {
            return new ModContractDto
            {

                Id = 0,
                DateCreated = new DateTime(2020, 09, 03),
                DateChanged = new DateTime(2020, 10, 03),
                ChangedBy = "string",
                AgreementId = 1,
                DateStart = new DateTime(2020, 09, 03),
                DateEnd = new DateTime(2020, 10, 03),
                ContractValue = 120,
                Comment = "string"

            };
        }
        public static ModContractDto createModContractDtoInvalidEnddate()
        {
            return new ModContractDto
            {

                Id = 0,
                DateCreated = new DateTime(2020, 09, 03),
                DateChanged = new DateTime(2020, 09, 03),
                ChangedBy = "string",
                AgreementId = 1,
                DateStart = new DateTime(2020, 09, 03),
                DateEnd = new DateTime(2020, 08, 02),
                ContractValue = 120,
                Comment = "string"

            };
        }
        public static ModContract createModContract()
        {
            return new ModContract
            {

                Id = 0,
                DateCreated = new DateTime(2020, 09, 03),
                DateChanged = new DateTime(2020, 09, 03),
                ChangedBy = "string",
                AgreementId = 1,
                DateStart = new DateTime(2020, 09, 03),
                DateEnd = new DateTime(2020, 10, 03),
                ContractValue = 120,
                Comment = "string"

            };
        }
        public static ModContractDto UpdateModContractDto(){
            return new ModContractDto{
                Id = 1,
                DateCreated = new DateTime(2020, 09, 03),
                DateChanged = new DateTime(2020, 09, 03),
                ChangedBy = "string",
                AgreementId = 1,
                DateStart = new DateTime(2020, 09, 03),
                DateEnd = new DateTime(2020, 10, 03),
                ContractValue = 120,
                Comment = "string"
            };
        }
         public static ModContractDto UpdateModContractDtoInvalidId(){
            return new ModContractDto{
                Id = 10,
                DateCreated = new DateTime(2020, 09, 03),
                DateChanged = new DateTime(2020, 09, 03),
                ChangedBy = "string",
                AgreementId = 1,
                DateStart = new DateTime(2020, 09, 03),
                DateEnd = new DateTime(2020, 10, 03),
                ContractValue = 120,
                Comment = "string"
            };
        }
         public static ModContract UpdateModContract(){
            return new ModContract{
                Id = 1,
                DateCreated = new DateTime(2020, 09, 03),
                DateChanged = new DateTime(2020, 09, 03),
                ChangedBy = "string",
                AgreementId = 1,
                DateStart = new DateTime(2020, 09, 03),
                DateEnd = new DateTime(2020, 10, 03),
                ContractValue = 120,
                Comment = "string"
            };
        }
        
        public static Dictionary<int,ModContract> ModContractDictionary(){
            return new Dictionary<int, ModContract>{};
        }
        public static List<ModContract> EmptyModContractList(){
            return new List<ModContract>{};
        }
        public static ModContract EmptyModContract(){
            return new ModContract();
        }
    }
}