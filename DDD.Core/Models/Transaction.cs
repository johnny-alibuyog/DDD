using System;

namespace DDD.Core.Models
{
    public abstract class Transaction : Entity<Guid, Transaction>
    {
        public virtual Account Account { get; protected internal set; }

        public virtual DateTime Date { get; protected internal set; }

        public virtual Money Amount { get; protected internal set; }

        public virtual Money CurrentBalance { get;  protected internal set; }
    }
}
