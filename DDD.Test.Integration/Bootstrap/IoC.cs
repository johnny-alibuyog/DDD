using Autofac;
using DDD.Common.Pipes;
using DDD.Service.Mappers;
using DDD.Service.Seeders;
using System.Collections.Generic;
using System.Reflection;

namespace DDD.Test.IntegrationTest.Bootstrap
{
    public class IoC
    {
        public static readonly IContainer Container = IoC.Initialize();

        private static IContainer Initialize()
        {
            var contianer = new Pipeline<IContainer>()
                .Register(new BuildContainerStep())
                .Register(new RegisterModelMappingStep())
                .Register(new SeedDataStep())
                .Execute(null);

            return contianer;
        }

        private class BuildContainerStep : Step<IContainer>
        {
            protected override IContainer Process(IContainer input)
            {
                var builder = new ContainerBuilder();

                builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

                return builder.Build();
            }
        }

        private class RegisterModelMappingStep : Step<IContainer>
        {
            protected override IContainer Process(IContainer input)
            {
                new MappingRegistrar().Register();
                return input;
            }
        }

        private class SeedDataStep : Step<IContainer>
        {
            protected override IContainer Process(IContainer input)
            {
                var seeders = input.Resolve<IEnumerable<Seeder>>();
                foreach(var seeder in seeders)
                {
                    seeder.Seed();
                }
                return input;
            }
        }
    }
}
