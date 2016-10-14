using DDD.Core.Models;
using FluentNHibernate.Mapping;

namespace DDD.Data.ModelDefenitions
{
    public class AccountMapping : ClassMap<Account>
    {
        public AccountMapping()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            References(x => x.Owner)
                .Cascade.SaveUpdate();

            Map(x => x.AccountName);

            Map(x => x.AccountNumber);

            Component(x => x.Balance);
        }
    }

    public class CheckingAccountMapping : SubclassMap<CheckingAccount>
    {
        public CheckingAccountMapping() { }
    }

    public class CurrentAccountMapping : SubclassMap<CurrentAccount>
    {
        public CurrentAccountMapping() { }
    }

    public class SavingsAccountMapping : SubclassMap<SavingsAccount>
    {
        public SavingsAccountMapping() { }
    }
}
