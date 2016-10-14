using DDD.Core.Services;
using DDD.Core.Services.Accounts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DDD.Core.Models
{
    public abstract class Account : Entity<Guid, Account>, IAccept<AccountVisitor>
    {
        public virtual Customer Owner { get; protected internal set; }

        public virtual string AccountName { get; protected internal set; }

        public virtual string AccountNumber { get; protected internal set; }

        public virtual Money Balance { get; protected internal set; }

        public virtual IEnumerable<Transaction> Transactions { get; protected internal set; } = new Collection<Transaction>();

        public AccountVisitor Accept(AccountVisitor visitor)
        {
            visitor.Visit(this);
            return visitor;
        }
    }
}
