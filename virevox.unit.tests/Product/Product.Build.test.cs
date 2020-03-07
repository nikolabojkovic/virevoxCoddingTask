using System;
using Xunit;
using Virevox.application.core;

namespace Virevox.unit.tests
{
    public class BuildProductsTest
    {
        [Theory]
        [InlineData(3500, 830, 800)]
        [InlineData(4500, 1050, 950)]
        [InlineData(6000, 1380, 1400)]
        public void Build_Products_ShouldCreateListOfProducts(long consumption, 
                                                              long expectedAnnualConstsBasic, 
                                                              int expectedAnnualConstsPackaged)
        {
            // Arrange
            var productBuider = new ProductBuilder();
                productBuider.SetConsumption(consumption);

            // Act
            Product [] products = productBuider.Build();

            // Assert
            Assert.Equal(2, products.Length);
            Assert.Equal(expectedAnnualConstsBasic, products[0].AnnualCosts);
            Assert.Equal(expectedAnnualConstsPackaged, products[1].AnnualCosts);
        }
    }
}
