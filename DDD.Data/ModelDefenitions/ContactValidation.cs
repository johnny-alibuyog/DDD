using DDD.Core.Models;
using NHibernate.Validator.Cfg.Loquacious;

namespace DDD.Data.ModelDefenitions
{
    public class ContactValidation : ValidationDef<Contact>
    {
        public ContactValidation()
        {
            Define(x => x.Id);
        }
    }

    public class EmailValidation : ValidationDef<Email>
    {
        public EmailValidation()
        {
            Define(x => x.Address)
                .NotNullableAndNotEmpty()
                .And.IsEmail();
        }
    }

    public class FaxValidation : ValidationDef<Fax>
    {
        public FaxValidation()
        {
            Define(x => x.Number)
                .NotNullableAndNotEmpty()
                .And.MaxLength(50);
        }
    }

    public class LandlineValidation : ValidationDef<Landline>
    {
        public LandlineValidation()
        {
            Define(x => x.Number)
                .NotNullableAndNotEmpty()
                .And.MaxLength(50);
        }
    }

    public class MobileValidation : ValidationDef<Mobile>
    {
        public MobileValidation()
        {
            Define(x => x.Number)
                .NotNullableAndNotEmpty()
                .And.MaxLength(50);
        }
    }
}
