using ExpressMapper;
using CoreModels = DDD.Core.Models;
using ServiceModels = DDD.Service.Models;

namespace DDD.Service.Mappers
{
    internal class AddressMapper : ICustomTypeMapper<ServiceModels.Address, CoreModels.Address>
    {
        public CoreModels.Address Map(IMappingContext<ServiceModels.Address, CoreModels.Address> context)
        {
            if (context.Source == null)
                return null;

            return new CoreModels.Address(
                addressLine1: context.Source.AddressLine1,
                addressLine2: context.Source.AddressLine2,
                city: context.Source.City,
                state: context.Source.State,
                country: context.Source.Country,
                postalCode: context.Source.PostalCode
            );
        }
    }
}
