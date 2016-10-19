using System;

namespace DDD.Service.Models
{
    public class Person
    {
        public virtual Guid Id { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        public virtual string LastName { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual DateTime? BirthDate { get; set; }

        public virtual Age Age { get; set; }
    }
}
