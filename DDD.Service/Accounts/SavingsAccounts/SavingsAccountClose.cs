using DDD.Common.Extentions;
using DDD.Core.Models;
using DDD.Core.Services.Accounts;
using MediatR;
using NHibernate;
using System;

namespace DDD.Service.Accounts.SavingsAccounts
{
    public class SavingsAccountClose
    {
        public class Request : IRequest<Response>
        {
            public Guid Id { get; set; }
        }

        public class Response
        {
            public Models.Money WithdrawnAmount { get; set; }
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
                    var closeVisitor = new SavingsAccountCloseVisitor();
                    account.Accept(closeVisitor);

                    transaction.Commit();
                    closeVisitor.MapTo(response);
                }

                return response;
            }
        }
    }
}
