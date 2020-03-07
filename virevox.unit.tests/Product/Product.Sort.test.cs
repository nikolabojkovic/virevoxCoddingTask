using System;
using Xunit;
using Virevox.application.core;

namespace Virevox.unit.tests
{
    public class SortProductsTest
    {
        [Theory]
        [InlineData(3500, 800, 830)]
        [InlineData(4500, 950, 1050)]
        [InlineData(6000, 1380, 1400)]
        public void Sort_Products_ShouldSortProductsInAscendingOrder(long consumption, 
                                                                     long expectedAnnualConstsBasic, 
                                                                     int expectedAnnualConstsPackaged)
        {
            // Arrange
            var productBuider = new ProductBuilder();
                productBuider.SetConsumption(consumption);

            // Act
            Product [] products = productBuider.Build();
            Array.Sort(products, new ProductComparer<Product>());

            // Assert
            Assert.Equal(2, products.Length);
            Assert.Equal(expectedAnnualConstsBasic, products[0].AnnualCosts);
            Assert.Equal(expectedAnnualConstsPackaged, products[1].AnnualCosts);
        }

        [Fact]
        public void Sort_Products_ShouldSortListOfProductsInAscendingOrder()
        {
            // Arrange
            var productBuider = new ProductBuilder();
                productBuider.SetConsumption(3500);

            var result3500 = productBuider.Build();

            productBuider.SetConsumption(4500);
            var result4500 = productBuider.Build();

            productBuider.SetConsumption(6000);
            var result6000 = productBuider.Build();

            Product [] products = new Product[] {
                 result3500[0],
                 result3500[1],
                 result4500[0],
                 result4500[1],
                 result6000[0],
                 result6000[1]
                };            

            // Act
            Array.Sort(products, new ProductComparer<Product>());

            // Assert
            Assert.Equal(800,   products[0].AnnualCosts);
            Assert.Equal(830,   products[1].AnnualCosts);
            Assert.Equal(950,   products[2].AnnualCosts);
            Assert.Equal(1050,  products[3].AnnualCosts);
            Assert.Equal(1380,  products[4].AnnualCosts);
            Assert.Equal(1400, products[5].AnnualCosts);
        }
    }
}
