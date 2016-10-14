using DDD.Data.ModelDefenitions;
using NHibernate.Cfg;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Cfg.Loquacious;
using NHibernate.Validator.Engine;
using System.Reflection;

namespace DDD.Data.Configurations
{
    internal static class ValidatorConfiguration
    {
        public static void Configure(this Configuration configuration)
        {
            var validatorEngine = GetValidatorEngine();
            new ValidatorSharedEngineProvider(validatorEngine).UseMe();
            configuration.Initialize(validatorEngine);
        }

        private static ValidatorEngine GetValidatorEngine()
        {
            var configuration = GetConfiguration();
            SessionFactoryProvider.Validator.Configure(configuration);
            return SessionFactoryProvider.Validator;
        }

        private static FluentConfiguration GetConfiguration()
        {
            var configuration = new FluentConfiguration();
            configuration
                .SetMessageInterpolator<ConventionMessageInterpolator>()
                .SetCustomResourceManager("DDD.Data.Properties.CustomValidatorMessages", Assembly.Load("DDD.Data"))
                .SetDefaultValidatorMode(ValidatorMode.OverrideExternalWithAttribute)
                .Register(Assembly.Load(typeof(UserMapping).Assembly.FullName).ValidationDefinitions())
                .IntegrateWithNHibernate
                    .ApplyingDDLConstraints()
                    .And.RegisteringListeners();

            return configuration;
        }
    }
}
