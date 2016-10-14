using System;

namespace DDD.Core.Models
{
    public class Email : Contact
    {
        public virtual string Address { get; protected internal set; }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Address}";
        }
    }
}
