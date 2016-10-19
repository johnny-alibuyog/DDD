using ExpressMapper;
using CoreModels = DDD.Core.Models;
using ServiceModels = DDD.Service.Models;


namespace DDD.Service.Mappers
{
    public class ContactMapper : ICustomTypeMapper<ServiceModels.Contact, CoreModels.Contact>
    {
        public CoreModels.Contact Map(IMappingContext<ServiceModels.Contact, CoreModels.Contact> context)
        {
            if (context.Source == null)
                return null;

            if (context.Source is ServiceModels.Email)
                context.Destination = new CoreModels.Email(((ServiceModels.Email)context.Source).Address);

            if (context.Source is ServiceModels.Fax)
                context.Destination = new CoreModels.Fax(((ServiceModels.Fax)context.Source).Number);

            if (context.Source is ServiceModels.Landline)
                context.Destination = new CoreModels.Landline(((ServiceModels.Landline)context.Source).Number);

            if (context.Source is ServiceModels.Mobile)
                context.Destination = new CoreModels.Mobile(((ServiceModels.Mobile)context.Source).Number);

            return context.Destination;
        }
    }

    public class ContactReverseMapper : ICustomTypeMapper<CoreModels.Contact, ServiceModels.Contact>
    {
        public ServiceModels.Contact Map(IMappingContext<CoreModels.Contact, ServiceModels.Contact> context)
        {
            if (context.Source == null)
                return null;

            if (context.Source is CoreModels.Email)
                context.Destination = new ServiceModels.Email(((CoreModels.Email)context.Source).Address);

            if (context.Source is CoreModels.Fax)
                context.Destination = new ServiceModels.Fax(((CoreModels.Fax)context.Source).Number);

            if (context.Source is CoreModels.Landline)
                context.Destination = new ServiceModels.Landline(((CoreModels.Landline)context.Source).Number);

            if (context.Source is CoreModels.Mobile)
                context.Destination = new ServiceModels.Mobile(((CoreModels.Mobile)context.Source).Number);

            return context.Destination;
        }
    }
}
