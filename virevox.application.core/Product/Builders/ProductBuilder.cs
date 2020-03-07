using System.Collections.Generic;

namespace Virevox.application.core
{
    public class ProductBuilder : IProductBuilder
    {
        private long _consumption;

        public ProductBuilder() {}

        public void SetConsumption(long consumption) =>
             _consumption = consumption;        

        public Product [] Build()
        {
            return new Product []
            {
                Product.Create("Basic electricity tariff", _consumption, new BasicTariffCalculator()),
                Product.Create("Packaged electricity tariff", _consumption, new PackagedTariffCalculator())
            };
        }
    }
}