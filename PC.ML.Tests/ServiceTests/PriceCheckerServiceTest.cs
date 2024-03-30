using Moq;

using PC.ML.Core.RequestDtos;
using PC.ML.Core.Services;

namespace PC.ML.Tests.ServiceTests
{
    [TestClass]
    public class PriceCheckerServiceTest
    {
        private readonly Mock<IPriceCheckerService> _priceCheckerServiceMock = new();
        [TestMethod]
        public async Task CheckPriceTestAsync()
        {
            // Arrange
            var requestDto = new PriceCheckerRequestDto
            {
                CPU = "Intel Core i5",
                GHz = 2.5f,
                GPU = "Nvidia GTX 1050",
                RAM = 8f,
                RAMType = "DDR4",
                Screen = 15.6f,
                Storage = 256f,
                SSD = true,
                Weight = 2.5f
            };
            var priceCheckerService = new PriceCheckerService();
            // Act
            var result = await priceCheckerService.CheckPrice(requestDto);
            // Assert
            Assert.IsTrue(result > 0m);
        }
    }
}
