namespace DDD.Core.Models
{
    public class Money : ValueObject<Money>
    {
        public virtual decimal Amount { get; protected set; }

        public virtual Currency Currency { get; protected set; }

        public Money() : this(0M) { }

        public Money(decimal amount) : this(amount, Currency.PHP) { }

        public Money(decimal amount, Currency currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        public override string ToString()
        {
            return $"{this.Currency.Symbol} {this.Amount.ToString("0.00")}";
        }

        public static Money operator +(Money value1, Money value2)
        {
            if (value1 == null && value2 == null)
                return null;

            var currency = value1?.Currency ?? value2?.Currency;
            if (value1 == null)
                value1 = new Money(0M, currency);

            if (value2 == null)
                value2 = new Money(0M, currency);

            return new Money(value1.Amount + value2.Amount, currency);
        }

        public static Money operator -(Money value1, Money value2)
        {
            if (value1 == null && value2 == null)
                return null;

            var currency = value1?.Currency ?? value2?.Currency;
            if (value1 == null)
                value1 = new Money(0M, currency);

            if (value2 == null)
                value2 = new Money(0M, currency);

            return new Money(value1.Amount - value2.Amount, currency);
        }
    }
}
