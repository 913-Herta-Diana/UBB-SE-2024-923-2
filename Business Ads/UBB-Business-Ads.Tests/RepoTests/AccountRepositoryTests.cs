// <copyright file="AccountRepositoryTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UBB_Business_Ads.Tests.RepoTests
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
            bankAccount = new BankAccount
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
            accountRepository = new AccountRepository(bankAccount);
        }

        [Test]
        public void Getter_Returns_Decrypted_BankAccount()
        {
            var decryptedAccount = accountRepository.BankAccount;

            Assert.Multiple(() =>
            {
                Assert.That(decryptedAccount, Is.Not.Null);
                Assert.That(decryptedAccount.Email, Is.EqualTo(bankAccount.Email));
                Assert.That(decryptedAccount.Name, Is.EqualTo(bankAccount.Name));
                Assert.That(decryptedAccount.Surname, Is.EqualTo(bankAccount.Surname));
                Assert.That(decryptedAccount.PhoneNumber, Is.EqualTo(bankAccount.PhoneNumber));
                Assert.That(decryptedAccount.County, Is.EqualTo(bankAccount.County));
                Assert.That(decryptedAccount.City, Is.EqualTo(bankAccount.City));
                Assert.That(decryptedAccount.Address, Is.EqualTo(bankAccount.Address));
                Assert.That(decryptedAccount.Number, Is.EqualTo(bankAccount.Number));
                Assert.That(decryptedAccount.HolderName, Is.EqualTo(bankAccount.HolderName));
                Assert.That(decryptedAccount.ExpiryDate, Is.EqualTo(bankAccount.ExpiryDate));
            });
        }

        [Test]
        public void Setter_Encrypts_BankAccount_Properties()
        {
            accountRepository.BankAccount = bankAccount;

            Assert.Multiple(() =>
            {
                Assert.That(accountRepository.BankAccount, Is.Not.Null);
                Assert.That(accountRepository.BankAccount.Email, Is.EqualTo(bankAccount.Email));
                Assert.That(accountRepository.BankAccount.Name, Is.EqualTo(bankAccount.Name));
                Assert.That(accountRepository.BankAccount.Surname, Is.EqualTo(bankAccount.Surname));
                Assert.That(accountRepository.BankAccount.PhoneNumber, Is.EqualTo(bankAccount.PhoneNumber));
                Assert.That(accountRepository.BankAccount.County, Is.EqualTo(bankAccount.County));
                Assert.That(accountRepository.BankAccount.City, Is.EqualTo(bankAccount.City));
                Assert.That(accountRepository.BankAccount.Address, Is.EqualTo(bankAccount.Address));
                Assert.That(accountRepository.BankAccount.Number, Is.EqualTo(bankAccount.Number));
                Assert.That(accountRepository.BankAccount.HolderName, Is.EqualTo(bankAccount.HolderName));
                Assert.That(accountRepository.BankAccount.ExpiryDate, Is.EqualTo(bankAccount.ExpiryDate));
            });
        }
    }
}