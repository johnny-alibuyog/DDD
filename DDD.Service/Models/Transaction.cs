using System;

namespace DDD.Service.Models
{
    public class Transaction
    {
        public virtual Guid Id { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual Money Amount { get; set; }

        public virtual Money CurrentBalance { get; set; }
    }
}
