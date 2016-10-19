using DDD.Common.Extentions;
using DDD.Core.Models;
using System;

namespace DDD.Core.Services.Accounts
{
    public class SavingsAccountDepositVisitor : SavingsAccountVisitor
    {
        public DateTime Date { get; set; }

        public Money Amount { get; set; }

        public override void Visit(SavingsAccount target)
        {
            var deposit = new CashDeposit()
            {
                Account = target,
                Date = this.Date,
                Amount = this.Amount,
                CurrentBalance = target.Balance
            };

            target.Balance += deposit.Amount;
            target.Transactions.Add(deposit);
        }
    }
}
