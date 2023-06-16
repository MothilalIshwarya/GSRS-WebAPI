using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class ModContractControllerTest
    {
        private Mock<IModContractService> _serviceMock = new Mock<IModContractService>();
        private Mock<IBaseModelToDtoMapper<ModContract, ModContractDto>> _dtoMapper = new Mock<IBaseModelToDtoMapper<ModContract, ModContractDto>>();
        private Mock<IBaseDtoToModelMapper<ModContractDto, ModContract>> _modelMapper = new Mock<IBaseDtoToModelMapper<ModContractDto, ModContract>>();
        private ModContractController _controller;
        public ModContractControllerTest()
        {
            _controller = new ModContractController(_serviceMock.Object, _dtoMapper.Object, _modelMapper.Object);
        }
        //GetAll
        [Fact]
        public async void GetAllModContract_withStatusCode200()
        {
            var entities = ModContractMock.GetAllModContract();
            var dictionary = entities.ToDictionary(c => c.Id, c => c);
            _serviceMock.Setup(s => s.SearchAsync(null)).ReturnsAsync(dictionary);
            var Result = await _controller.Get() as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);
            Assert.IsType<OkObjectResult>(Result as OkObjectResult);
        }
        [Fact]
        public async void GetAllModcontract_withStatusCode204()
        {

            var Dictionary = ModContractMock.ModContractDictionary;
            _serviceMock.Setup(s => s.SearchAsync(null)).ReturnsAsync(Dictionary);
            var Result = await _controller.Get();
            Assert.Null(Result as ObjectResult);
            Assert.IsType<NoContentResult>(Result);
        }
        //GetById Method
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void GetModContractbyId_withStatusCode200(int id)
        {
            //arrange 
            var sample = ModContractMock.GetAllModContract();
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
        public async void GetModContractbyId_withStatusCode204(int id)
        {
            //Arrange
            var sample = ModContractMock.GetAllModContract();
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
        public async void GetModContractbyId_withArgumentedNullException(int id)
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _controller.Get(id));

        }
        [Fact]
        public async void PostModContract_withStatusCode200()
        {
            var ModContractDto = ModContractMock.createModContractDto();
            var ModContract = ModContractMock.createModContract();
            // int id = 1;
            var model = _modelMapper.Setup(s => s.Map(ModContractDto)).Returns(ModContract);
            var ModContractlist = ModContractMock.EmptyModContractList();
            var ModContractdictionary = ModContractlist?.ToDictionary(c => c.Id, c => c);
            var ModContractName = _serviceMock.Setup(s => s.SearchAsync(It.IsAny<SearchCondition<ModContract>>())).ReturnsAsync(ModContractdictionary);
            _serviceMock.Setup(s => s.CreateAsync(ModContract)).ReturnsAsync(ModContract.Id);
            var ControllerResult = await _controller.Post(ModContractDto) as ObjectResult;
            Assert.Equal(ModContract.Id, ControllerResult?.Value);
            Assert.NotNull(ControllerResult);
            Assert.IsType<OkObjectResult>(ControllerResult as OkObjectResult);
            Assert.IsType<int>(ControllerResult.Value);
        }
        [Fact]
        public async void PostModContract_withValidationException()
        {
            var ModContractDto = ModContractMock.createModContractDtoInvalidEnddate();
            Assert.ThrowsAsync<ValidationException>(() => _controller.Post(ModContractDto));
        }
        [Fact]
        public async void UpdateModContract_withStatusCode200()
        {
            var ModContractDto = ModContractMock.UpdateModContractDto();
            var ModContract = ModContractMock.UpdateModContract();
            // int id = 1;
            var model = _modelMapper.Setup(s => s.Map(ModContractDto)).Returns(ModContract);
            var ModContractlist = ModContractMock.EmptyModContractList();
            var ModContractdictionary = ModContractlist?.ToDictionary(c => c.Id, c => c);
            var ModContractName = _serviceMock.Setup(s => s.SearchAsync(It.IsAny<SearchCondition<ModContract>>())).ReturnsAsync(ModContractdictionary);
            _serviceMock.Setup(s => s.GetByIdAsync(ModContract.Id, false)).ReturnsAsync(ModContract);
            _serviceMock.Setup(s => s.UpdateAsync(ModContract)).ReturnsAsync(ModContract.Id);
            var ControllerResult = await _controller.Post(ModContractDto) as ObjectResult;
            Assert.Equal(ModContract.Id, ControllerResult?.Value);
            Assert.NotNull(ControllerResult);
            Assert.IsType<OkObjectResult>(ControllerResult as OkObjectResult);
            Assert.IsType<int>(ControllerResult.Value);
        }
        [Fact]
        public async void UpdateModContract_withStatusCode404()
        {
            var ModContractDto = ModContractMock.UpdateModContractDtoInvalidId();
            var ModContract = ModContractMock.UpdateModContract();
            // int id = 10;
            var model = _modelMapper.Setup(s => s.Map(ModContractDto)).Returns(ModContract);
            var ModContractlist = ModContractMock.EmptyModContractList();
            var ModContractdictionary = ModContractlist?.ToDictionary(c => c.Id, c => c);
            var ModContractName = _serviceMock.Setup(s => s.SearchAsync(It.IsAny<SearchCondition<ModContract>>())).ReturnsAsync(ModContractdictionary);
            _serviceMock.Setup(s => s.GetByIdAsync(ModContractDto.Id, false)).ReturnsAsync(ModContractMock.EmptyModContract);
            var ControllerResult = await _controller.Post(ModContractDto) as ObjectResult;
            Assert.Equal(null, ControllerResult?.Value);

        }
    }
}