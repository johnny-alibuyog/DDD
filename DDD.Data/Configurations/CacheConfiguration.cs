using DDD.Core.Models;
using NHibernate.Caches.SysCache2;
using NHibernate.Cfg;

namespace DDD.Data.Configurations
{
    internal static class CacheConfiguration
    {
        private const string RegionName = "hourly";

        public static void Configure(this Configuration config)
        {
            config
                .SetProperty(Environment.UseSecondLevelCache, "true")
                .SetProperty(Environment.UseQueryCache, "true")
                .Cache(c => c.Provider<SysCacheProvider>())
                .EntityCache<Currency>(x =>
                {
                    x.Strategy = EntityCacheUsage.ReadWrite;
                    x.RegionName = CacheConfiguration.RegionName;
                })
                .EntityCache<Person>(x =>
                {
                    x.Strategy = EntityCacheUsage.ReadWrite;
                    x.RegionName = CacheConfiguration.RegionName;
                });
        }
    }
}
