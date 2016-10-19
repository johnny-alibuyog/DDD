namespace DDD.Core.Models
{
    public class Landline : Contact
    {
        public virtual string Number { get; protected internal set; }

        public Landline() { }

        public Landline(string number)
        {
            this.Number = number;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Number}";
        }
    }
}
