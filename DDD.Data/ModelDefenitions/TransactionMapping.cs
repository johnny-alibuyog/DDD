using DDD.Core.Models;
using FluentNHibernate.Mapping;

namespace DDD.Data.ModelDefenitions
{
    public class TransactionMapping : ClassMap<Transaction>
    {
        public TransactionMapping()
        {
            Id(x => x.Id)
                .GeneratedBy.Assigned();

            Component(x => x.Amount,
                MoneyMapping.Map("Amount_", nameof(Transaction)));

            Component(x => x.CurrentBalance,
                MoneyMapping.Map("CurrentBalance_", nameof(Transaction)));
        }
    }

    public class CashDepositMapping : SubclassMap<CashDeposit>
    {
        public CashDepositMapping() { }
    }

    public class CashWithdrawalMapping : SubclassMap<CashWithdrawal>
    {
        public CashWithdrawalMapping() { }
    }

    public class CheckDepositMapping : SubclassMap<CheckDeposit>
    {
        public CheckDepositMapping()
        {
            Map(x => x.CheckNumber);
        }
    }

    public class CheckReleaseMapping : SubclassMap<CheckRelease>
    {
        public CheckReleaseMapping()
        {
            Map(x => x.CheckNumber);
        }
    }
}
