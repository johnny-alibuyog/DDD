using DDD.Core.Models;
using FluentNHibernate.Mapping;

namespace DDD.Data.ModelDefenitions
{
    public class UserMapping : SubclassMap<User>
    {
        public UserMapping()
        {
            Component(x => x.Address);

            HasMany(x => x.Roles)
               .Table("UsersRoles")
               .Element("Role")
               .AsBag();
        }
    }
}
