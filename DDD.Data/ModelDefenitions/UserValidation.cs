using DDD.Core.Models;
using NHibernate.Validator.Cfg.Loquacious;

namespace DDD.Data.ModelDefenitions
{
    public class UserValidation : ValidationDef<User>
    {
        public UserValidation()
        {
            Define(x => x.Address)
                .IsValid();

            Define(x => x.Roles);
        }
    }
}
