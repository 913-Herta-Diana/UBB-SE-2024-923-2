// <copyright file="AccountRepositoryTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Tests.RepositoryTests
{
    using Backend.Models;
    using Backend.Repositories;
    using Backend.Services;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class AccountRepositoryTests
    {
        private AccountRepository accountRepository;
        private BankAccount bankAccount;

        [SetUp]
        public void Setup()
        {
            this.bankAccount = new BankAccount
            {
                Email = "test@example.com",
                Name = "John",
                Surname = "Doe",
                PhoneNumber = "123456789",
                County = "Test County",
                City = "Test City",
                Address = "Test Address",
                Number = "1234567890123456",
                HolderName = "John Doe",
                ExpiryDate = "12/24",
            };
            this.accountRepository = new AccountRepository(this.bankAccount);
        }

        [Test]
        public void Getter_Returns_Decrypted_BankAccount()
        {
            var decryptedAccount = this.accountRepository.BankAccount;

            Assert.Multiple(() =>
            {
                Assert.That(decryptedAccount, Is.Not.Null);
                Assert.That(decryptedAccount.Email, Is.EqualTo(this.bankAccount.Email));
                Assert.That(decryptedAccount.Name, Is.EqualTo(this.bankAccount.Name));
                Assert.That(decryptedAccount.Surname, Is.EqualTo(this.bankAccount.Surname));
                Assert.That(decryptedAccount.PhoneNumber, Is.EqualTo(this.bankAccount.PhoneNumber));
                Assert.That(decryptedAccount.County, Is.EqualTo(this.bankAccount.County));
                Assert.That(decryptedAccount.City, Is.EqualTo(this.bankAccount.City));
                Assert.That(decryptedAccount.Address, Is.EqualTo(this.bankAccount.Address));
                Assert.That(decryptedAccount.Number, Is.EqualTo(this.bankAccount.Number));
                Assert.That(decryptedAccount.HolderName, Is.EqualTo(this.bankAccount.HolderName));
                Assert.That(decryptedAccount.ExpiryDate, Is.EqualTo(this.bankAccount.ExpiryDate));
            });
        }

        [Test]
        public void Setter_Encrypts_BankAccount_Properties()
        {
            this.accountRepository.BankAccount = this.bankAccount;

            Assert.Multiple(() =>
            {
                Assert.That(this.accountRepository.BankAccount, Is.Not.Null);
                Assert.That(this.accountRepository.BankAccount.Email, Is.EqualTo(this.bankAccount.Email));
                Assert.That(this.accountRepository.BankAccount.Name, Is.EqualTo(this.bankAccount.Name));
                Assert.That(this.accountRepository.BankAccount.Surname, Is.EqualTo(this.bankAccount.Surname));
                Assert.That(this.accountRepository.BankAccount.PhoneNumber, Is.EqualTo(this.bankAccount.PhoneNumber));
                Assert.That(this.accountRepository.BankAccount.County, Is.EqualTo(this.bankAccount.County));
                Assert.That(this.accountRepository.BankAccount.City, Is.EqualTo(this.bankAccount.City));
                Assert.That(this.accountRepository.BankAccount.Address, Is.EqualTo(this.bankAccount.Address));
                Assert.That(this.accountRepository.BankAccount.Number, Is.EqualTo(this.bankAccount.Number));
                Assert.That(this.accountRepository.BankAccount.HolderName, Is.EqualTo(this.bankAccount.HolderName));
                Assert.That(this.accountRepository.BankAccount.ExpiryDate, Is.EqualTo(this.bankAccount.ExpiryDate));
            });
        }
    }
}