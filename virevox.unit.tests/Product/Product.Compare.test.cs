using System;
using Xunit;
using Virevox.application.core;

namespace Virevox.unit.tests
{
    public class CompareProductsTest
    {
        [Theory]
        [InlineData(3500, 4500, -1)]
        [InlineData(4500, 3500, 1)]        
        [InlineData(4500, 4500, 0)]
        public void Compare_Products_ShouldCompareProducts(long consumptionProductLeft, 
                                                           long consumptionProductRight, 
                                                           int comparisonResult)
        {
            // Arrange
            var productComparer = new ProductComparer<Product>();

            // Act
            Product productLeft = Product.Create("pLeft", consumptionProductLeft, new BasicTariffCalculator());
            Product productRight = Product.Create("pRight", consumptionProductRight, new BasicTariffCalculator());

            // Assert
            Assert.Equal(comparisonResult, productComparer.Compare(productLeft, productRight));
        }
    }
}
