using DDD.Common.Extentions;
using DDD.Core.Models;
using MediatR;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace DDD.Service.Accounts.SavingsAccounts
{
    public class SavingsAccountList
    {
        public class Request : IRequest<Response> { }

        public class Response : List<Models.SavingsAccount>
        {
            public Response() { }

            public Response(IEnumerable<Models.SavingsAccount> items) : base(items) { }
        }

        public class Handler : RequestHandlerBase<Request, Response>
        {
            public Handler(ISessionFactory sessionFactory) : base(sessionFactory) { }

            public override Response Handle(Request message)
            {
                var response = new Response();

                using (var session = this._sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var accounts = session.QueryOver<SavingsAccount>()
                        .Fetch(x => x.Owner).Eager
                        .Fetch(x => x.Balance.Currency).Eager
                        .Fetch(x => x.Transactions).Eager
                        .Fetch(x => x.Transactions.First().Amount.Currency).Eager
                        .Fetch(x => x.Transactions.First().CurrentBalance.Currency).Eager
                        .List();

                    response = new Response(accounts.MapTo(default(List<Models.SavingsAccount>)));
                }

                return response;
            }
        }
    }
}
