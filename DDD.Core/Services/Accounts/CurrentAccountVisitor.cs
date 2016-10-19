using DDD.Core.Models;

namespace DDD.Core.Services.Accounts
{
    public abstract class CurrentAccountVisitor : IVisitor<CurrentAccount>
    {
        public abstract void Visit(CurrentAccount target);
    }
}
