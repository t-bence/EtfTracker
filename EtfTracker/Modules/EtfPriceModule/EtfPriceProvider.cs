using EtfTracker.Modules;
using EtfTracker.Modules.ApiHandlerModule;

namespace EtfTracker.Modules.EtfPriceModule
{

    public class EtfPriceProvider : IEtfPriceProvider
    {
        private const string apiUrl = "http://api.marketstack.com/v1/eod?access_key={0}&symbols=SXR8.XETRA&limit=1";
        private const string apiKey = "EtfPriceApi:Key";
        private IConfiguration configuration;

        public EtfPriceProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public decimal GetEtfPriceInEur()
        {
            var handler = new ApiHandler(configuration);

            var etfData = handler.GetData<EtfData>(apiUrl, apiKey);
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