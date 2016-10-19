using DDD.Core.Models;
using NHibernate;
using NHibernate.Linq;
using System.Linq;

namespace DDD.Service.Seeders
{
    public class CurrencySeeder : Seeder
    {
        public CurrencySeeder(ISessionFactory sessionFactory) : base(sessionFactory) { }

        public override void Seed()
        {
            using (var session = this._sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                if (!session.Query<Currency>().Any())
                {
                    session.Save(Currency.PHP);
                }

                transaction.Commit();
            }
        }
    }
}
