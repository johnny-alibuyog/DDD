using DDD.Common.Configurations;
using DDD.Data.Configurations;
using DDD.Data.Conventions;
using DDD.Data.ModelDefenitions;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Bytecode;
using NHibernate.Validator.Engine;

namespace DDD.Data
{
    public interface IAuditProvider
    {
        object GetCurrentUserId();
    }

    public class SessionFactoryProvider : ISessionFactoryProvider
    {
        internal static ValidatorEngine Validator { get; private set; }

        internal static IAuditProvider AuditProvider { get; private set; }

        public static ISessionFactory SessionFactory { get; private set; }

        public virtual ISessionFactory GetSessionFactory() => SessionFactoryProvider.SessionFactory;

        public SessionFactoryProvider(ValidatorEngine validator, IAuditProvider auditProvider)
        {
            SessionFactoryProvider.Validator = validator;

            SessionFactoryProvider.AuditProvider = auditProvider;

            SessionFactoryProvider.SessionFactory = Fluently.Configure()
                .Database(PostgreSQLConfiguration.PostgreSQL82
                    .ConnectionString(x => x
                        .Host(DbConfig.Instance.Host)
                        .Port(DbConfig.Instance.Port)
                        .Database(DbConfig.Instance.Name)
                        .Username(DbConfig.Instance.Username)
                        .Password(DbConfig.Instance.Password)
                    )
                    .QuerySubstitutions("true 1, false 0, yes y, no n")
                    .DefaultSchema("public")
                    .AdoNetBatchSize(15)
                    .FormatSql()
                    .ShowSql()
                )
                .Mappings(x => x
                    .FluentMappings.AddFromAssemblyOf<UserMapping>()
                    .Conventions.AddFromAssemblyOf<CustomJoinedSubclassConvention>()
                    .Conventions.Setup(o => o.Add(AutoImport.Never()))
                    .ExportTo(DbConfig.Instance.GetWorkingPath("Mappings"))
                )
                .ProxyFactoryFactory<DefaultProxyFactoryFactory>()
                .ExposeConfiguration(EventListenerConfiguration.Configure)
                .ExposeConfiguration(CacheConfiguration.Configure)
                .ExposeConfiguration(ValidatorConfiguration.Configure)
                .ExposeConfiguration(IndexForeignKeyConfiguration.Configure)
                .ExposeConfiguration(SchemaConfiguration.Configure)
                .ExposeConfiguration(SessionContextConfiguration.Configure)
                .BuildSessionFactory();
        }
    }
}
