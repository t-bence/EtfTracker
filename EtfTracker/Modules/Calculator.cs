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
            ctx.EtfPurchase.AsEnumerable().Average(e => YearlyGain(e)); }
        


        public Calculator(EtfTrackerContext context, IExchangeRateProvider exchangeRateProvider,
            IEtfPriceProvider etfPriceProvider, IMemoryCache memoryCache)
        {
            ctx = context;

            EurPrice = GetCached<decimal>(CacheKeys.EurPrice, exchangeRateProvider.GetEurPriceInHuf);

            EtfPrice = GetCached<decimal>(CacheKeys.EtfPrice, etfPriceProvider.GetEtfPriceInEur);

            T GetCached<T>(string key, Func<T> function)
            {
                return memoryCache.GetOrCreate<T>(
                    key,
                    cacheEntry =>
                    {
                        cacheEntry.SlidingExpiration = TimeSpan.FromHours(3);
                        return function();
                    }
                );
            }

        }

        private decimal YearlyGain(EtfPurchase etf)
        {
            const decimal DAYS_IN_YEAR = 365.0m;
            decimal daysBoughtSince = (decimal) (DateTime.Now - etf.Date).TotalDays;
            return (EtfPrice - etf.EurPrice) / daysBoughtSince * DAYS_IN_YEAR;
        }

    }

    public class CacheKeys
    {
        public static string EurPrice = nameof(EurPrice);
        public static string EtfPrice = nameof(EtfPrice);
    }
}
