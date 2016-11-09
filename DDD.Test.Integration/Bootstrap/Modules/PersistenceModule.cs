using Autofac;
using DDD.Data;
using NHibernate.Validator.Engine;

namespace DDD.Test.IntegrationTest.Bootstrap.Modules
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuditProvider>()
                .As<IAuditProvider>();

            builder.RegisterType<ValidatorEngine>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<SessionFactoryProvider>()
                .As<ISessionFactoryProvider>()
                .SingleInstance();

            builder.Register(context => context.Resolve<ISessionFactoryProvider>().GetSessionFactory())
                .SingleInstance();
        }
    }

    public class AuditProvider : IAuditProvider
    {
        public object GetCurrentUserId()
        {
            return "admin1";
        }
    }
}
