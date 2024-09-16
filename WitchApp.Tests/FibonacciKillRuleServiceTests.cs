using WitchApp.Interfaces.Impl;

namespace WitchApp.Tests
{
    public class FibonacciKillRuleServiceTests
    {
        private readonly FibonacciKillRuleService _killRuleService;

        public FibonacciKillRuleServiceTests()
        {
            _killRuleService = new FibonacciKillRuleService();
        }

        [Fact]
        public void CalculateVillagerKillByYear_ValidNumber_ReturnsCorrectSum()
        {
            // Arrange
            int year = 5;

            // Act
            var result = _killRuleService.CalculateVillagerKillByYear(year);

            // Assert
            Assert.Equal(12, result); // Fibonacci sequence: 1, 1, 2, 3, 5 => sum = 12
        }

        [Fact]
        public void CalculateVillagerKillByYear_YearOne_ReturnsInitialValue()
        {
            // Arrange
            int year = 1;

            // Act
            var result = _killRuleService.CalculateVillagerKillByYear(year);

            // Assert
            Assert.Equal(1, result); // For year 1, return 1
        }

        [Fact]
        public void CalculateVillagerKillByYear_YearTwo_ReturnsSumForTwoYears()
        {
            // Arrange
            int year = 2;

            // Act
            var result = _killRuleService.CalculateVillagerKillByYear(year);

            // Assert
            Assert.Equal(2, result); // For year 2, return sum of 1 + 1 = 2
        }

        [Fact]
        public void CalculateVillagerKillByYear_YearFour_ReturnsCorrectSum()
        {
            // Arrange
            int year = 4;

            // Act
            var result = _killRuleService.CalculateVillagerKillByYear(year);

            // Assert
            Assert.Equal(7, result); // Fibonacci sequence: 1, 1, 2, 3 => sum = 7
        }
    }

}
