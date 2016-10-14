using DDD.Core.Models;

namespace DDD.Core.Services.Accounts
{
    public class AccountCreateVisitor : AccountVisitor
    {
        public virtual Customer Owner { get; set; }

        public virtual string AccountName { get; set; }

        public virtual string AccountNumber { get; set; }

        public override void Visit(Account target)
        {
            target.Owner = this.Owner;
            target.AccountName = this.AccountName;
            target.AccountNumber = this.AccountNumber;
        }
    }
}
