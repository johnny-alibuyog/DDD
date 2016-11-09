namespace DDD.Service.Models
{
    public class Money
    {
        public virtual decimal Amount { get; set; }

        public virtual Currency Currency { get; set; }

        public Money() : this(0M) { }

        public Money(decimal amount, Currency currency = null)
        {
            this.Amount = amount;
            this.Currency = currency ?? Currency.PHP;
        }
    }
}
