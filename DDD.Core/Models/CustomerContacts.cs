using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DDD.Core.Models
{
    public class CustomerContacts : Entity<Guid, CustomerContacts>
    {
        public virtual IEnumerable<Contact> Contacts { get; private set; } = new Collection<Contact>();
    }
}
