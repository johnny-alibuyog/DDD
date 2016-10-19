using System;

namespace DDD.Core.Models
{
    public class Email : Contact
    {
        public virtual string Address { get; protected internal set; }

        public Email() { }

        public Email(string address)
        {
            this.Address = address;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Address}";
        }
    }
}
