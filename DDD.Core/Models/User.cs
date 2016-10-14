using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DDD.Core.Models
{
    public class User : Person
    {
        public virtual Address Address { get; protected internal set; }

        public virtual IEnumerable<Role> Roles { get; protected internal set; } = new Collection<Role>();
    }
}
