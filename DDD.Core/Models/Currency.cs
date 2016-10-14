namespace DDD.Core.Models
{
    public class Currency : Entity<string, Currency>
    {
        public virtual string Symbol { get; protected internal set; }

        public virtual string Name { get; protected internal set; }

        public Currency() { }

        public Currency(string id, string symbol, string name)
        {
            this.Id = id;
            this.Symbol = symbol;
            this.Name = name;
        }

        public static readonly Currency PHP = new Currency("PHP", "₱", "Philippine Peso");
    }
}
