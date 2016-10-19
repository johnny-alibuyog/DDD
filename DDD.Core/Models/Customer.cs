using DDD.Core.Services;
using DDD.Core.Services.Customers;
using System.Collections.Generic;

namespace DDD.Core.Models
{
    public class Customer : Person, IAccept<CustomerVisitor>
    {
        public virtual Address Address { get; protected internal set; }

        public virtual IEnumerable<Contact> Contacts { get; protected internal set; }

        public virtual void Accept(CustomerVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
