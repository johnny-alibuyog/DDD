using DDD.Core.Models;
using FluentNHibernate.Mapping;
using System;

namespace DDD.Data.ModelDefenitions
{
    public class MoneyMapping : ComponentMap<Money>
    {
        public MoneyMapping()
        {
            Map(x => x.Amount);

            References(x => x.Currency);
        }

        internal static Action<ComponentPart<Money>> Map(string prefix = "", string parent = "")
        {
            return mapping =>
            {
                mapping.Map(x => x.Amount, $"{prefix}Amount");

                mapping.References(x => x.Currency, $"{prefix}CurrencyId")
                    .ForeignKey($"FK_{parent}_{prefix}Currency");
            };
        }
    }
}
