using Autofac;
using DDD.Service.Accounts.SavingsAccounts;
using DDD.Service.Models;
using DDD.Test.IntegrationTest.Bootstrap;
using MediatR;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DDD.Test.IntegrationTest
{
    [TestFixture]
    public class SavingsAccountTest
    {
        [Test]
        public void Test()
        {
            var mediator = IoC.Container.Resolve<IMediator>();

            var respone = mediator.Send(new SavingsAccountOpen.Request()
            {
                Owner = new Customer()
                {
                    FirstName = "Johnny",
                    LastName = "Abarientos",
                    Address = new Address()
                    {
                        AddressLine1 = "AddressLine1",
                        AddressLine2 = "AddressLine2",
                        City = "City",
                        State = "State",
                        Country = "Country",
                        PostalCode = "PostalCode",
                    },
                    Contacts = new List<Contact>()
                    {
                        new Email() { Address = "j.a@b.com" },
                        new Mobile() { Number = "654864644" }
                    },
                },
                AccountName = "Johnny A",
                AccountNumber = "25847684546",
                Date = DateTime.UtcNow,
                InitialDeposit = new Money()
                {
                    Amount = 1000M,
                    Currency = Currency.PHP
                }
            });
        }
    }
}
