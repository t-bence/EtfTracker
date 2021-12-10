﻿using EtfTracker.Data;
using EtfTracker.Models;

namespace EtfTracker.Services
{
    public class Calculator
    {
        private readonly EtfTrackerContext ctx;


        public decimal EurPrice { get; }
        public decimal EtfPrice { get; }
        public int NumberOfEtfs { get => ctx.EtfPurchase.Count(); }
        public decimal TotalHufSpent { get => ctx.Exchange.Sum(e => e.CostInHuf); }
        public decimal TotalEurBought { get => ctx.Exchange.Sum(e => e.EurAmount); }
        public decimal TotalEtfCost { get => ctx.EtfPurchase.Sum(e => e.EurPrice + EtfPurchase.Fee);  }
        public decimal RemainingMoney { get => TotalEurBought - TotalEtfCost; }
        public decimal TotalValue { get => NumberOfEtfs * EtfPrice + RemainingMoney; }
        public decimal TotalValueHuf { get => TotalValue * EurPrice; }
        public decimal Gain { get => TotalValueHuf - TotalHufSpent; }
        public decimal GainPercent { get => Gain / TotalHufSpent; }
        public decimal AvgYearlyGain {  get => ctx.EtfPurchase.Average(e => YearlyGain(e, EtfPrice)); }
        


        public Calculator(EtfTrackerContext context, IExchangeRateProvider exchangeRateProvider,
            IEtfPriceProvider etfPriceProvider)
        {
            ctx = context;
            EurPrice = exchangeRateProvider.GetEurPriceInHuf();
            EtfPrice = etfPriceProvider.GetEtfPriceInEur();

        }

        private static decimal YearlyGain(EtfPurchase etf, decimal currentPrice)
        {
            decimal daysBoughtSince = (decimal) (DateTime.Now - etf.Date).TotalDays;
            return (currentPrice - etf.EurPrice) / daysBoughtSince * 365.0m;
        }

    }
}