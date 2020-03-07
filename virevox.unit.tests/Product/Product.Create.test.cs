using System;
using Xunit;
using Virevox.application.core;

namespace Virevox.unit.tests
{
    public class ProductTest
    {
        [Theory]
        [InlineData(3500, 830)]
        [InlineData(4500, 1050)]
        [InlineData(6000, 1380)]
        public void Create_BasicTariffProduct_ShouldReturnProductWithCalculatedAnnualConst(long consumption, long expectedAnnualConsts)
        {
            // Arrange
            var productName = "Basic electricity tariff";

            // Act
            Product product = Product.Create(productName, consumption, new BasicTariffCalculator());

            // Assert
            Assert.Equal(expectedAnnualConsts, product.AnnualCosts);
        }

        [Theory]
        [InlineData(3500, 800)]
        [InlineData(4500, 950)]
        [InlineData(6000, 1400)]
        public void Create_PackagedTariffProduct_ShouldReturnProductWithCalculatedAnnualConst(long consumption, long expectedAnnualConsts)
        {
            // Arrange
            var productName = "Packaged electricity tariff";

            // Act
            Product product = Product.Create(productName, consumption, new PackagedTariffCalculator());

            // Assert
            Assert.Equal(expectedAnnualConsts, product.AnnualCosts);
        }
    }
}
