using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.Infrastructure.Dtos;

namespace GSRS.Demo.WebAPI.IntegrationTesting.MockData
{
    public class ProductGroupPriceMock
    {
        public static List<ProductGroupPrice> GetAllProductGroupPrice()
        {
            return new List<ProductGroupPrice>(){
                new ProductGroupPrice(){
                   ProductGroupId= 1,
                    LicServerGroupId= 1,
                    DateStart=new DateTime(2020, 09, 03),
                    DateEnd= new DateTime(2020, 10, 03),
                    PriceContract= 10,
                    PricePerUnit= 0,
                    CostFactor= 0,
                    Enabled= true,
                    MacComment= "string",
                    Description= "string",
                    // ProductGroupName= "Product 1",
                    // ServerGroupName= "string",
                    Id= 1,
                    DateCreated= new DateTime(2020, 09, 03),
                    DateChanged= new DateTime(2020, 10, 03),
                    ChangedBy= "iswarya.mothilal"

                },
                  new ProductGroupPrice(){
                     ProductGroupId= 1,
                    LicServerGroupId= 1,
                    DateStart=new DateTime(2020, 09, 03),
                    DateEnd= new DateTime(2020, 10, 03),
                    PriceContract= 10,
                    PricePerUnit= 0,
                    CostFactor= 0,
                    Enabled= true,
                    MacComment= "string",
                    Description= "string",
                    // ProductGroupName= "Product 1",
                    // ServerGroupName= "string",
                    Id= 2,
                    DateCreated= new DateTime(2020, 09, 03),
                    DateChanged= new DateTime(2020, 10, 03),
                    ChangedBy= "iswarya.mothilal"
                },
            };
        }
        public static ProductGroupPrice GetProductGroupPrice()
        {
            return new ProductGroupPrice
            {
                 ProductGroupId= 1,
                    LicServerGroupId= 1,
                    DateStart=new DateTime(2020, 09, 03),
                    DateEnd= new DateTime(2020, 10, 03),
                    PriceContract= 10,
                    PricePerUnit= 0,
                    CostFactor= 0,
                    Enabled= true,
                    MacComment= "string",
                    Description= "string",
                    // ProductGroupName= "Product 1",
                    // ServerGroupName= "string",
                    Id= 4,
                    DateCreated= new DateTime(2020, 09, 03),
                    DateChanged= new DateTime(2020, 10, 03),
                    ChangedBy= "iswarya.mothilal"
            };
        }
        public static List<ProductGroupPriceDto> createProductGroupPriceDto()
        {
             return new List<ProductGroupPriceDto>(){
                new ProductGroupPriceDto(){
                   ProductGroupId= 1,
                    LicServerGroupId= 1,
                    DateStart=new DateTime(2020, 09, 03),
                    DateEnd= new DateTime(2020, 10, 03),
                    PriceContract= 10,
                    PricePerUnit= 0,
                    CostFactor= 0,
                    Enabled= true,
                    MacComment= "string",
                    Description= "string",
                    ProductGroupName= "Product 1",
                    ServerGroupName= "string",
                    Id= 1,
                    DateCreated= new DateTime(2020, 09, 03),
                    DateChanged= new DateTime(2020, 10, 03),
                    ChangedBy= "iswarya.mothilal"

                },
                  new ProductGroupPriceDto(){
                     ProductGroupId= 1,
                    LicServerGroupId= 1,
                    DateStart=new DateTime(2020, 09, 03),
                    DateEnd= new DateTime(2020, 10, 03),
                    PriceContract= 10,
                    PricePerUnit= 0,
                    CostFactor= 0,
                    Enabled= true,
                    MacComment= "string",
                    Description= "string",
                    ProductGroupName= "Product 1",
                    ServerGroupName= "string",
                    Id= 2,
                    DateCreated= new DateTime(2020, 09, 03),
                    DateChanged= new DateTime(2020, 10, 03),
                    ChangedBy= "iswarya.mothilal"
                },
            };
        }
        public static List<ProductGroupPrice> createProductGroupPrice()
        {
            return new List<ProductGroupPrice>(){
                new ProductGroupPrice(){
                   ProductGroupId= 1,
                    LicServerGroupId= 1,
                    DateStart=new DateTime(2020, 09, 03),
                    DateEnd= new DateTime(2020, 10, 03),
                    PriceContract= 10,
                    PricePerUnit= 0,
                    CostFactor= 0,
                    Enabled= true,
                    MacComment= "string",
                    Description= "string",
                    Id= 1,
                    DateCreated= new DateTime(2020, 09, 03),
                    DateChanged= new DateTime(2020, 10, 03),
                    ChangedBy= "iswarya.mothilal"

                },
                  new ProductGroupPrice(){
                     ProductGroupId= 1,
                    LicServerGroupId= 1,
                    DateStart=new DateTime(2020, 09, 03),
                    DateEnd= new DateTime(2020, 10, 03),
                    PriceContract= 10,
                    PricePerUnit= 0,
                    CostFactor= 0,
                    Enabled= true,
                    MacComment= "string",
                    Description= "string",
                    Id= 2,
                    DateCreated= new DateTime(2020, 09, 03),
                    DateChanged= new DateTime(2020, 10, 03),
                    ChangedBy= "iswarya.mothilal"
                },
            };
        }
        public static Dictionary<int, ProductGroupPrice> ProductGroupPriceDictionary()
        {
            return new Dictionary<int, ProductGroupPrice> { };
        }
        public static List<ProductGroupPrice> EmptyProductGroupPrice()
        {
            return new List<ProductGroupPrice> { };
        }
        
    }
}