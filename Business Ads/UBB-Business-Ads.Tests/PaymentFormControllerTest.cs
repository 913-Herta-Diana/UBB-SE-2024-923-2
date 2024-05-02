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
    internal class PaymentFormControllerTest
    {
        [Test]
        public void SendPaymentConfirmationMailAsync_IsCorrect_ReturnsTask()
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
            var mockProduct = new ProductMock
            {
                Name = "Product",
                Description = "Description",
                Price = "100",
                Image = "doggo.png"
            };
            var productRepository = new ProductRepository(mockProduct);
            PaymentFormController paymentFormController = new PaymentFormController(accountRepository, productRepository);

            //var result=paymentFormController.SendPaymentConfirmationMailAsync();

            Assert.DoesNotThrow(() => paymentFormController.SendPaymentConfirmationMailAsync());
        }

        [Test]
        public void GetProduct_IsCorrect_ReturnsProduct()
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
            var mockProduct = new ProductMock
            {
                Name = "Product",
                Description = "Description",
                Price = "100",
                Image = "doggo.png"
            };
            var productRepository = new ProductRepository(mockProduct);
            PaymentFormController paymentFormController = new PaymentFormController(accountRepository, productRepository);


            var result= paymentFormController.GetProduct();

            Assert.That(result.Name, Is.EqualTo(mockProduct.Name));
            Assert.That(result.Description, Is.EqualTo(mockProduct.Description));
            Assert.That(result.Price, Is.EqualTo(mockProduct.Price));
            Assert.That(result.Image, Is.EqualTo(mockProduct.Image));

        }
    }
}
