using System.Collections.Generic;

namespace DDD.Service.Models
{
    public class User : Person
    {
        public virtual Address Address { get; set; }

        public virtual IEnumerable<Role> Roles { get; set; }
    }
}
