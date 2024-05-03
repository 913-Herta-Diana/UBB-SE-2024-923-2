// <copyright file="ProductMockModelTest.cs" company="PlaceholderCompany">
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
    internal class ProductMockModelTest
    {
        [Test]
        public void ProductMock_SetAndGetProperties_SuccessGettingAndSettingProperties()
        {
            var product = new ProductMock();

            product.Name = "Test Product";
            product.Description = "Test Description";
            product.Price = "$10.00";
            product.Image = "test_image.jpg";
            Assert.That(product.Name, Is.EqualTo("Test Product"));
            Assert.That(product.Description, Is.EqualTo("Test Description"));
            Assert.That(product.Price, Is.EqualTo("$10.00"));
            Assert.That(product.Image, Is.EqualTo("test_image.jpg"));
        }
    }
}
