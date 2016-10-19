using DDD.Core.Models;

namespace DDD.Core.Services.Accounts
{
    public class CheckingAccountCreateVisitor : CheckingAccountVisitor
    {
        public virtual Customer Owner { get; set; }

        public virtual string AccountName { get; set; }

        public virtual string AccountNumber { get; set; }

        public override void Visit(CheckingAccount target)
        {
            target.Owner = this.Owner;
            target.AccountName = this.AccountName;
            target.AccountNumber = this.AccountNumber;
        }
    }
}
