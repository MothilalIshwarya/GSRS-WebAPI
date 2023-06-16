using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.Infrastructure.Dtos;

namespace GSRS.Demo.WebAPI.IntegrationTesting.MockData
{
    public class ProductGroupMock
    {
        public static List<ProductGroup> ProductGroupList()
        {
            return new List<ProductGroup>{
                new ProductGroup(){
                    AgreementId= 1,
                    UnitFactorId= 1,
                    ProductGroupCode= "PGC123",
                    ProductGroupName= "Product 1",
                    CostModelId= 1,
                    AccountByGroup= 0,
                    Comment= "Product 1 price is fixed",
                    Enabled= 1,
                    Graceperiod= 0,
                    SupportgroupId= 0,
                    Id= 1,
                    DateCreated= new DateTime(2020, 09, 03),
                    DateChanged= new DateTime(2020, 09, 03),
                    ChangedBy= "iswarya.mothilal"
                },
                new ProductGroup(){
                    AgreementId= 1,
                    UnitFactorId= 4,
                    ProductGroupCode= "PGC124",
                    ProductGroupName= "Product 2",
                    CostModelId= 1,
                    AccountByGroup= 1,
                    Comment= "",
                    Enabled= 0,
                    Graceperiod= 7,
                    SupportgroupId= 5,
                    Id= 2,
                    DateCreated= new DateTime(2020, 09, 03),
                    DateChanged= new DateTime(2020, 09, 03),
                    ChangedBy= "iswarya.mothilal"
                }

            };
        }
        public static ProductGroup CreateProductGroup()
        {
            return new ProductGroup
            {
                AgreementId = 1,
                UnitFactorId = 1,
                ProductGroupCode = "PGC123",
                ProductGroupName = "Product 1",
                CostModelId = 1,
                AccountByGroup = 0,
                Comment = "Product 1 price is fixed",
                Enabled = 1,
                Graceperiod = 0,
                SupportgroupId = 0,
                Id = 1,
                DateCreated = new DateTime(2020, 09, 03),
                DateChanged = new DateTime(2020, 09, 03),
                ChangedBy = "iswarya.mothilal"
            };
        }
        public static ProductGroup UpdateProductGroup()
        {
            return new ProductGroup
            {
                AgreementId = 1,
                UnitFactorId = 1,
                ProductGroupCode = "PGC123",
                ProductGroupName = "Product 1",
                CostModelId = 1,
                AccountByGroup = 0,
                Comment = "Product 1 price is fixed",
                Enabled = 1,
                Graceperiod = 0,
                SupportgroupId = 0,
                Id = 1,
                DateCreated = new DateTime(2020, 09, 03),
                DateChanged = new DateTime(2020, 09, 03),
                ChangedBy = "iswarya.mothilal"
            };
        }
        public static ProductGroupDto UpdateProductGroupDto()
        {
            return new ProductGroupDto
            {
                AgreementId = 1,
                UnitFactorId = 1,
                ProductGroupCode = "PGC123",
                ProductGroupName = "Product 1",
                CostModelId = 1,
                AccountByGroup = 0,
                Comment = "Product 1 price is fixed",
                Enabled = 1,
                Graceperiod = 0,
                SupportgroupId = 0,
                Id = 1,
                DateCreated = new DateTime(2020, 09, 03),
                DateChanged = new DateTime(2020, 09, 03),
                ChangedBy = "iswarya.mothilal",
                Description_Agreement = "MS Office Applications",
                Description_UnitFactor = "Units per day/use",
                Description_CostModel = "Fixed Price"
            };
        }
        public static ProductGroupDto CreateProductGroupDto()
        {
            return new ProductGroupDto
            {
                AgreementId = 1,
                UnitFactorId = 1,
                ProductGroupCode = "PGC123",
                ProductGroupName = "Product 1",
                CostModelId = 1,
                AccountByGroup = 0,
                Comment = "Product 1 price is fixed",
                Enabled = 1,
                Graceperiod = 0,
                SupportgroupId = 0,
                Id = 0,
                DateCreated = new DateTime(2020, 09, 03),
                DateChanged = new DateTime(2020, 09, 03),
                ChangedBy = "iswarya.mothilal",
                Description_Agreement = "MS Office Applications",
                Description_UnitFactor = "Units per day/use",
                Description_CostModel = "Fixed Price"
            };
        }

        public static List<ProductGroup> EmptyList()
        {
            return new List<ProductGroup>
            {
            };
        }
        public static ProductGroup NullProductgroup()
        {
            return null;
        }


    }

}