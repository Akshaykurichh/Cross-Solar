using System.Threading.Tasks;
using CrossSolar.Controllers;
using CrossSolar.Models;
using CrossSolar.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CrossSolar.Tests.Controller
{
    public class AnalyticsControllerTests
    {
        public AnalyticsControllerTests()
        {
            _analyticsController = new AnalyticsController(_panelRepositoryMock.Object);
        }

        private readonly AnalyticsController _analyticsController;

        private readonly Mock<IAnalyticsRepository> _analyticsRepositoryMock = new Mock<IAnalyticsRepository>();

        [Fact]
        public async Task Get_ShouldGetResults()
        {
           var panelId="120";

            // Arrange

            // Act
            var result = await _analyticsController.Get(panelId);

            // Assert
            Assert.NotNull(result);

            var createdResult = result as CreatedResult;
            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);
        }
        [Fact]
        public async Task Get_ShouldReturnBadRequest()
        {
           var panelId="0";

            // Arrange

            // Act
            var result = await _analyticsController.Get(panelId);

            // Assert
            //Assert.Null(result);

            var createdResult = result as CreatedResult;
            //Assert.NotNull(createdResult);
            Assert.Equal(404, createdResult.StatusCode);
        }

         [Fact]
        public async Task Get_ShouldGetResults()
        {
           var panelId="120";

            // Arrange

            // Act
            var result = await _analyticsController.DayResults(panelId);

            // Assert
            Assert.NotNull(result);

            var createdResult = result as CreatedResult;
            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);
        }
       [Fact]
        public async Task GetDayResults_ShouldNotGetResults()
        {
           var panelId="0";

            // Arrange

            // Act
            var result = await _analyticsController.DayResults(panelId);

            // Assert
            //Assert.Null(result);

            //var createdResult = result as CreatedResult;
            //Assert.NotNull(createdResult);
            Assert.Equal(404, createdResult.StatusCode);
        }
            }
}