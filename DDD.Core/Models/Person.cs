using System;

namespace DDD.Core.Models
{
    public class Person : Entity<Guid, Person>
    {
        public virtual string FirstName { get; protected internal set; }

        public virtual string MiddleName { get; protected internal set; }

        public virtual string LastName { get; protected internal set; }

        public virtual Gender Gender { get; protected internal set; }

        public virtual DateTime? BirthDate { get; protected internal set; }

        public virtual Age Age { get { return BirthDate.HasValue ? new Age(BirthDate.Value) : null; } }
    }
}
