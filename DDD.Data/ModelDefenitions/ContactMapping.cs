using DDD.Core.Models;
using FluentNHibernate.Mapping;

namespace DDD.Data.ModelDefenitions
{
    public class ContactMapping : ClassMap<Contact>
    {
        public ContactMapping()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            DiscriminateSubClassesOnColumn<string>("Type");
        }
    }

    public class EmailMapping : SubclassMap<Email>
    {
        protected EmailMapping()
        {
            DiscriminatorValue("Email");
        }
    }

    public class FaxMapping : SubclassMap<Fax>
    {
        protected FaxMapping()
        {
            DiscriminatorValue("Fax");
        }
    }

    public class LandlineMapping : SubclassMap<Landline>
    {
        protected LandlineMapping()
        {
            DiscriminatorValue("Landline");
        }
    }

    public class MobileMapping : SubclassMap<Mobile>
    {
        protected MobileMapping()
        {
            DiscriminatorValue("Mobile");
        }
    }
}
