using EtfTracker.Data;
using EtfTracker.Models;
using Microsoft.Extensions.Caching.Memory;

namespace EtfTracker.Modules
{
    public class Calculator
    {
        private readonly EtfTrackerContext ctx;

        public ExchangeRate EurPrice { get; }
        public EurValue EtfPrice { get; }
        public int NumberOfEtfs { get => ctx.EtfPurchase.Count(); }
        public HufValue TotalHufSpent { get => ctx.Exchange.AsEnumerable().Sum(e => e.CostInHuf); }
        // these AsEnumerables are only needed becauces sqlite cannot sum decimals
        public EurValue TotalEurBought { get => ctx.Exchange.AsEnumerable().Sum(e => e.Amount); }
        public EurValue TotalEtfCost { get => ctx.EtfPurchase.AsEnumerable().Sum(e => e.TotalCostEur);  }
        public EurValue RemainingMoney { get => (EurValue)(TotalEurBought - TotalEtfCost); }
        public EurValue TotalValue { get => (EurValue)(EtfPrice * NumberOfEtfs + RemainingMoney); }
        public HufValue TotalValueHuf { get => (HufValue)(TotalValue * EurPrice); }
        public HufValue Gain { get => (HufValue)(TotalValueHuf - TotalHufSpent); }
        public decimal GainPercent { get => TotalHufSpent.IsZero ? 0.0m : Gain / TotalHufSpent * 100; }
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
            return (EtfPrice - etf.Price) / daysBoughtSince * DAYS_IN_YEAR;
        }

    }

    public class CacheKeys
    {
        public static string EurPrice = nameof(EurPrice);
        public static string EtfPrice = nameof(EtfPrice);
    }

}
