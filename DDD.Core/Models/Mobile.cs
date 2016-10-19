namespace DDD.Core.Models
{
    public class Mobile : Contact
    {
        public virtual string Number { get; protected internal set; }

        public Mobile() { }

        public Mobile(string number)
        {
            this.Number = number;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Number}";
        }
    }
}
