using Autofac;
using DDD.Service.Seeders;

namespace DDD.Test.IntegrationTest.Bootstrap.Modules
{
    public class SeederModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CurrencySeeder>()
              .As<Seeder>();
        }
    }
}
