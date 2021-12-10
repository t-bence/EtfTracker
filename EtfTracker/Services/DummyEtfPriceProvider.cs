namespace EtfTracker.Services
{
    public class DummyEtfPriceProvider : IEtfPriceProvider
    {
        public decimal GetEtfPriceInEur()
        {
            return 414.0m;
        }
    }
}
