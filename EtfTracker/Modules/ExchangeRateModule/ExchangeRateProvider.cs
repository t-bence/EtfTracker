using EtfTracker.Modules;
using EtfTracker.Modules.ApiHandlerModule;

namespace EtfTracker.Modules.ExchangeRateModule
{
    public class ExchangeRateProvider : IExchangeRateProvider
    {
        string apiKeySource = "ApiKeys:ExchangeRateApi";
        string apiUrl = "https://v6.exchangerate-api.com/v6/{0}/pair/EUR/HUF";
        private string apiKey { get; set; }

        public ExchangeRateProvider(IConfiguration configuration)
        {
            apiKey = configuration.GetValue<string>(apiKeySource);
        }

        public decimal GetEurPriceInHuf()
        {
            var handler = new ApiHandler(apiKey);

            var exchangeData = handler.GetData<ExchangeData>(apiUrl);

            return exchangeData.conversion_rate;
        }
    }

    /// <summary>
    /// This class describes the API output (useful parts)
    /// </summary>
    class ExchangeData
    {
        public decimal conversion_rate { get; set; }

    }
}
