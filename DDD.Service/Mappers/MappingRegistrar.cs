using ExpressMapper;
using CoreModels = DDD.Core.Models;
using ServiceModels = DDD.Service.Models;

namespace DDD.Service.Mappers
{
    public class MappingRegistrar
    {
        public void Register()
        {
            Mapper.RegisterCustom<ServiceModels.Address, CoreModels.Address, AddressMapper>();
            Mapper.RegisterCustom<ServiceModels.Customer, CoreModels.Customer, CustomerMapper>();
            Mapper.RegisterCustom<ServiceModels.Contact, CoreModels.Contact, ContactMapper>();
            Mapper.RegisterCustom<CoreModels.Contact, ServiceModels.Contact, ContactReverseMapper>();
            Mapper.RegisterCustom<ServiceModels.Money, CoreModels.Money, MoneyMapper>();
            Mapper.RegisterCustom<ServiceModels.Transaction, CoreModels.Transaction, TransactionMapper>();
            Mapper.RegisterCustom<CoreModels.Transaction, ServiceModels.Transaction, TransactionReverseMapper>();
        }
    }
}
