using DDD.Core.Models;
using MediatR;
using System;
using NHibernate;
using DDD.Core.Services.Accounts;

namespace DDD.Service.Accounts.SavingsAccounts
{
    public class SavingsAccountCreate
    {
        public class Request : Models.SavingsAccount, IRequest<Response> { }

        public class Response 
        {
            public Guid Id { get; set; }
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
                    var account = new SavingsAccount();
                    account.Accept(new AccountCreateVisitor()
                    {

                    });

                    transaction.Commit();
                }

                return response;
            }
        }
    }
}
