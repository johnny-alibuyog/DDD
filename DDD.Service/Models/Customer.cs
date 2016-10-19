using System.Collections.Generic;

namespace DDD.Service.Models
{
    public class Customer : Person
    {
        public virtual Address Address { get; set; }

        public virtual IEnumerable<Contact> Contacts { get; set; }
    }
}
