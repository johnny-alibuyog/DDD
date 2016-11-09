using DDD.Common.Extentions;
using ExpressMapper;
using CoreModels = DDD.Core.Models;
using ServiceModels = DDD.Service.Models;

namespace DDD.Service.Mappers
{
    public class AccountMapper : ICustomTypeMapper<CoreModels.Account, ServiceModels.Account>
    {
        public ServiceModels.Account Map(IMappingContext<CoreModels.Account, ServiceModels.Account> context)
        {
            if (context.Source == null)
                return null;

            if (context.Source is CoreModels.CheckingAccount)
                context.Destination = context.Source.MapTo(default(ServiceModels.CheckingAccount));

            if (context.Source is CoreModels.CurrentAccount)
                context.Destination = context.Source.MapTo(default(ServiceModels.CurrentAccount));

            if (context.Source is CoreModels.SavingsAccount)
                context.Destination = context.Source.MapTo(default(ServiceModels.SavingsAccount));

            return context.Destination;
        }
    }

    //public class SavngsAccountReadRequestMapper : ICustomTypeMapper<CoreModels.Account, SavingsAccountRead.Request>
    //{
    //    public SavingsAccountRead.Request Map(IMappingContext<CoreModels.Account, SavingsAccountRead.Request> context)
    //    {
    //        if (context.Source == null)
    //            return null;

    //        if (context.Source is CoreModels.CheckingAccount)
    //            context.Destination = context.Source.MapTo(default(ServiceModels.CheckingAccount));

    //        if (context.Source is CoreModels.CurrentAccount)
    //            context.Destination = context.Source.MapTo(default(ServiceModels.CurrentAccount));

    //        if (context.Source is CoreModels.SavingsAccount)
    //            context.Destination = context.Source.MapTo(default(ServiceModels.SavingsAccount));

    //        return context.Destination;
    //    }
    //}
}
