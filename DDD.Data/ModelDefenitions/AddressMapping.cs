using DDD.Core.Models;
using FluentNHibernate.Mapping;
using System;

namespace DDD.Data.ModelDefenitions
{
    public class AddressMapping : ComponentMap<Address>
    {
       public AddressMapping()
        {
            Map(x => x.AddressLine1);

            Map(x => x.AddressLine2);

            Map(x => x.City);

            Map(x => x.State);

            Map(x => x.Country);

            Map(x => x.PostalCode);
        }

        internal static Action<ComponentPart<Address>> Map(string prefix = "")
        {
            return mapping =>
            {
                mapping.Map(x => x.AddressLine1, $"{prefix}AddressLine1");

                mapping.Map(x => x.AddressLine2, $"{prefix}AddressLine2");

                mapping.Map(x => x.City, $"{prefix}City");

                mapping.Map(x => x.State, $"{prefix}State");

                mapping.Map(x => x.Country, $"{prefix}Country");

                mapping.Map(x => x.PostalCode, $"{prefix}PostalCode");
            };
        }
    }
}
