using PC.ML.Core.Exceptions;
using PC.ML.Core.RequestDtos;
using PC.ML.Core.Services;

namespace PC.ML.Tests.ServiceTests
{
    [TestClass]
    public class PriceCheckerServiceTest
    {
        /// <summary>
        /// Test for checking the price of a laptop.
        /// <para>Asserts that the price is greater than 0.</para>
        /// </summary>
        /// <returns>Task of the opration.</returns>
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

        /// <summary>
        /// Test for checking the price of a laptop if default values are provided.
        /// <para>Asserts that the price is greater than 0.</para>
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task CheckPriceTestWithDefaltValuesAsync()
        {
            // Arrange
            var priceCheckerService = new PriceCheckerService();
            // Act
            var result = await priceCheckerService.CheckPrice(new PriceCheckerRequestDto());
            // Assert
            Assert.IsTrue(result > 0m);
        }

        /// <summary>
        /// Test for checking the price of a laptop if default values are provided.
        /// <para>Expect an exception.</para>
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [ExpectedException(typeof(MLException))]
        public async Task CheckPriceTestWithNullAsync()
        {
            // Arrange
            var priceCheckerService = new PriceCheckerService();
            // Act
            var result = await priceCheckerService.CheckPrice(null);
        }
    }
}
