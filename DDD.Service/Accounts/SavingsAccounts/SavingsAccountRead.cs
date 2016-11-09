using DDD.Common.Extentions;
using DDD.Core.Models;
using MediatR;
using NHibernate;
using System;
using System.Linq;

namespace DDD.Service.Accounts.SavingsAccounts
{
    public class SavingsAccountRead
    {
        public class Request : IRequest<Response>
        {
            public Guid Id { get; set; }
        }

        public class Response : Models.SavingsAccount { }

        public class Handler : RequestHandlerBase<Request, Response>
        {
            public Handler(ISessionFactory sessionFactory) : base(sessionFactory) { }

            public override Response Handle(Request message)
            {
                var response = new Response();

                using (var session = this._sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var account = session.QueryOver<SavingsAccount>()
                        .Where(x => x.Id == message.Id)
                        .Fetch(x => x.Owner).Eager
                        .Fetch(x => x.Owner.Contacts).Eager
                        .Fetch(x => x.Balance.Currency).Eager
                        .Fetch(x => x.Transactions).Eager
                        .Fetch(x => x.Transactions.First().Amount.Currency).Eager
                        .Fetch(x => x.Transactions.First().CurrentBalance.Currency).Eager
                        .SingleOrDefault();

                    account.MapTo(response);

                    transaction.Commit();
                }

                return response;
            }
        }
    }
}
