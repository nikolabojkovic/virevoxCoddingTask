namespace Virevox.application.core
{
    public class PackagedTariffCalculator : ICostsCalculator
    {
        private readonly long ADDITIONAL_CONSTS = 30;
        private readonly long BASE_CONSUMPTION = 4000;
        private readonly long BASE_CONSUMPTION_CONSTS = 800 * 100; // in cents
        public long CalculateFrom(long consumption)
        {
            if (consumption <= BASE_CONSUMPTION)
                return BASE_CONSUMPTION_CONSTS / 100;
                
            return (BASE_CONSUMPTION_CONSTS + ((consumption - BASE_CONSUMPTION) * ADDITIONAL_CONSTS)) / 100;
        }
    }
}