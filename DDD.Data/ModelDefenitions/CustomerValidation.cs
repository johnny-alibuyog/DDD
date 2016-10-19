using DDD.Core.Models;
using NHibernate.Validator.Cfg.Loquacious;

namespace DDD.Data.ModelDefenitions
{
    public class CustomerValidation : ValidationDef<Customer>
    {
        public CustomerValidation()
        {
            Define(x => x.Address)
               .IsValid();

            Define(x => x.Contacts);
        }
    }
}
