namespace DDD.Core.Models
{
    public class Fax : Contact
    {
        public virtual string Number { get; protected internal set; }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Number}";
        }
    }
}
