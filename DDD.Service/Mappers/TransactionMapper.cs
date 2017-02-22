using DDD.Common.Extentions;
using ExpressMapper;
using CoreModels = DDD.Core.Models;
using ServiceModels = DDD.Service.Models;

namespace DDD.Service.Mappers
{
    internal class TransactionMapper : ICustomTypeMapper<ServiceModels.Transaction, CoreModels.Transaction>
    {
        public CoreModels.Transaction Map(IMappingContext<ServiceModels.Transaction, CoreModels.Transaction> context)
        {
            if (context.Source == null)
                return null;

            if (context.Source is ServiceModels.CashDeposit)
                context.Destination = context.Source.MapTo(default(CoreModels.CashDeposit));

            if (context.Source is ServiceModels.CashWithdrawal)
                context.Destination = context.Source.MapTo(default(CoreModels.CashWithdrawal));

            if (context.Source is ServiceModels.CheckDeposit)
                context.Destination = context.Source.MapTo(default(CoreModels.CheckDeposit));

            if (context.Source is ServiceModels.CheckRelease)
                context.Destination = context.Source.MapTo(default(CoreModels.CheckRelease));

            return context.Destination;
        }
    }

    internal class TransactionReverseMapper : ICustomTypeMapper<CoreModels.Transaction, ServiceModels.Transaction>
    {
        public ServiceModels.Transaction Map(IMappingContext<CoreModels.Transaction, ServiceModels.Transaction> context)
        {
            if (context.Source == null)
                return null;

            if (context.Source is CoreModels.CashDeposit)
                context.Destination = context.Source.MapTo(new ServiceModels.CashDeposit());

            if (context.Source is CoreModels.CashWithdrawal)
                context.Destination = context.Source.MapTo(new ServiceModels.CashWithdrawal());

            if (context.Source is CoreModels.CheckDeposit)
                context.Destination = context.Source.MapTo(new ServiceModels.CheckDeposit());

            if (context.Source is CoreModels.CheckRelease)
                context.Destination = context.Source.MapTo(new ServiceModels.CheckRelease());

            return context.Destination;
        }
    }
}
