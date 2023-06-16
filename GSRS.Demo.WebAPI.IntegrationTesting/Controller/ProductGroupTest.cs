using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSRS.Demo.WebApi;
using GSRS.Service;
using GSRS.Demo.BusinessService;
using Moq;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Api.BaseMapperContracts;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Demo.WebApi.Controllers;
using Xunit;
using GSRS.Demo.WebAPI.IntegrationTesting.MockData;
using Microsoft.AspNetCore.Mvc;
using GSRS.Service.Models;

namespace GSRS.Demo.WebAPI.IntegrationTesting.Controller
{
    public class ProductGroupTest
    {
        private Mock<IProductGroupService> _service = new Mock<IProductGroupService>();
        private Mock<IBaseModelToDtoMapper<ProductGroup, ProductGroupDto>> _dtoMapper = new Mock<IBaseModelToDtoMapper<ProductGroup, ProductGroupDto>>();
        private Mock<IBaseDtoToModelMapper<ProductGroupDto, ProductGroup>> _modelMapper = new Mock<IBaseDtoToModelMapper<ProductGroupDto, ProductGroup>>();
        private ProductGroupController _controller;
        public ProductGroupTest()
        {
            _controller = new ProductGroupController(
                _service.Object, _dtoMapper.Object, _modelMapper.Object
            );
        }
        //GetAll ProductGroup
        [Fact]
        public async void GetAllProductGroup_WithStatusCode200()
        {
            var productGroupDto = ProductGroupMock.ProductGroupList();
            var dictionary = productGroupDto.ToDictionary(c => c.Id, c => c);
             _service.Setup(s => s.SearchAsync(null)).ReturnsAsync(dictionary);
            var ControllerResult = await _controller.Get() as ObjectResult;
            Assert.IsType<OkObjectResult>(ControllerResult);
            Assert.NotNull(ControllerResult.Value);
        }
        [Fact]
        public async void GetAllProductGroup_WithStatusCode204()
        {
            var productGroupDto = ProductGroupMock.ProductGroupList();
            productGroupDto = null;
            var dictionary = productGroupDto?.ToDictionary(c => c.Id, c => c);
            _service.Setup(s => s.SearchAsync(null)).ReturnsAsync(dictionary);
            var ControllerResult = await _controller.Get();
            Assert.Null(ControllerResult as ObjectResult);
            Assert.IsType<NoContentResult>(ControllerResult);
        }
        //GetById
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void GetProductGroupById_WithStatusCode200(int id)
        {
            var productGroup = ProductGroupMock.ProductGroupList();
            var entities = productGroup?.FirstOrDefault(c => c.Id == id);
           _service.Setup(s => s.GetByIdAsync(id, true)).ReturnsAsync(entities);
            var ControllerResult = await _controller.Get(id) as ObjectResult;
            // var mapper=_dtoMapper.Setup(s=>s.Map(productGroup)).Returns(ProductGroupMock.CreateProductGroup);
            Assert.IsType<OkObjectResult>(ControllerResult);
            Assert.NotNull(ControllerResult);
            Console.WriteLine(ControllerResult.Value);
        }
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        public async void GetProductGroupById_WithStatusCode204(int id)
        {
            var productGroup = ProductGroupMock.ProductGroupList();
            var entities = productGroup?.FirstOrDefault(c => c.Id == id);
             _service.Setup(s => s.GetByIdAsync(id, true)).ReturnsAsync(entities);
            var ControllerResult = await _controller.Get(id);
            // var mapper=_dtoMapper.Setup(s=>s.Map(productGroup)).Returns(ProductGroupMock.CreateProductGroup);
            Assert.IsType<NoContentResult>(ControllerResult);
            Assert.Null(ControllerResult as ObjectResult);
        }
         [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void GetProductGroupbyId_withArgumentedNullException(int id)
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _controller.Get(id));
        }
        //post
        [Fact]
        public async void PostProductGroup_withStatusCode200()
        {
            int id=1;
           var productGroup=ProductGroupMock.CreateProductGroup();
           var productGroupDto=ProductGroupMock.CreateProductGroupDto();
           var ProductGroupList=ProductGroupMock.EmptyList();
           var dictionary=ProductGroupList.ToDictionary(c=>c.Id,c=>c);
           var productgroupName= _service.Setup(s=>s.SearchAsync(It.IsAny<SearchCondition<ProductGroup>>())).ReturnsAsync(dictionary);
           _modelMapper.Setup(s=>s.Map(productGroupDto)).Returns(productGroup);
           _service.Setup(s=>s.CreateAsync(productGroup)).ReturnsAsync(id);
           var ControllerResult= await _controller.Post(productGroupDto) as ObjectResult;
           Assert.IsType<OkObjectResult>(ControllerResult);
           Assert.IsType<int>(ControllerResult.Value);
           Assert.Equal(id,ControllerResult.Value);
           Assert.NotNull(ControllerResult.Value);

        }
         [Fact]
        public async void PostProductGroup_withAlreadyExistErrorMsg()
        {
            int id=1;
            var productgroup=ProductGroupMock.CreateProductGroup();
            var productGroupDto=ProductGroupMock.CreateProductGroupDto();
            var ProductGroupList=ProductGroupMock.ProductGroupList();
           var dictionary=ProductGroupList.ToDictionary(c=>c.Id,c=>c);
            _service.Setup(s=>s.SearchAsync(It.IsAny<SearchCondition<ProductGroup>>())).ReturnsAsync(dictionary);
           _modelMapper.Setup(s=>s.Map(productGroupDto)).Returns(productgroup);
           _service.Setup(s=>s.CreateAsync(productgroup)).ReturnsAsync(id);
           var ControllerResult= await _controller.Post(productGroupDto) as ObjectResult;
             Assert.IsType<BadRequestObjectResult>(ControllerResult);
            // var badRequestResult = ControllerResult as BadRequestObjectResult;
            Assert.Equal("An Entity Exists Already", ControllerResult?.Value);
            Assert.IsType<string>(ControllerResult.Value);
        }
        [Fact]
        public async void UpadteProductGroup_withStatusCode200()
        {
            int id=1;
           var productGroup=ProductGroupMock.CreateProductGroup();
           var productGroupDto=ProductGroupMock.UpdateProductGroupDto();
           var ProductGroupList=ProductGroupMock.EmptyList();
           var dictionary=ProductGroupList.ToDictionary(c=>c.Id,c=>c);
           var productgroupName= _service.Setup(s=>s.SearchAsync(It.IsAny<SearchCondition<ProductGroup>>())).ReturnsAsync(dictionary);
           _modelMapper.Setup(s=>s.Map(productGroupDto)).Returns(productGroup);
           _service.Setup(s=>s.GetByIdAsync(id,false)).ReturnsAsync(productGroup);
           _service.Setup(s=>s.UpdateAsync(productGroup)).ReturnsAsync(id);
           var ControllerResult= await _controller.Post(productGroupDto) as ObjectResult;
           Assert.IsType<OkObjectResult>(ControllerResult);
           Assert.IsType<int>(ControllerResult.Value);
           Assert.Equal(id,ControllerResult.Value);
           Assert.NotNull(ControllerResult.Value);

        }
         [Fact]
        public async void UpdateProductGroup_withAlreadyExistErrorMsg()
        {
            int id=1;
            var productgroup=ProductGroupMock.UpdateProductGroup();
            var productGroupDto=ProductGroupMock.UpdateProductGroupDto();
            var ProductGroupList=ProductGroupMock.ProductGroupList();
           var dictionary=ProductGroupList.ToDictionary(c=>c.Id,c=>c);
            _service.Setup(s=>s.SearchAsync(It.IsAny<SearchCondition<ProductGroup>>())).ReturnsAsync(dictionary);
           _modelMapper.Setup(s=>s.Map(productGroupDto)).Returns(productgroup);
           _service.Setup(s=>s.CreateAsync(productgroup)).ReturnsAsync(id);
           var ControllerResult= await _controller.Post(productGroupDto) as ObjectResult;
             Assert.IsType<BadRequestObjectResult>(ControllerResult);
            // var badRequestResult = ControllerResult as BadRequestObjectResult;
            Assert.Equal("An Entity Exists Already", ControllerResult?.Value);
            Assert.IsType<string>(ControllerResult.Value);
        }
        [Fact]
        public async void UpdateProductGroup_withStatusCode404()
        {
           int id=1;
            var productgroup=ProductGroupMock.CreateProductGroup();
            var productGroupDto=ProductGroupMock.UpdateProductGroupDto();
            var ProductGroupList=ProductGroupMock.EmptyList();
           var dictionary=ProductGroupList.ToDictionary(c=>c.Id,c=>c);
           _modelMapper.Setup(s=>s.Map(productGroupDto)).Returns(productgroup);
           _service.Setup(s=>s.GetByIdAsync(id,false)).ReturnsAsync(ProductGroupMock.NullProductgroup);
           _service.Setup(s=>s.SearchAsync(It.IsAny<SearchCondition<ProductGroup>>())).ReturnsAsync(dictionary);
        //    _service.Setup(s=>s.UpdateAsync(productgroup));
           var ControllerResult=await _controller.Post(productGroupDto);
           var result=ControllerResult as ObjectResult;
        //  Assert.Null(result?.Value);
        Assert.Equal(null,result?.Value);
        }
      
    }
}