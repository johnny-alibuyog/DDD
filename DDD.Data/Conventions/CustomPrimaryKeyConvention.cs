﻿using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace DDD.Data.Conventions
{
    public class CustomPrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column(instance.EntityType.Name + "Id");
        }
    }
}
