using DDD.Core.Models;
using NHibernate.Validator.Cfg.Loquacious;

namespace DDD.Data.ModelDefenitions
{
    public class AccountValidation : ValidationDef<Account>
    {
        public AccountValidation()
        {
            Define(x => x.Id);

            Define(x => x.Owner)
                .NotNullable()
                .And.IsValid();

            Define(x => x.AccountNumber)
                .NotNullable()
                .And.MaxLength(50);

            Define(x => x.Balance)
                .IsValid();
        }
    }

    public class CheckingAccountValidation : ValidationDef<CheckingAccount>
    {
        public CheckingAccountValidation() { }
    }

    public class CurrentAccountValidation : ValidationDef<CurrentAccount>
    {
        public CurrentAccountValidation() { }
    }

    public class SavingAccountValidation : ValidationDef<SavingsAccount>
    {
        public SavingAccountValidation() { }
    }
}
