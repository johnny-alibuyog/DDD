using DDD.Common.Extentions;
using ExpressMapper;
using CoreModels = DDD.Core.Models;
using ServiceModels = DDD.Service.Models;

namespace DDD.Service.Mappers
{
    public class SavingsAccountMapper : ICustomTypeMapper<CoreModels.SavingsAccount, ServiceModels.SavingsAccount>
    {
        public ServiceModels.SavingsAccount Map(IMappingContext<CoreModels.SavingsAccount, ServiceModels.SavingsAccount> context)
        {
            if (context.Source == null)
                return null;

            //if (context.Source is CoreModels.CheckingAccount)
            //    context.Destination = context.Source.MapTo(default(ServiceModels.CheckingAccount));

            //if (context.Source is CoreModels.CurrentAccount)
            //    context.Destination = context.Source.MapTo(default(ServiceModels.CurrentAccount));

            //if (context.Source is CoreModels.SavingsAccount)
            //    context.Destination = context.Source.MapTo(default(ServiceModels.SavingsAccount));

            return context.Destination;
        }
    }
}
