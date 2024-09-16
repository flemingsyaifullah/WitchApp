using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitchApp.Interfaces;
using WitchApp.Models;

namespace WitchApp.Tests
{
    public class WitchFacadeTests
    {
        private readonly Mock<IValidationService> _mockValidationService;
        private readonly Mock<IKillCalculatorService> _mockKillCalculatorService;
        private readonly WitchFacade _facade;

        public WitchFacadeTests()
        {
            _mockValidationService = new Mock<IValidationService>();
            _mockKillCalculatorService = new Mock<IKillCalculatorService>();
            _facade = new WitchFacade(_mockValidationService.Object, _mockKillCalculatorService.Object);
        }

        [Fact]
        public void CalculateAverageKills_ValidData_ReturnsCorrectAverage()
        {
            // Arrange

            var villagerA = new Villager(10, 12);
            var villagerB = new Villager(13, 17);
            double expectedAverage = 4.5;

            _mockValidationService.Setup(v => v.ValidateData(villagerA.Age, villagerA.YearOfDeath)).Returns(true);
            _mockValidationService.Setup(v => v.ValidateData(villagerB.Age, villagerB.YearOfDeath)).Returns(true);

            _mockKillCalculatorService
                .Setup(c => c.CalculateAverageKillsOfTwoVillagers(villagerA, villagerB))
                .Returns(expectedAverage);

            // Act
            var result = _facade.CalculateAverageKills(villagerA, villagerB);

            // Assert
            Assert.Equal(expectedAverage, result);
        }

        [Fact]
        public void CalculateAverageKills_InvalidData_ReturnsNegativeOne()
        {
            // Arrange

            var villagerA = new Villager(-1, 12);
            var villagerB = new Villager(13, 17);

            _mockValidationService.Setup(v => v.ValidateData(villagerA.Age, villagerA.YearOfDeath)).Returns(false);

            // Act
            var result = _facade.CalculateAverageKills(villagerA, villagerB);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void CalculateAverageKills_ValidationFails_RegardlessOfCalculatorResult_ReturnsNegativeOne()
        {
            // Arrange
            var villagerA = new Villager(10, 12);
            var villagerB = new Villager(13, 17);

            _mockValidationService.Setup(v => v.ValidateData(villagerA.Age, villagerA.YearOfDeath)).Returns(false);
            _mockValidationService.Setup(v => v.ValidateData(villagerB.Age, villagerB.YearOfDeath)).Returns(true);

            // Act
            var result = _facade.CalculateAverageKills(villagerA, villagerB);

            // Assert
            Assert.Equal(-1, result);
        }
    }
}
