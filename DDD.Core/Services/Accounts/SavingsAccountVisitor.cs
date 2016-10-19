using DDD.Core.Models;

namespace DDD.Core.Services.Accounts
{
    public abstract class SavingsAccountVisitor : IVisitor<SavingsAccount>
    {
        public abstract void Visit(SavingsAccount target);
    }
}
