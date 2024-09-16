using WitchApp.Interfaces.Impl;

namespace WitchApp.Tests
{
    public class ValidationServiceTests
    {
        private readonly ValidationService _validationService;

        public ValidationServiceTests()
        {
            _validationService = new ValidationService();
        }

        [Fact]
        public void ValidateInputs_ValidData_ReturnsTrue()
        {
            // Act
            var result = _validationService.ValidateData(10, 17);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidateInputs_InvalidData_ReturnsFalse()
        {
            // Act
            var result = _validationService.ValidateData(-1, 17);

            // Assert
            Assert.False(result);
        }
    }
}
