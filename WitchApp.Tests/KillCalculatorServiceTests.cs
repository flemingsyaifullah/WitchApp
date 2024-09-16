using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitchApp.Interfaces.Impl;
using WitchApp.Interfaces;
using WitchApp.Models;

namespace WitchApp.Tests
{
    public class KillCalculatorServiceTests
    {
        private readonly KillCalculatorService _killCalculatorService;
        private readonly Mock<IKillRuleService> _mockKillRuleService;

        public KillCalculatorServiceTests()
        {
            _mockKillRuleService = new Mock<IKillRuleService>();
            _killCalculatorService = new KillCalculatorService(_mockKillRuleService.Object);
        }

        [Fact]
        public void CalculateAverageKills_ValidData_ReturnsCorrectAverage()
        {
            // Arrange
            var villagerA = new Villager(10, 12);
            var villagerB = new Villager(13, 17);

            // Mock the KillRuleService to return the correct kill counts for both years
            _mockKillRuleService.Setup(x => x.CalculateVillagerKillByYear(2)).Returns(2); // Person A born in year 2
            _mockKillRuleService.Setup(x => x.CalculateVillagerKillByYear(4)).Returns(7); // Person B born in year 4

            // Act
            var result = _killCalculatorService.CalculateAverageKillsOfTwoVillagers(villagerA, villagerB);

            // Assert
            Assert.Equal(4.5, result); // (2 + 7) / 2 = 4.5
        }
    }

}
