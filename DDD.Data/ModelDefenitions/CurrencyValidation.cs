using DDD.Core.Models;
using NHibernate.Validator.Cfg.Loquacious;

namespace DDD.Data.ModelDefenitions
{
    public class CurrencyValidation : ValidationDef<Currency>
    {
        public CurrencyValidation()
        {
            Define(x => x.Id)
                .NotNullableAndNotEmpty()
                .And.MaxLength(5);

            Define(x => x.Symbol)
                .NotNullableAndNotEmpty()
                .And.MaxLength(5);

            Define(x => x.Name)
                .NotNullableAndNotEmpty()
                .And.MaxLength(50);
        }
    }
}
