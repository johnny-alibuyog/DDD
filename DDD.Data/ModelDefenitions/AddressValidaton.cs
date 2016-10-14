using DDD.Core.Models;
using NHibernate.Validator.Cfg.Loquacious;

namespace DDD.Data.ModelDefenitions
{
    public class AddressValidaton : ValidationDef<Address>
    {
        public AddressValidaton()
        {
            Define(x => x.AddressLine1)
                .MaxLength(250);

            Define(x => x.AddressLine2)
                .MaxLength(250);

            Define(x => x.City)
                .MaxLength(100);

            Define(x => x.State)
                .MaxLength(100);

            Define(x => x.Country)
                .MaxLength(100);

            Define(x => x.PostalCode)
                .MaxLength(100);
        }
    }
}
