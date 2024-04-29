namespace UBB_Business_Ads.Tests
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
        public void ProductMock_SetAndGetProperties_Success()
        {
            var product = new ProductMock();

            product.Name = "Test Product";
            product.Description = "Test Description";
            product.Price = "$10.00";
            product.Image = "test_image.jpg";
            Assert.That(product.Name, Is.EqualTo("Test Product"));

            // Assert.Equal("Test Product", product.Name);
            Assert.That(product.Description, Is.EqualTo("Test Description"));

            // Assert.AreEqual("$10.00", product.Price);
            // ClassicAssert.AreEqual("$10.00", product.Price);
            Assert.That(product.Price, Is.EqualTo("$10.00"));
            Assert.That(product.Image, Is.EqualTo("test_image.jpg"));
        }
    }
}
