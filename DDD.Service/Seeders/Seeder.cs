using NHibernate;

namespace DDD.Service.Seeders
{
    public abstract class Seeder
    {
        protected readonly ISessionFactory _sessionFactory;

        public abstract void Seed();

        public Seeder(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }
    }
}
