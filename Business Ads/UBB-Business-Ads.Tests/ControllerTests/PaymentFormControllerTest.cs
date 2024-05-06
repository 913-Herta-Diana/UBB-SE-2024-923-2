// <copyright file="PaymentFormControllerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UBB_Business_Ads.Tests.ControllerTests
{
    using Backend.Controllers;
    using Backend.Models;
    using Backend.Repositories;
    using NUnit.Framework;

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
                ExpiryDate = "12/23",
            };
            var accountRepository = new AccountRepository(bankAccount);
            var mockProduct = new Product
            {
                Name = "Product",
                Description = "Description",
                Price = "100",
                Image = "doggo.png",
            };
            INterfaceProductRepository productRepository = new ProductRepository(mockProduct);
            InterfacePaymentFormController paymentFormController = new PaymentFormController(accountRepository, productRepository);

            // var result=paymentFormController.SendPaymentConfirmationMailAsync();
            Assert.DoesNotThrow(() => paymentFormController.SendPaymentConfirmationMailAsync());
        }

        [Test]
        public void SendPaymentConfirmationmailAsync_InvalidReceiverData_ThrowsException()
        {
            var bankAccount = new BankAccount
            {
                Email = " ",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23",
            };
            var accountRepository = new AccountRepository(bankAccount);
            var mockProduct = new ProductMock
            {
                Name = "Product",
                Description = "Description",
                Price = "100",
                Image = "doggo.png",
            };
            INterfaceProductRepository productRepository = new ProductRepository(mockProduct);
            InterfacePaymentFormController paymentFormController = new PaymentFormController(accountRepository, productRepository);

            var ex = Assert.Catch<Exception>(() => paymentFormController.SendPaymentConfirmationMailAsync());

            Assert.That(ex.Message, Does.Contain("Receiver email cannot be null or empty."));
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
                ExpiryDate = "12/23",
            };
            var accountRepository = new AccountRepository(bankAccount);
            var mockProduct = new Product
            {
                Name = "Product",
                Description = "Description",
                Price = "100",
                Image = "doggo.png",
            };
            INterfaceProductRepository productRepository = new ProductRepository(mockProduct);
            InterfacePaymentFormController paymentFormController = new PaymentFormController(accountRepository, productRepository);

            var result = paymentFormController.GetProduct();

            Assert.Multiple(() =>
            {
                Assert.That(result.Name, Is.EqualTo(mockProduct.Name));
                Assert.That(result.Description, Is.EqualTo(mockProduct.Description));
                Assert.That(result.Price, Is.EqualTo(mockProduct.Price));
                Assert.That(result.Image, Is.EqualTo(mockProduct.Image));
            });
        }
    }
}
