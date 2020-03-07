using System;
using Xunit;
using Virevox.application.core;
using Virevox.Controllers;
using AutoMapper;
using Virevox.Profiles;
using System.Linq;
using Virevox.ViewModels;

namespace Virevox.unit.tests
{
    public class ProductsControllerTest
    {
        [Theory]
        [InlineData(3500, 800, 830)]
        [InlineData(4500, 950, 1050)]
        [InlineData(6000, 1380, 1400)]
        public void GetAll_Products_ShouldSortedListOfProducts(long consumption, 
                                                               long expectedAnnualConstsBasic, 
                                                               int expectedAnnualConstsPackaged)
        {
            // TODO: use mock instead or concreate implementations
            // Arrange
            var productBuider = new ProductBuilder();
                productBuider.SetConsumption(consumption);
            var productComparer = new ProductComparer<Product>();

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductProfile());
            });
            var mapper = mockMapper.CreateMapper();
            var productsController = new ProductsController(productBuider, productComparer, mapper);

            // Act
            ProductViewModel [] products = productsController.Get(consumption).ToArray();

            // Assert
            Assert.Equal(2, products.Length);
            Assert.Equal(expectedAnnualConstsBasic, products[0].AnnualCosts);
            Assert.Equal(expectedAnnualConstsPackaged, products[1].AnnualCosts);
        }

        [Fact]
        public void Get_Products_ShouldThrowBadRequestException()
        {
            // Arrange
            var productBuider = new ProductBuilder();
                productBuider.SetConsumption(-1000);
            var productComparer = new ProductComparer<Product>();

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductProfile());
            });
            var mapper = mockMapper.CreateMapper();
            var productsController = new ProductsController(productBuider, productComparer, mapper);

            // Act
            // Assert
            Assert.Throws<BadRequestException>(() => productsController.Get(-1000));
        }
    }
}
