using System.Threading.Tasks;
using Api.Controllers;
using Api.Models.Models;
using Api.Repositories.Interfaces;
using Api.Services.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Api.Tests.Controller
{
    [TestFixture]
    public class ControllerGetAllMoviesTest
    {
        public async Task Controller_GetAll_Test()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Movies>>();
            mockRepo.Setup(getAll => getAll.GetAll())
                .Returns(TestHelper.AllMovies);

            var mockServices = new Mock<MoviesService>(mockRepo.Object, TestHelper.Mapper);
            mockServices.Setup(getAllMoviesAsync => getAllMoviesAsync.GetAllMoviesAsync())
                .Returns(TestHelper.MappedMovies(TestHelper.AllMovies, TestHelper.Mapper));
            var mockController = new Mock<MoviesController>(mockServices.Object);
            
            // Act
            var result = await mockController.Object.GetAll();

            // Assert
            result.GetType().Should().Be(typeof(IActionResult));
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            var objResult = result as ObjectResult;
            objResult.Should().NotBeNull();
            objResult?.StatusCode.Should().Be(200);
        }
    }
}