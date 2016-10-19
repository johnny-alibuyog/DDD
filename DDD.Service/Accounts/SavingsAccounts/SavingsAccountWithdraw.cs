using DDD.Common.Extentions;
using DDD.Core.Models;
using DDD.Core.Services.Accounts;
using MediatR;
using NHibernate;
using System;

namespace DDD.Service.Accounts.SavingsAccounts
{
    public class SavingsAccountWithdraw
    {
        public class Request : IRequest<Response>
        {
            public Guid Id { get; set; }

            public DateTime Date { get; set; }

            public Models.Money Amount { get; set; }
        }

        public class Response
        {
            public Models.Money CurrentBalance { get; set; }
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
                    var account = session.Get<SavingsAccount>(message.Id);
                    var withdrawVisitor = message.MapTo(default(SavingsAccountWithdrawVisitor));
                    account.Accept(withdrawVisitor);

                    transaction.Commit();
                    account.MapTo(response);
                }

                return response;
            }
        }
    }
}
