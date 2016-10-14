using DDD.Core.Models;
using FluentNHibernate.Mapping;

namespace DDD.Data.ModelDefenitions
{
    public class PersonMapping : ClassMap<Person>
    {
        public PersonMapping()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            Map(x => x.FirstName);

            Map(x => x.MiddleName);

            Map(x => x.LastName);

            Map(x => x.Gender);

            Map(x => x.BirthDate);
        }
    }
}
