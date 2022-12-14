using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace DDD.Data.Conventions
{
    public class CustomJoinedSubclassConvention : IJoinedSubclassConvention
    {
        private readonly PluralizationService _pluralizationService;

        public CustomJoinedSubclassConvention()
        {
            _pluralizationService = PluralizationService.CreateService(new CultureInfo("en-US"));
        }

        public void Apply(IJoinedSubclassInstance instance)
        {
            instance.Table(_pluralizationService.Pluralize(instance.EntityType.Name));
            //instance.Key.Column(instance.EntityType.Name + "Id");
        }
    }
}
