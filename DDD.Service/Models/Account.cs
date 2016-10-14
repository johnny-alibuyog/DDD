using System;
using System.Collections.Generic;

namespace DDD.Service.Models
{
    public class Account
    {
        public virtual Guid Id { get; set; }

        public virtual Customer Owner { get; set; }

        public virtual string AccountNumber { get; set; }

        public virtual Money Balance { get; set; }

        public virtual IEnumerable<Transaction> Transactions { get; set; }
    }
}
