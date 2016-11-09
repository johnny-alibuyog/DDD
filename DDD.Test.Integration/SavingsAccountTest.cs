using Autofac;
using DDD.Common.Exceptions;
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
        private IMediator _mediator;
        private Guid _accountId;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mediator = IoC.Container.Resolve<IMediator>();

            var respone = this._mediator.Send(new SavingsAccountOpen.Request()
            {
                Owner = MockData.Customer,
                AccountName = "Johnny A",
                AccountNumber = "25847684546",
                Date = DateTime.UtcNow,
                InitialDeposit = new Money(5000M)
            });

            this._accountId = respone.Id;
        }

        [Test]
        public void ShouldAddDepositAmountToBalance()
        {
            // arrange
            var account = _mediator.Send(new SavingsAccountRead.Request() { Id = _accountId });
            var expected = account.Balance.Amount + 2000M;

            // act
            var response = this._mediator.Send(new SavingsAccountDeposit.Request()
            {
                Id = this._accountId,
                Date = DateTime.UtcNow,
                Amount = new Money(2000M),
            });

            // assert
            Assert.AreEqual(expected, response.Balance.Amount);
        }

        [Test]
        public void ShouldSubtractWithdrwanAmountToBalance()
        {
            // arrange
            var account = _mediator.Send(new SavingsAccountRead.Request() { Id = _accountId });
            var expected = account.Balance.Amount - 2000M;

            // act
            var response = this._mediator.Send(new SavingsAccountWithdraw.Request()
            {
                Id = this._accountId,
                Date = DateTime.UtcNow,
                Amount = new Money(2000M),
            });

            // assert
            Assert.AreEqual(expected, response.Balance.Amount);
        }

        [Test]
        public void ShouldThrowErrorWhenWithdrwanAmountIsGreaterThanBalance()
        {
            // assert
            Assert.Throws<BusinessException>(() =>
            {
                this._mediator.Send(new SavingsAccountWithdraw.Request()
                {
                    Id = this._accountId,
                    Date = DateTime.UtcNow,
                    Amount = new Money(8000M),
                });
            });
        }
    }

    public class MockData
    {
        public static readonly Customer Customer = new Customer()
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
        };
    }
}
