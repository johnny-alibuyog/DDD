namespace DDD.Service.Models
{
    public class Currency
    {
        public virtual string Id { get; set; }

        public virtual string Symbol { get; set; }

        public virtual string Name { get; set; }

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
