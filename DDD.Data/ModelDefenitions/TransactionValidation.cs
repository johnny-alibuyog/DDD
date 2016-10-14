using DDD.Core.Models;
using NHibernate.Validator.Cfg.Loquacious;

namespace DDD.Data.ModelDefenitions
{
    public class TransactionValidation : ValidationDef<Transaction>
    {
        public TransactionValidation()
        {
            Define(x => x.Id);

            Define(x => x.Amount)
                .NotNullable()
                .And.IsValid();

            Define(x => x.CurrentBalance)
                .NotNullable()
                .And.IsValid();
        }
    }

    public class CashDepositValidation : ValidationDef<CashDeposit>
    {
        public CashDepositValidation() { }
    }

    public class CashWithdrawalValidation : ValidationDef<CashWithdrawal>
    {
        public CashWithdrawalValidation() { }
    }

    public class CheckDepositValidation : ValidationDef<CheckDeposit>
    {
        public CheckDepositValidation() { }
    }

    public class CheckReleaseValidation : ValidationDef<CheckRelease>
    {
        public CheckReleaseValidation() { }
    }
}
