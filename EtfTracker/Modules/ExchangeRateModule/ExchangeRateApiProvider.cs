using EtfTracker.Modules;
using EtfTracker.Modules.ApiHandlerModule;

namespace RazorPagesMovie.Modules.ExchangeRateModule
{
    public class ExchangeRateApiProvider : IExchangeRateProvider
    {
        string apiKey = "ExchangeRateApi:Key";
        string apiUrl = "https://v6.exchangerate-api.com/v6/{0}/pair/EUR/HUF";
        private IConfiguration configuration;


        public ExchangeRateApiProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public decimal GetEurPriceInHuf()
        {
            var handler = new ApiHandler(configuration);

            var exchangeData = handler.GetData<ExchangeData>(apiUrl, apiKey);

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
