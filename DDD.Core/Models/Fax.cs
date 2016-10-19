namespace DDD.Core.Models
{
    public class Fax : Contact
    {
        public virtual string Number { get; protected internal set; }

        public Fax() { }

        public Fax(string number)
        {
            this.Number = number;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Number}";
        }
    }
}
