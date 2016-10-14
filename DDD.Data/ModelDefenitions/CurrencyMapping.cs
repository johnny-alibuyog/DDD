using DDD.Core.Models;
using FluentNHibernate.Mapping;

namespace DDD.Data.ModelDefenitions
{
    public class CurrencyMapping : ClassMap<Currency>
    {
        public CurrencyMapping()
        {
            Id(x => x.Id)
                .GeneratedBy.Assigned();

            Map(x => x.Symbol);

            Map(x => x.Name);
        }
    }
}
