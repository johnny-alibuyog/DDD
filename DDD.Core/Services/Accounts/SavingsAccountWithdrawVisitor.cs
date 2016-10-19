using DDD.Common.Exceptions;
using DDD.Common.Extentions;
using DDD.Core.Models;
using System;

namespace DDD.Core.Services.Accounts
{
    public class SavingsAccountWithdrawVisitor : SavingsAccountVisitor
    {
        public DateTime Date { get; set; }

        public Money Amount { get; set; }

        public override void Visit(SavingsAccount target)
        {
            if (target.Balance == null)
                throw new BusinessException("Unable to withdraw. No balance.");

            if (target.Balance.Amount < this.Amount.Amount)
                throw new BusinessException("Unable to withdraw. No balance.");

            var withdrawal = new CashWithdrawal()
            {
                Account = target,
                Date = this.Date,
                Amount = this.Amount,
                CurrentBalance = target.Balance
            };

            target.Balance -= withdrawal.Amount;
            target.Transactions.Add(withdrawal);
        }
    }
}
