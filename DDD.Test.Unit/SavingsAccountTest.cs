using DDD.Common.Exceptions;
using DDD.Core.Models;
using DDD.Core.Services.Accounts;
using DDD.Core.Services.Customers;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DDD.Test.Unit
{
    [TestFixture]
    public class SavingsAccountTest
    {
        [Test]
        public void ShouldAddDepositAmountToBalance()
        {
            // arrange
            var account = MockData.Customer;
            var deposit = new Money(2000M, Currency.PHP);
            var expected = account.Balance + deposit;

            // act
            account.Accept(new SavingsAccountDepositVisitor()
            {
                Date = DateTime.UtcNow,
                Amount = deposit,
            });

            // assert
            Assert.AreEqual(expected, account.Balance);
        }

        [Test]
        public void ShouldSubtractWithdrwanAmountToBalance()
        {
            // arrange
            var account = MockData.Customer;
            var deposit = new Money(2000M, Currency.PHP);
            var expected = account.Balance - deposit;

            // act
            account.Accept(new SavingsAccountWithdrawVisitor()
            {
                Date = DateTime.UtcNow,
                Amount = deposit,
            });

            // assert
            Assert.AreEqual(expected, account.Balance);
        }

        [Test]
        public void ShouldThrowErrorWhenWithdrwanAmountIsGreaterThanBalance()
        {
            // assert
            Assert.Throws<BusinessException>(() =>
            {
                var account = MockData.Customer;
                account.Accept(new SavingsAccountWithdrawVisitor()
                {
                    Date = DateTime.UtcNow,
                    Amount = new Money(95000000000100M),
                });
            });
        }
    }

    public class MockData
    {
        public static readonly SavingsAccount Customer = new SavingsAccount(new SavingsAccountOpenVisitor()
        {
            Date = DateTime.UtcNow,
            AccountName = "Johnny A",
            AccountNumber = "483545644654",
            Owner = new Customer(new InitializeIdentityVisitor()
            {
                FirstName = "Johnny",
                LastName = "Abarrientos",
                BirthDate = new DateTime(1970, 7, 17),
                Gender = Gender.Male,
                Address = new Address(city: "Naga", state: "Camarines Sur"),
                Contacts = new List<Contact>()
                {
                    new Fax("johnn@flying.a"),
                    new Email("johnn@flying.a"),
                    new Mobile("5465464546"),
                    new Landline("8651231353"),
                }
            }),
            InitialDeposit = new Money(95000000000000M, Currency.PHP),
        });
    }
}
