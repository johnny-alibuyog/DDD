using System;

namespace DDD.Core.Models
{
    public class UserRole : Entity<Guid, UserRole>
    {
        public virtual User User { get; protected internal set; }

        public virtual Role Role { get; protected internal set; }
    }
}
