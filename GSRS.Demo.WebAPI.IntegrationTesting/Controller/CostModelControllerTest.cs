
using Moq;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.WebAPI.IntegrationTesting.MockData;
using GSRS.Api.BaseMapperContracts;
using GSRS.Demo.BusinessService.Model;
using GSRS.Demo.Infrastructure.Dtos;
using GSRS.Demo.WebApi.Controllers;
using Xunit;
using GSRS.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;

namespace GSRS.Demo.WebAPI.IntegrationTesting.Controller
{
    public class CostModelControllerTest
    {
        private Mock<ICostModelService> _serviceMock;
        private Mock<IBaseModelToDtoMapper<CostModel, CostModelDto>> _dtoMapperMock;
        private Mock<IBaseDtoToModelMapper<CostModelDto, CostModel>> _modelMapperMock;
        private CostModelController _controller;
        public CostModelControllerTest()
        {
            _serviceMock = new Mock<ICostModelService>();
            _dtoMapperMock = new Mock<IBaseModelToDtoMapper<CostModel, CostModelDto>>();
            _modelMapperMock = new Mock<IBaseDtoToModelMapper<CostModelDto, CostModel>>();


            _controller = new CostModelController(
                _serviceMock.Object,
                _dtoMapperMock.Object,
                _modelMapperMock.Object
            );
        }
        //GetById Method
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void GetCostModelbyId_withStatusCode200(int id)
        {
            //arrange 
            var sample = CostModelMock.GetAllCostModel();
            var entity = sample.FirstOrDefault(c => c.Id == id);
            //act
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
        public async void GetCostModelbyId_withStatusCode204(int id)
        {
            //Arrange
            var sample = CostModelMock.GetAllCostModel();
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
        public async void GetCostModelbyId_withArgumentedNullException(int id)
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _controller.Get(id));

        }
        //GetAll Method
        [Fact]
        public async void GetAllCostModel_withStatusCode200()
        {
            var entities = CostModelMock.GetAllCostModel();
            var Dictionary = entities.ToDictionary(c => c.Id, c => c);
            _serviceMock.Setup(s => s.SearchAsync(null)).ReturnsAsync(Dictionary);
            var Result = await _controller.Get() as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);
            Assert.IsType<OkObjectResult>(Result as OkObjectResult);


        }
        [Fact]
        public async void GetAllCostModel_withStatusCode204()
        {

            var Dictionary = CostModelMock.ProductGroupDictionary;
            _serviceMock.Setup(s => s.SearchAsync(null)).ReturnsAsync(Dictionary);
            var Result = await _controller.Get();
            Assert.Null(Result as ObjectResult);
            Assert.IsType<NoContentResult>(Result);

        }
        //Post Moethod
        [Fact]
        public async void PostCostModel_withStatusCode200()
        {
            var costModelDto = CostModelMock.createcostmodelDto();
            var costModel = CostModelMock.createcostmodel();
            // int id = 1;
            var model = _modelMapperMock.Setup(s => s.Map(costModelDto)).Returns(costModel);
            var costmodellist = CostModelMock.EmptyCostmodelList();
            var Costmodeldictionary = costmodellist?.ToDictionary(c => c.Id, c => c);
            var CostModelName = _serviceMock.Setup(s => s.SearchAsync(It.IsAny<SearchCondition<CostModel>>())).ReturnsAsync(Costmodeldictionary);
            _serviceMock.Setup(s => s.CreateAsync(costModel)).ReturnsAsync(costModel.Id);
            var ControllerResult = await _controller.Post(costModelDto) as ObjectResult;
            Assert.Equal(costModel.Id, ControllerResult?.Value);
            Assert.NotNull(ControllerResult);
            Assert.IsType<OkObjectResult>(ControllerResult as OkObjectResult);
            Assert.IsType<int>(ControllerResult.Value);
        }
        [Fact]
        public async void PostCostModel_withAlreadyExistErrorMsg()
        {
            var sample = CostModelMock.createcostmodelDto();
            var entities = CostModelMock.createcostmodel();
            // int id = 1;
            var existingname = CostModelMock.GetAllCostModel();
            var model = _modelMapperMock.Setup(s => s.Map(sample)).Returns(entities);
            var dic = CostModelMock.GetAllCostModel();
            var dics = dic?.ToDictionary(c => c.Id, c => c);
            _serviceMock.Setup(s => s.SearchAsync(It.IsAny<SearchCondition<CostModel>>())).ReturnsAsync(dics);
            _serviceMock.Setup(s => s.CreateAsync(entities)).ReturnsAsync(sample.Id);
            // var Controller = new CostModelController(_serviceMock.Object, _dtoMapperMock.Object, _modelMapperMock.Object, _messageMock.Object);
            // var Result = await Controller.Post(sample) as ObjectResult;
            var Result = await _controller.Post(sample) as ObjectResult;
            Assert.IsType<BadRequestObjectResult>(Result);
            // var badRequestResult = Result as BadRequestObjectResult;
            Assert.Equal("An Entity Exists Already", Result?.Value);
            Assert.IsType<string>(Result.Value);
        }
        [Fact]
        public async void UpdateCostModel_withStatusCode200()
        {
            var costModelDto = CostModelMock.upadtecostmodelDto();
            var costModel = CostModelMock.upadtecostmodel();
            var model = _modelMapperMock.Setup(s => s.Map(costModelDto)).Returns(costModel);
            var costmodellist = CostModelMock.EmptyCostmodelList();
            var Costmodeldictionary = costmodellist?.ToDictionary(c => c.Id, c => c);
            var CostModelName = _serviceMock.Setup(s => s.SearchAsync(It.IsAny<SearchCondition<CostModel>>())).ReturnsAsync(Costmodeldictionary);
            _serviceMock.Setup(s => s.GetByIdAsync(costModel.Id, false)).ReturnsAsync(costModel);
            _serviceMock.Setup(s => s.UpdateAsync(costModel)).ReturnsAsync(costModel.Id);
            var ControllerResult = await _controller.Post(costModelDto) as ObjectResult;
            Assert.Equal(costModel.Id, ControllerResult?.Value);
            Assert.NotNull(ControllerResult);
            Assert.IsType<OkObjectResult>(ControllerResult as OkObjectResult);
            Assert.IsType<int>(ControllerResult.Value);
        }
        [Fact]
        public async void UpdateCostModel_withStatusCode404()
        {
            var costModelDto = CostModelMock.upadtecostmodelDtoInvalidId();
            var costModel = CostModelMock.upadtecostmodel();
            var model = _modelMapperMock.Setup(s => s.Map(costModelDto)).Returns(costModel);
            var costmodellist = CostModelMock.EmptyCostmodelList();
            var Costmodeldictionary = costmodellist?.ToDictionary(c => c.Id, c => c);
            var CostModelName = _serviceMock.Setup(s => s.SearchAsync(It.IsAny<SearchCondition<CostModel>>())).ReturnsAsync(Costmodeldictionary);
            _serviceMock.Setup(s => s.GetByIdAsync(costModelDto.Id, false)).ReturnsAsync(costModel);
            _serviceMock.Setup(s => s.UpdateAsync(costModel)).ReturnsAsync(costModel.Id);
            var ControllerResult = await _controller.Post(costModelDto) as ObjectResult;
            //  Assert.Null(result?.Value);
            Assert.Equal(null, ControllerResult?.Value);
        }
        [Fact]
        public async void UpdateCostModel_withAlreadyExistErrorMsg()
        {
            var sample = CostModelMock.upadtecostmodelDto();
            var entities = CostModelMock.upadtecostmodel();
            // int id = 1;
            var existingname = CostModelMock.GetAllCostModel();
            var model = _modelMapperMock.Setup(s => s.Map(sample)).Returns(entities);
            var dic = CostModelMock.GetAllCostModel();
            var dics = dic?.ToDictionary(c => c.Id, c => c);
            _serviceMock.Setup(s => s.SearchAsync(It.IsAny<SearchCondition<CostModel>>())).ReturnsAsync(dics);
            _serviceMock.Setup(s => s.CreateAsync(entities)).ReturnsAsync(entities.Id);
            // var Controller = new CostModelController(_serviceMock.Object, _dtoMapperMock.Object, _modelMapperMock.Object, _messageMock.Object);
            // var Result = await Controller.Post(sample) as ObjectResult;
            var Result = await _controller.Post(sample) as ObjectResult;
            Assert.IsType<BadRequestObjectResult>(Result);
            // var badRequestResult = Result as BadRequestObjectResult;
            Assert.Equal("An Entity Exists Already", Result?.Value);
            Assert.IsType<string>(Result.Value);
        }

    }
}
