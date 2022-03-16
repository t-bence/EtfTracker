namespace EtfTracker.Models
{
    public class MoneyValue
    {
        public decimal Value { get; }
        public Currency Currency { get; }

        public MoneyValue(decimal value, Currency currency)
        {
            Value = value;
            Currency = currency;
        }

        public bool IsZero => Value == 0;

        public static MoneyValue operator +(MoneyValue left, MoneyValue right)
        {
            if (left.Currency != right.Currency)
            {
                throw new CurrencyMismatchException("Only values of the same currency can be added!");
            }
            return new MoneyValue(left.Value + right.Value, left.Currency);
        }

        public static MoneyValue operator -(MoneyValue left, MoneyValue right)
        {
            if (left.Currency != right.Currency)
            {
                throw new CurrencyMismatchException("Only values of the same currency can be added!");
            }
            return new MoneyValue(left.Value - right.Value, left.Currency);
        }

        public static MoneyValue operator *(MoneyValue moneyValue, int times)
        {
            return new MoneyValue(moneyValue.Value * times, moneyValue.Currency);
        }

        public static decimal operator /(MoneyValue left, MoneyValue right)
        {
            if (left.Currency != right.Currency)
            {
                throw new CurrencyMismatchException("Only values of the same currency can be divided!");
            }
            return left.Value / right.Value;
        }


        public static MoneyValue operator *(MoneyValue moneyValue, ExchangeRate exchangeRate)
        {
            if (moneyValue.Currency != exchangeRate.BaseCurrency)
            {
                throw new CurrencyMismatchException($"Cannot convert {moneyValue} using {exchangeRate}");
            }
            return new MoneyValue(moneyValue.Value * exchangeRate.Rate, exchangeRate.TargetCurrency);
        }

        public override string ToString()
        {
            return Value.ToString() + " " + Enum.GetName(typeof(Currency), this.Currency);
        }
    }

    public class EurValue : MoneyValue
    {
        public EurValue(decimal value) : base(value, Currency.EUR)
        {
        }

    }

    public class HufValue : MoneyValue
    {
        public HufValue(decimal value) : base(value, Currency.HUF)
        {
        }
    }

    public class ExchangeRate
    {
        public decimal Rate { get; }
        public Currency BaseCurrency { get; }
        public Currency TargetCurrency { get; }

        public ExchangeRate(decimal rate, Currency baseCurrency, Currency targetCurrency)
        {
            if (baseCurrency == targetCurrency)
            {
                throw new CurrencyMismatchException("Exchange rate currencies must differ!");
            }
            Rate = rate;
            BaseCurrency = baseCurrency;
            TargetCurrency = targetCurrency;
        }

        public override string ToString()
        {
            return Rate.ToString() + " " + 
                Enum.GetName(typeof(Currency), this.TargetCurrency) + " / " +
                Enum.GetName(typeof(Currency), this.BaseCurrency);
        }
    }

    public class CurrencyMismatchException : Exception
    {
        public CurrencyMismatchException(string message) : base(message)
        {
        }
    }




    public enum Currency
    {
        EUR,
        HUF
    }
}