using System.Collections.Generic;

namespace DDD.Core.Models
{
    public class Customer : Person
    {
        public virtual Address Address { get; protected internal set; }

        public virtual IEnumerable<Contact> Contacts { get; protected internal set; }
    }
}
