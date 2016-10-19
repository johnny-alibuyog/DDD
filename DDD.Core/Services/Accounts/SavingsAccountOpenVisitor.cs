using System;
using DDD.Core.Models;

namespace DDD.Core.Services.Accounts
{
    public class SavingsAccountOpenVisitor : SavingsAccountVisitor
    {
        public Customer Owner { get; set; }

        public string AccountName { get; set; }

        public string AccountNumber { get; set; }

        public Money InitialDeposit { get; set; }

        public DateTime Date { get; set; }

        public override void Visit(SavingsAccount target)
        {
            target.Owner = this.Owner;
            target.AccountName = this.AccountName;
            target.AccountNumber = this.AccountNumber;
            target.Accept(new SavingsAccountDepositVisitor()
            {
                Date = this.Date,
                Amount = this.InitialDeposit
            });
        }
    }
}
