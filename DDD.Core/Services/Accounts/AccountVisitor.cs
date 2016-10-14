using System;
using DDD.Core.Models;

namespace DDD.Core.Services.Accounts
{
    public abstract class AccountVisitor : IVisitor<Account>
    {
        public abstract void Visit(Account target);
    }
}
