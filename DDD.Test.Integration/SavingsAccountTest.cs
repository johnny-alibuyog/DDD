using Autofac;
using DDD.Common.Exceptions;
using DDD.Service.Accounts.SavingsAccounts;
using DDD.Service.Models;
using DDD.Test.IntegrationTest.Bootstrap;
using MediatR;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDD.Test.IntegrationTest
{
    [TestFixture]
    public class SavingsAccountTest
    {
        private IMediator _mediator;
        private Guid _accountId;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _mediator = IoC.Container.Resolve<IMediator>();

            var respone = await this._mediator.Send(new SavingsAccountOpen.Request()
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
        public async Task ShouldAddDepositAmountToBalance()
        {
            // arrange
            var account = await _mediator.Send(new SavingsAccountRead.Request() { Id = _accountId });
            var expected = account.Balance.Amount + 2000M;

            // act
            var response = await this._mediator.Send(new SavingsAccountDeposit.Request()
            {
                Id = this._accountId,
                Date = DateTime.UtcNow,
                Amount = new Money(2000M),
            });

            // assert
            Assert.AreEqual(expected, response.Balance.Amount);
        }

        [Test]
        public async Task ShouldSubtractWithdrwanAmountToBalance()
        {
            // arrange
            var account = await _mediator.Send(new SavingsAccountRead.Request() { Id = _accountId });
            var expected = account.Balance.Amount - 2000M;

            // act
            var response = await this._mediator.Send(new SavingsAccountWithdraw.Request()
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
            Assert.ThrowsAsync<BusinessException>(async () =>
            {
                await this._mediator.Send(new SavingsAccountWithdraw.Request()
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
