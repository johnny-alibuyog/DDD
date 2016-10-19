using DDD.Core.Models;
using System;

namespace DDD.Core.Services.Accounts
{
    public class SavingsAccountCloseVisitor : SavingsAccountVisitor
    {
        public DateTime Date { get; set; }

        public Money WithdrawAmount { get; set; }

        public override void Visit(SavingsAccount target)
        {
            this.WithdrawAmount = target.Balance;

            target.Accept(new SavingsAccountWithdrawVisitor()
            {
                Date = this.Date,
                Amount = this.WithdrawAmount
            });
        }
    }
}
