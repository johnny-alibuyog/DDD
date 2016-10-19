using DDD.Core.Models;

namespace DDD.Core.Services.Accounts
{
    public abstract class CheckingAccountVisitor : IVisitor<CheckingAccount>
    {
        public abstract void Visit(CheckingAccount target);
    }
}
