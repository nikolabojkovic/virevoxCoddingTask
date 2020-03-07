using System;

namespace virevox.application.core
{
    public class Product
    {
        private readonly long _consumption;
        private readonly ICostsCalculator _calculatioModel;
        
        private Product(string tariffName, long consumption, ICostsCalculator calculatioModel)
        {
            TariffName = tariffName;
            _consumption = consumption;
            _calculatioModel = calculatioModel;
        }

        public string TariffName { get; private set; }
        public long AnnualCosts { get; private set; }

        public static Product Create(string name, long consumption, ICostsCalculator calculator)
        {
            var product = new Product(name, consumption, calculator);
            product.CalculateAnnualCosts();

            return product;
        }

        private void CalculateAnnualCosts()
        {
            AnnualCosts = _calculatioModel.CalculateFrom(_consumption);
        }
    }
}