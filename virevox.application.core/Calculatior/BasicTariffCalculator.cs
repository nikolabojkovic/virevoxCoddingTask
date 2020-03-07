namespace virevox.application.core
{
    public class BasicTariffCalculator : ICostsCalculator
    {
        // in cents
        private readonly long CONSTS_PER_MONTH = 5 * 100;
        private readonly long CONSUMPTION_CONSTS = 22;

        public long CalculateFrom(long consumption)
        {
            // price in euros
            return ((12 * CONSTS_PER_MONTH) + (consumption * CONSUMPTION_CONSTS)) / 100;
        }
    }
}