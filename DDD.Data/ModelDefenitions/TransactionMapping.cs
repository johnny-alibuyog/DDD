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

            Map(x => x.Amount);

            Map(x => x.CurrentBalance);
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
        public CheckDepositMapping() { }
    }

    public class CheckReleaseMapping : SubclassMap<CheckRelease>
    {
        public CheckReleaseMapping() { }
    }
}
