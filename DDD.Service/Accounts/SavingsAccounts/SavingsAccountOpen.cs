using DDD.Common.Extentions;
using DDD.Core.Models;
using DDD.Core.Services.Accounts;
using DDD.Data;
using MediatR;
using NHibernate;
using System;

namespace DDD.Service.Accounts.SavingsAccounts
{
    public class SavingsAccountOpen
    {
        public class Request : IRequest<Response>
        {
            public Models.Customer Owner { get; set; }

            public string AccountName { get; set; }

            public string AccountNumber { get; set; }

            public Models.Money InitialDeposit { get; set; }

            public DateTime Date { get; set; }
        }

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

                using (var session = this._sessionFactory.RetrieveSharedSession())
                using (var transaction = session.BeginTransaction())
                {
                    var account = new SavingsAccount();
                    var openVisitor = message.MapTo(default(SavingsAccountOpenVisitor));
                    account.Accept(openVisitor);

                    session.Save(account);
                    transaction.Commit();

                    account.MapTo(response);

                    this._sessionFactory.ReleaseSharedSession();
                }

                return response;
            }
        }
    }
}
