using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Controllers;
using Backend.Repositories;
using Backend.Models;
using NUnit.Framework.Legacy;
using NUnit.Framework;
using NUnit;


namespace UBB_Business_Ads.Tests
{
    [TestFixture]
    internal class BankAccountControllerTest
    {
        [TestCase ("", "Surname", "testAccount@gmail.com", "0740123456", "Cluj", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "123456789", "Name Surname", "12/23")]
        [TestCase ("Name", "", "testAccount@gmail.com", "0740123456", "Cluj", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "123456789", "Name Surname", "12/23")]
        [TestCase ("Name", "Surname", "", "0740123456", "Cluj", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "123456789", "Name Surname", "12/23")]
        [TestCase ("Name", "Surname", "testAccount@gmail.com", "aaa", "Cluj", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "123456789", "Name Surname", "12/23")]
        [TestCase ("Name", "Surname", "testAccount@gmail.com", "0740123456", "", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "123456789", "Name Surname", "12/23")]
        [TestCase ("Name", "Surname", "testAccount@gmail.com", "0740123456", "Cluj", "", "Str. SomeStreet, Nr. 1", "123456789", "Name Surname", "12/23")]
        [TestCase ("Name", "Surname", "testAccount@gmail.com", "0740123456", "Cluj", "Cluj-Napoca", "", "123456789", "Name Surname", "12/23")]
        [TestCase ("Name", "Surname", "testAccount@gmail.com", "0740123456", "Cluj", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "aaa", "Name Surname", "12/23")]
        [TestCase ("Name", "Surname", "testAccount@gmail.com", "0740123456", "Cluj", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "123456789", "", "12/23")]
        [TestCase ("Name", "Surname", "testAccount@gmail.com", "0740123456", "Cluj", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "123456789", "Name Surname", "")]
        public void UpdateBankAccount_InvalidData_ThrowsException(string name, string surname, string email, string phoneNumber, string county, string city, string address, string number, string holderName, string expiryDate)
        {
            var bankAccount = new BankAccount
            {
                Email = "testAccount@gmail.com",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23"
            };
            var accountRepository = new AccountRepository(bankAccount);
            BankAccountController bankAccountController=new BankAccountController(accountRepository);

            var ex = Assert.Catch<Exception>(() => bankAccountController.UpdateBankAccount(name, surname, email, phoneNumber, county, city, address, number, holderName, expiryDate));

            StringAssert.Contains("Invalid bank account data!", ex.Message);

        }
        [TestCase("NewName", "NewSurname", "NewTestAccount@gmail.com", "0740123456", "Cluj", "Cluj-Napoca", "Str. SomeStreet, Nr. 1", "123456789", "Name Surname", "12/23")]
        public void UpdateBankAccount_ValidData_NoException(string name, string surname, string email, string phoneNumber, string county, string city, string address, string number, string holderName, string expiryDate)
        {
            var bankAccount = new BankAccount
            {
                Email = "testAccount@gmail.com",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23"
            };
            var accountRepository = new AccountRepository(bankAccount);
            BankAccountController bankAccountController = new BankAccountController(accountRepository);

            Assert.DoesNotThrow(()=> bankAccountController.UpdateBankAccount(name, surname, email, phoneNumber, county, city, address, number, holderName, expiryDate));

        }

        [Test]
        public void GetBankAccount_IsCorrect_ReturnsBankAccount()
        {
            var bankAccount = new BankAccount
            {
                Email = "testAccount@gmail.com",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23"
            };
            var accountRepository = new AccountRepository(bankAccount);
            BankAccountController bankAccountController = new BankAccountController(accountRepository);

            var result= bankAccountController.GetBankAccount();

            // Assert.That(areEqual, Is.True);
            //Assert.AreEqual(result, bankAccount);
            Assert.That(result.Email, Is.EqualTo(bankAccount.Email));
            Assert.That(result.Name, Is.EqualTo(bankAccount.Name));
            Assert.That(result.Surname, Is.EqualTo(bankAccount.Surname));
            Assert.That(result.PhoneNumber, Is.EqualTo(bankAccount.PhoneNumber));
            Assert.That(result.County, Is.EqualTo(bankAccount.County));
            Assert.That(result.City, Is.EqualTo(bankAccount.City));
            Assert.That(result.Address, Is.EqualTo(bankAccount.Address));
            Assert.That(result.Number, Is.EqualTo(bankAccount.Number));
            Assert.That(result.HolderName, Is.EqualTo(bankAccount.HolderName));
            Assert.That(result.ExpiryDate, Is.EqualTo(bankAccount.ExpiryDate));

        }


    }
}
