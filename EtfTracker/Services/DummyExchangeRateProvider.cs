namespace EtfTracker.Services
{
    public class DummyExchangeRateProvider : IExchangeRateProvider
    {
        public decimal GetEurPriceInHuf() => 366.0m;
    }
}
