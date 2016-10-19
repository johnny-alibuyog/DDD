using DDD.Core.Models;
using System;
using System.Collections.Generic;

namespace DDD.Core.Services.Customers
{
    public class InitializeIdentityVisitor : CustomerVisitor
    {
        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        public virtual string LastName { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual DateTime? BirthDate { get; set; }

        public virtual Address Address { get; set; }

        public virtual IEnumerable<Contact> Contacts { get; set; }

        public override void Visit(Customer target)
        {
            target.FirstName = this.FirstName;
            target.MiddleName = this.MiddleName;
            target.LastName = this.LastName;
            target.Gender = this.Gender;
            target.BirthDate = this.BirthDate;
            target.Address = this.Address;
            target.Contacts = this.Contacts;            
        }
    }
}
