// <copyright file="BankAccountModelTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UBB_Business_Ads.Tests.Test_models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Backend.Models;
    using NUnit;
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    internal class BankAccountModelTest
    {
        [Test]
        public void TestValidBankAccount_FieldsMustBeValid_SuccessValidBankAccount()
        {
            var validBankAccount = new BankAccount
            {
                Email = "test@example.com",
                Name = "John",
                Surname = "Doe",
                PhoneNumber = "123456789",
                County = "County",
                City = "City",
                Address = "123 Street",
                Number = "1234567890123456",
                HolderName = "John Doe",
                ExpiryDate = "12/25",
            };

            bool isValid = BankAccount.Validate(validBankAccount);

            Assert.That(isValid, Is.True);
        }

        [Test]
        public void TestInvalidBankAccount_FieldsShouldBeInvalid_NotValidBankAccount()
        {
            var invalidBankAccount = new BankAccount
            {
                Email = "invalid-email",
                Name = "J",
                Surname = "D",
                PhoneNumber = "12345",
                County = string.Empty,
                City = string.Empty,
                Address = string.Empty,
                Number = "123",
                HolderName = string.Empty,
                ExpiryDate = "12",
            };

            bool isValid = BankAccount.Validate(invalidBankAccount);

            Assert.That(isValid, Is.False);
        }
    }
}
