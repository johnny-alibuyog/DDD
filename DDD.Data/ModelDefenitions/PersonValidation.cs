using DDD.Core.Models;
using NHibernate.Validator.Cfg.Loquacious;

namespace DDD.Data.ModelDefenitions
{
    public class PersonValidation : ValidationDef<Person>
    {
        public PersonValidation()
        {
            Define(x => x.Id);

            Define(x => x.FirstName)
                .NotNullableAndNotEmpty()
                .And.MaxLength(150);

            Define(x => x.MiddleName)
                .MaxLength(150);

            Define(x => x.LastName)
                .NotNullableAndNotEmpty()
                .And.MaxLength(150);

            Define(x => x.Gender);

            Define(x => x.BirthDate);
        }
    }
}
