using Newtonsoft.Json;

namespace Virevox.ViewModels
{
    public class ProductViewModel
    {
        [JsonProperty("tariffName")]
        public string TariffName { get; set; }
        
        [JsonProperty("annualCosts")]
        public long AnnualCosts { get; set; }
    }
}