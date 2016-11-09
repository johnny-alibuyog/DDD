using DDD.Common.Extentions;
using DDD.Core.Services.Customers;
using DDD.Data;
using ExpressMapper;
using System;
using System.Collections.ObjectModel;
using CoreModels = DDD.Core.Models;
using ServiceModels = DDD.Service.Models;

namespace DDD.Service.Mappers
{
    internal class CustomerMapper : ICustomTypeMapper<ServiceModels.Customer, CoreModels.Customer>
    {
        public CoreModels.Customer Map(IMappingContext<ServiceModels.Customer, CoreModels.Customer> context)
        {
            var session = SessionFactoryProvider.SessionFactory.RetrieveSharedSession();

            if (context.Source == null)
                return null;

            if (context.Source.Id != Guid.Empty)
                return session.Load<CoreModels.Customer>(context.Source.Id);

            if (context.Destination == null)
                context.Destination = new CoreModels.Customer();

            context.Destination.Accept(context.Source.MapTo(default(InitializeIdentityVisitor)));

            return context.Destination;
        }
    }

    internal class CustomerReverseMapper : ICustomTypeMapper<CoreModels.Customer, ServiceModels.Customer>
    {
        public ServiceModels.Customer Map(IMappingContext<CoreModels.Customer, ServiceModels.Customer> context)
        {
            var session = SessionFactoryProvider.SessionFactory.RetrieveSharedSession();

            if (context.Source == null)
                return null;

            if (context.Destination == null)
                context.Destination = new ServiceModels.Customer();

            context.Source.MapTo(context.Destination);
            context.Destination.Contacts = context.Source.Contacts.MapTo(default(Collection<ServiceModels.Contact>));

            return context.Destination;
        }
    }

    internal class CustomerInitializeIdentityVisitorMapper : ICustomTypeMapper<ServiceModels.Customer, InitializeIdentityVisitor>
    {
        public InitializeIdentityVisitor Map(IMappingContext<ServiceModels.Customer, InitializeIdentityVisitor> context)
        {
            if (context.Source == null)
                return null;

            if (context.Destination == null)
                context.Destination = new InitializeIdentityVisitor();

            context.Destination.FirstName = context.Source.FirstName;
            context.Destination.MiddleName = context.Source.MiddleName;
            context.Destination.LastName = context.Source.LastName;
            context.Destination.Gender = context.Source.Gender.MapTo(default(CoreModels.Gender));
            context.Destination.BirthDate = context.Source.BirthDate;
            context.Destination.Address = context.Source.Address.MapTo(default(CoreModels.Address));
            context.Destination.Contacts = context.Source.Contacts.MapTo(default(Collection<CoreModels.Contact>));

            return context.Destination;
        }
    }
}
