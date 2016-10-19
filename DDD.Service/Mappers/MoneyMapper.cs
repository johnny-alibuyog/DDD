using DDD.Data;
using ExpressMapper;
using CoreModels = DDD.Core.Models;
using ServiceModels = DDD.Service.Models;

namespace DDD.Service.Mappers
{
    public class MoneyMapper : ICustomTypeMapper<ServiceModels.Money, CoreModels.Money>
    {
        public CoreModels.Money Map(IMappingContext<ServiceModels.Money, CoreModels.Money> context)
        {
            var session = SessionFactoryProvider.SessionFactory.RetrieveSharedSession();

            context.Destination = new CoreModels.Money(
                currency: context.Source.Currency != null
                    ? session.Load<CoreModels.Currency>(context.Source.Currency.Id)
                    : CoreModels.Currency.PHP,
                amount: context.Source.Amount
            );

            return context.Destination;
        }
    }
}
