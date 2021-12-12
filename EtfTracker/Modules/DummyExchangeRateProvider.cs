namespace EtfTracker.Modules
{
    public class DummyExchangeRateProvider : IExchangeRateProvider
    {
        public decimal GetEurPriceInHuf() => 366.0m;
    }
}
