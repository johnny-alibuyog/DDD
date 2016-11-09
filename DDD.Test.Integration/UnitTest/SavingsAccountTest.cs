using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Test.UnitTest
{
    [TestFixture]
    public class SavingsAccountTest
    {

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
            Assert.Throws<BusinessException>(code: () => this._mediator.Send(new SavingsAccountWithdraw.Request()
            {
                Id = this._accountId,
                Date = DateTime.UtcNow,
                Amount = new Money(8000M),
            }));
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
