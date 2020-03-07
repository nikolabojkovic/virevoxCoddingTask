namespace Virevox.application.core
{
    public partial class Product
    {
        private readonly long _consumption;
        private readonly ICostsCalculator _calculator;
        
        private Product(string tariffName, long consumption, ICostsCalculator calculatioModel)
        {
            TariffName = tariffName;
            _consumption = consumption;
            _calculator = calculatioModel;
        }

        public static Product Create(string name, long consumption, ICostsCalculator calculator)
        {
            var product = new Product(name, consumption, calculator);
                product.AnnualCosts = product.CalculateAnnualCosts();

            return product;
        }

        private long CalculateAnnualCosts() =>
            _calculator.CalculateFrom(_consumption);
        
    }
}