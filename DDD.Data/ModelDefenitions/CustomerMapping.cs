using DDD.Core.Models;
using FluentNHibernate.Mapping;

namespace DDD.Data.ModelDefenitions
{
    public class CustomerMapping : SubclassMap<Customer>
    {
        public CustomerMapping()
        {
            Component(x => x.Address);

            HasManyToMany(x => x.Contacts)
               .Table("CustomersContacts")
               .Cascade.All();
        }
    }
}
