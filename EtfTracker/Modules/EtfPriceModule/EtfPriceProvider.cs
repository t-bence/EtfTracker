using EtfTracker.Modules.ApiHandlerModule;

namespace EtfTracker.Modules.EtfPriceModule
{
    public class EtfPriceProvider : IEtfPriceProvider
    {
        private const string apiUrl = "http://api.marketstack.com/v1/eod?access_key={0}&symbols=SXR8.XETRA&limit=1";
        private const string apiKeySource = "ApiKeys:EtfPriceApi";
        private string apiKey { get; set; }

        public EtfPriceProvider(IConfiguration configuration)
        {
            apiKey = configuration.GetValue<string>(apiKeySource);
        }

        public decimal GetEtfPriceInEur()
        {
            var handler = new ApiHandler(apiKey);

            var etfData = handler.GetData<EtfData>(apiUrl);
            return etfData.data[0].close;
        }

        public class EtfData
        {
            public List<DailyEtfData> data { get; set; }
        }

        public class DailyEtfData
        {
            public decimal close { get; set; }
        }
    }
}