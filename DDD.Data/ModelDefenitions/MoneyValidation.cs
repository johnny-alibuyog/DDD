using DDD.Core.Models;
using NHibernate.Validator.Cfg.Loquacious;

namespace DDD.Data.ModelDefenitions
{
    public class MoneyValidation : ValidationDef<Money>
    {
        public MoneyValidation()
        {
            Define(x => x.Amount);

            Define(x => x.Currency)
                .IsValid();
        }
    }
}
