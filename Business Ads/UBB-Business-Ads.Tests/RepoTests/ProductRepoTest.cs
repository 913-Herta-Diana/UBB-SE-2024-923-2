/*// <copyright file="ProductRepoTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UBB_Business_Ads.Tests.RepoTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using Backend.Models;
    using Backend.Repositories;
    using Backend.Services;
    using Moq;
    using NUnit;
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class ProductRepoTest
    {
        private ProductRepository productRepository;
        private ProductMock product;

        [SetUp]
        public void Setup()
        {
            this.productRepository = new ProductRepository(new ProductMock
            {
                Name = "Test Product",
                Description = "This is a test product",
                Price = "19.99",
                Image = "test.jpg",
            });
            this.product = new ProductMock
            {
                Name = "New Product",
                Description = "This is a new product",
                Price = "29.99",
                Image = "new.jpg",
            };
        }

        [Test]
        public void Test_Setter()
        {
            this.productRepository.Product = this.product;

            Assert.Multiple(() =>
            {
                Assert.That(this.productRepository.Product, Is.Not.Null);
                Assert.That(this.product, Is.Not.EqualTo(this.productRepository.Product));
                Assert.That(this.product.Name, Is.EqualTo(this.productRepository.Product.Name));
                Assert.That(this.product.Description, Is.EqualTo(this.productRepository.Product.Description));
                Assert.That(this.product.Price, Is.EqualTo(this.productRepository.Product.Price));
                Assert.That(this.product.Image, Is.EqualTo(this.productRepository.Product.Image));
            });
        }

        [Test]
        public void Test_Getter()
        {
            this.productRepository.Product = this.product;

            var decryptProduct = this.productRepository.Product;

            Assert.That(decryptProduct, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(decryptProduct.Name, Is.EqualTo("New Product"));
                Assert.That(decryptProduct.Description, Is.EqualTo("This is a new product"));
                Assert.That(decryptProduct.Price, Is.EqualTo("29.99"));
                Assert.That(decryptProduct.Image, Is.EqualTo("new.jpg"));
            });
        }
    }
}
*/