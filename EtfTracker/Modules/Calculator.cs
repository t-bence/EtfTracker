using EtfTracker.Data;
using EtfTracker.Models;
using Microsoft.Extensions.Caching.Memory;

namespace EtfTracker.Modules
{
    public class Calculator
    {
        private readonly EtfTrackerContext ctx;

        public decimal EurPrice { get; }
        public decimal EtfPrice { get; }
        public int NumberOfEtfs { get => ctx.EtfPurchase.Count(); }
        public decimal TotalHufSpent { get => ctx.Exchange.AsEnumerable().Sum(e => e.CostInHuf); }
        // these AsEnumerables are only needed becauces sqlite cannot sum decimals
        public decimal TotalEurBought { get => ctx.Exchange.AsEnumerable().Sum(e => e.EurAmount); }
        public decimal TotalEtfCost { get => ctx.EtfPurchase.AsEnumerable().Sum(e => e.TotalCostEur);  }
        public decimal RemainingMoney { get => TotalEurBought - TotalEtfCost; }
        public decimal TotalValue { get => NumberOfEtfs * EtfPrice + RemainingMoney; }
        public decimal TotalValueHuf { get => TotalValue * EurPrice; }
        public decimal Gain { get => TotalValueHuf - TotalHufSpent; }
        public decimal GainPercent { get => TotalHufSpent == 0 ? 0.0m : Gain / TotalHufSpent * 100; }
        public decimal AvgYearlyGain {  get => NumberOfEtfs == 0 ? 0.0m : 
            ctx.EtfPurchase.AsEnumerable().Average(e => YearlyGain(e, EtfPrice)); }
        


        public Calculator(EtfTrackerContext context, IExchangeRateProvider exchangeRateProvider,
            IEtfPriceProvider etfPriceProvider, IMemoryCache memoryCache)
        {
            ctx = context;
            EurPrice = memoryCache.GetOrCreate<decimal>(
                CacheKeys.EurPrice,
                cacheEntry => 
                {
                    cacheEntry.SlidingExpiration = TimeSpan.FromHours(3);
                    return exchangeRateProvider.GetEurPriceInHuf();
                }
            );

            EtfPrice = memoryCache.GetOrCreate<decimal>(
                CacheKeys.EtfPrice,
                cacheEntry =>
                {
                    cacheEntry.SlidingExpiration = TimeSpan.FromHours(3);
                    return etfPriceProvider.GetEtfPriceInEur();
                }
            );

        }

        private static decimal YearlyGain(EtfPurchase etf, decimal currentPrice)
        {
            decimal daysBoughtSince = (decimal) (DateTime.Now - etf.Date).TotalDays;
            return (currentPrice - etf.EurPrice) / daysBoughtSince * 365.0m;
        }

    }

    public class CacheKeys
    {
        public static string EurPrice = "EurPrice";
        public static string EtfPrice = "EtfPrice";
    }
}
