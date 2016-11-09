using DDD.Common.Extentions;
using DDD.Core.Models;
using DDD.Core.Services.Accounts;
using DDD.Data;
using MediatR;
using NHibernate;
using System;

namespace DDD.Service.Accounts.SavingsAccounts
{
    public class SavingsAccountDeposit
    {
        public class Request : IRequest<Response>
        {
            public Guid Id { get; set; }

            public DateTime Date { get; set; }

            public Models.Money Amount { get; set; }
        }

        public class Response
        {
            public Models.Money Balance { get; set; }
        }

        public class Handler : RequestHandlerBase<Request, Response>
        {
            public Handler(ISessionFactory sessionFactory) : base(sessionFactory) { }

            public override Response Handle(Request message)
            {
                var response = new Response();

                using (var session = _sessionFactory.RetrieveSharedSession())
                using (var transaction = session.BeginTransaction())
                {
                    var account = session.Get<SavingsAccount>(message.Id);
                    var depositVisitor = message.MapTo(default(SavingsAccountDepositVisitor));
                    account.Accept(depositVisitor);

                    transaction.Commit();
                    account.MapTo(response);

                    _sessionFactory.ReleaseSharedSession();
                }

                return response;
            }
        }
    }
}
