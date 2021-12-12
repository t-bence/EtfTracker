namespace EtfTracker.Modules
{
    public class DummyEtfPriceProvider : IEtfPriceProvider
    {
        public decimal GetEtfPriceInEur()
        {
            return 414.0m;
        }
    }
}
