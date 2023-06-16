using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSRS.Api.BaseMapperContracts;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Demo.WebApi.Controllers;
using GSRS.Demo.WebAPI.IntegrationTesting.MockData;
using GSRS.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GSRS.Demo.WebAPI.IntegrationTesting.Controller
{
    public class ProductGroupPriceControllerTest
    {
        private Mock<IProductGroupPriceService> _serviceMock = new Mock<IProductGroupPriceService>();
        private Mock<IBaseModelToDtoMapper<ProductGroupPrice, ProductGroupPriceDto>> _dtoMapper = new Mock<IBaseModelToDtoMapper<ProductGroupPrice, ProductGroupPriceDto>>();
        private Mock<IBaseDtoToModelMapper<ProductGroupPriceDto, ProductGroupPrice>> _modelMapper = new Mock<IBaseDtoToModelMapper<ProductGroupPriceDto, ProductGroupPrice>>();
        private ProductGroupPriceController _controller;
        public ProductGroupPriceControllerTest()
        {
            _controller = new ProductGroupPriceController(_serviceMock.Object, _dtoMapper.Object, _modelMapper.Object);
        }
        //GetAll
        [Fact]
        public async void GetAllProductGroupPrice_withStatusCode200()
        {
            var entities = ProductGroupPriceMock.GetAllProductGroupPrice();
            var dictionary = entities.ToDictionary(c => c.Id, c => c);
            _serviceMock.Setup(s=>s.SearchAsync(null)).ReturnsAsync(dictionary);
            var Result = await _controller.Get() as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);
            Assert.IsType<OkObjectResult>(Result as OkObjectResult);
        }

          [Fact]
        public async void GetAllProductGroupPrice_withStatusCode204()
        {
            
            var Dictionary =ProductGroupPriceMock.ProductGroupPriceDictionary;
            _serviceMock.Setup(s => s.SearchAsync(null)).ReturnsAsync(Dictionary);
            var Result = await _controller.Get();
            Assert.Null(Result as ObjectResult);
            Assert.IsType<NoContentResult>(Result);

        } 
        //GetById Method
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void GetProductGroupPricebyId_withStatusCode200(int id)
        {
            //arrange 
            var sample = ProductGroupPriceMock.GetAllProductGroupPrice();
            var entity = sample.FirstOrDefault(c => c.Id == id);
            //act
            // _serviceMock.set
            _serviceMock.Setup(s => s.GetByIdAsync(id, true)).ReturnsAsync(entity);
            var Result = await _controller.Get(id) as ObjectResult;
            //assert
            Assert.NotNull(Result);
            Assert.Equal(StatusCodes.Status200OK, Result.StatusCode);
            Assert.IsType<OkObjectResult>(Result as OkObjectResult);



        }
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        public async void GetProductGroupPricebyId_withStatusCode204(int id)
        {
            //Arrange
            var sample = ProductGroupPriceMock.GetAllProductGroupPrice();
            var entity = sample.FirstOrDefault(c => c.Id == id);
           _serviceMock.Setup(s => s.GetByIdAsync(id, true)).ReturnsAsync(entity);
            //Act
            var Result = await _controller.Get(id);

            //Assert
            Assert.Null(Result as ObjectResult);
            Assert.IsType<NoContentResult>(Result);


        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void GetProductGroupPricebyId_withArgumentedNullException(int id)
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _controller.Get(id));

        } 
        [Fact]
        public async void PostProductGroupPrice_withStatusCode200()
        {
            var ProductGroupPriceDto = ProductGroupPriceMock.createProductGroupPriceDto();
            var ProductGroupPrice = ProductGroupPriceMock.createProductGroupPrice();
            int id = 1;
            var model = _modelMapper.Setup(s => s.Map(ProductGroupPriceDto)).Returns(ProductGroupPrice);
            var ProductGroupPricelist = ProductGroupPriceMock.EmptyProductGroupPrice();
            var ProductGroupPricedictionary = ProductGroupPricelist?.ToDictionary(c => c.Id, c => c);
            var ProductGroupPriceName = _serviceMock.Setup(s => s.SearchAsync(It.IsAny<SearchCondition<ProductGroupPrice>>())).ReturnsAsync(ProductGroupPricedictionary);
             _serviceMock.Setup(s => s.CreateListAsync(ProductGroupPrice)).ReturnsAsync(true);
            var ControllerResult = await _controller.Post(ProductGroupPriceDto) as ObjectResult;
            Assert.Equal(true, ControllerResult?.Value);
            Assert.NotNull(ControllerResult);
            Assert.IsType<OkObjectResult>(ControllerResult as OkObjectResult);
            Assert.IsType<Boolean>(ControllerResult.Value);
        }
       
    }
}